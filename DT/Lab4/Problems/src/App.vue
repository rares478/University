<script setup>
import HuffmanComponent from './components/HuffmanComponent.vue';
import ShannonFanoComponent from './components/ShannonFanoComponent.vue';
</script>

<template>
  <main>
    <HuffmanComponent />
    <ShannonFanoComponent />
  </main>
</template>

<style>
body {
  background-color: #1e2a38;
  color: white;
  font-family: Arial, sans-serif;
  margin: 0;
  padding: 20px;
}

main {
  max-width: 1200px;
  margin: 0 auto;
}
</style>