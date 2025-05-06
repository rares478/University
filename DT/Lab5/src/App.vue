<script setup>
import { ref, onMounted, watch } from 'vue';
import {
  getManchesterLevelEncoding,
  getAMIEncoding,
  getMLT3Encoding,
  get4B5BNRZIEncoding,
  getDifferentialManchesterEncoding,
  getHDB3Encoding,
  getB8ZSEncoding,
  getNRZSEncoding,
  getNRZLEncoding,
  getNRZMEncoding
} from './baseband-codes.js';

const bits = ref([]);
const encodedBits = ref([]);
const numberOfBits = ref(8); // Changed to reactive ref
const selectedEncoding = ref('manchester');

// Helper functions
const validateBit = (character) => {
  if (character === null) return false;
  return (parseInt(character) === 0 || parseInt(character) === 1);
};

const getBitstream = (n) => {
  const result = [];
  for (let i = 0; i < n; i++) {
    let bit = { value: null };
    result.push(bit);
  }
  return result;
};

const updateBitstream = () => {
  // Preserve existing values when changing bit count
  const oldBits = [...bits.value];
  const newBits = getBitstream(numberOfBits.value);

  // Copy values from old bitstream to new bitstream where possible
  for (let i = 0; i < newBits.length && i < oldBits.length; i++) {
    newBits[i].value = oldBits[i].value;
  }

  bits.value = newBits;
  encode();
};

const encode = () => {
  switch(selectedEncoding.value) {
    case 'manchester':
      encodedBits.value = getManchesterLevelEncoding(bits.value);
      break;
    case 'differential-manchester':
      encodedBits.value = getDifferentialManchesterEncoding(bits.value);
      break;
    case 'ami':
      encodedBits.value = getAMIEncoding(bits.value);
      break;
    case 'hdb3':
      encodedBits.value = getHDB3Encoding(bits.value);
      break;
    case 'b8zs':
      encodedBits.value = getB8ZSEncoding(bits.value);
      break;
    case 'mlt3':
      encodedBits.value = getMLT3Encoding(bits.value);
      break;
    case '4b5bnrzi':
      encodedBits.value = get4B5BNRZIEncoding(bits.value);
      break;
    case 'nrzs':
      encodedBits.value = getNRZSEncoding(bits.value);
      break;
    case 'nrzl':
      encodedBits.value = getNRZLEncoding(bits.value);
      break;
    case 'nrzm':
      encodedBits.value = getNRZMEncoding(bits.value);
      break;
    default:
      encodedBits.value = getManchesterLevelEncoding(bits.value);
  }
};

// Watch for changes in numberOfBits
watch(numberOfBits, updateBitstream);

onMounted(() => {
  bits.value = getBitstream(numberOfBits.value);
});
</script>

<template>
  <main>
    <div id="baseband-encoder">
      <div class="encoder-controls">
        <div class="bit-selector">
          <label for="bit-count">Number of Bits:</label>
          <input
              type="number"
              id="bit-count"
              v-model.number="numberOfBits"
              min="2"
              max="16"
              class="bit-count-input"
          />
        </div>

        <div class="encoding-select">
          <label for="encoding-type">Encoding Type:</label>
          <select id="encoding-type" v-model="selectedEncoding" @change="encode()">
            <option value="manchester">Manchester</option>
            <option value="differential-manchester">Differential Manchester</option>
            <option value="ami">AMI</option>
            <option value="hdb3">HDB3</option>
            <option value="b8zs">B8ZS</option>
            <option value="mlt3">MLT-3</option>
            <option value="4b5bnrzi">4B/5B NRZI</option>
            <option value="nrzs">NRZ-S</option>
            <option value="nrzl">NRZ-L</option>
            <option value="nrzm">NRZ-M</option>
          </select>
        </div>

        <ul v-for="(bit, index) in bits" :key="index">
          <li>
            <input
                @change="encode()"
                maxlength="1"
                :placeholder="'B'+index"
                v-model="bit.value"
                :class="[validateBit(bit.value) ? 'valid-input' : 'invalid-input']"
            />
          </li>
        </ul>
      </div>

      <p>Bitstream data model: <code>{{ bits }}</code></p>
      <p>Baseband code representation: <code class="encoded">{{ encodedBits.join('') }}</code></p>
    </div>
  </main>
</template>

<style scoped>
select {
  margin-top: -5px;
  padding: 5px;
}

ul {
  list-style: none;
  display: inline-block;
  margin: 0 0 20px;
  padding: 0;
}

input {
  font-size: 16px;
  padding: 10px;
  width: 50px;
  text-align: center;
}

.bit-count-input {
  width: 60px;
  margin-left: 10px;
}

.invalid-input {
  border: 2px solid green;
  transition: all 1000ms linear;
}

.valid-input {
  border: 2px solid green;
  background-color: green;
  color: white;
  transition: all 1000ms linear;
}

button {
  margin-top: 10px;
  padding: 10px;
}

.encoded {
  letter-spacing: -6px;
  font-size: 30px;
  font-weight: bold;
}

.encoder-controls {
  margin-bottom: 20px;
}

.encoding-select, .bit-selector {
  margin-bottom: 15px;
}
</style>