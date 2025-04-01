<template>
  <div style="height:600px; width:800px">
    <p>vue-leaflet SSR Demo</p>
    <p v-if="loading">Getting your location...</p>
    <p v-if="locationError" class="error-message">{{ locationError }}</p>
    <l-map :useGlobalLeaflet="false" :center="center" :zoom="zoom">
      <l-geo-json :geojson="geojson" :options="geojsonOptions" />
      <l-tile-layer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"></l-tile-layer>
      <l-marker :lat-lng="center" v-if="!loading"></l-marker>
    </l-map>
  </div>
</template>

<script>
import "leaflet/dist/leaflet.css"
import { LMap, LGeoJson, LTileLayer, LMarker } from "@vue-leaflet/vue-leaflet";

export default {
  components: {
    LMap,
    LGeoJson,
    LTileLayer,
    LMarker
  },
  data() {
    return {
      center: [47.41322, -1.219482],
      zoom: 13,
      loading: true,
      locationError: null,
      geojson: {
        type: "FeatureCollection",
        features: [

        ],
      },
      geojsonOptions: {
        // Options that don't rely on Leaflet methods.
      },
    };
  },
  methods: {
    getUserLocation() {
      if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(
            (position) => {
              this.center = [
                position.coords.latitude,
                position.coords.longitude
              ];
              this.loading = false;
              this.locationError = null;
            },
            (error) => {
              this.loading = false;


              switch(error.code) {
                case 1:
                  this.locationError = "Location access denied. Using default location.";
                  break;
                case 2:
                  this.locationError = "Unable to determine your location. Using default location.";
                  break;
                case 3:
                  this.locationError = "Location request timed out. Using default location.";
                  break;
                default:
                  this.locationError = "Error getting location. Using default location.";
              }

              console.error("Geolocation error:", error.code, error.message);
            },
            {
              enableHighAccuracy: true,
              timeout: 10000,
              maximumAge: 60000
            }
        );
      } else {
        this.loading = false;
        this.locationError = "Geolocation is not supported by your browser. Using default location.";
      }
    }
  },
  mounted() {
    this.getUserLocation();
  },
  async beforeMount() {
    const { circleMarker } = await import("leaflet/dist/leaflet-src.esm");
    this.geojsonOptions.pointToLayer = (feature, latLng) =>
        circleMarker(latLng, { radius: 8 });
    this.mapIsReady = true;
  },
};
</script>

<style scoped>
.error-message {
  color: #e74c3c;
  margin-bottom: 10px;
}
</style>