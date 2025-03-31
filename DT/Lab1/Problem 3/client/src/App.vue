<script setup>
import ChatInterface from './components/ChatInterface.vue';
</script>

<template>
  <main>
    <ChatInterface />
  </main>
</template>

<style>
html, body {
  margin: 0;
  padding: 0;
  height: 100%;
  width: 100%;
  overflow: hidden;
}

main {
  height: 100vh;
  width: 100vw;
  padding: 0;
  margin: 0;
  display: flex;
}
</style>