<template>
  <div id="hamming-encoder">
    <h1>Hamming code for <input type="number" v-model="numberOfDataBits" min="4" @input="initDataBits"/> data bits</h1>
    <br>
    <ul>
      <li v-for="(bit, index) in dataBits" :key="index">
        <input maxlength="1" :placeholder="'D' + index" v-model="bit.data" :class="[validateBit(bit.data) ? 'valid-input' : 'invalid-input']" />
      </li>
    </ul>
    <br>
    Data bits: <code>{{ dataBits }}</code>
    <br>
    <button @click="send">Send</button>
    <p>{{ status }}</p>
    <br>
    <table>
      <thead>
      <tr>
        <th>Initial Input</th>
        <th>Distorted Input</th>
        <th>Corrected Input</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="(entry, index) in tableData" :key="index">
        <td>{{ entry.initial }}</td>
        <td>{{ entry.distorted }}</td>
        <td>{{ entry.corrected }}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, watch, onMounted } from 'vue'

const dataBits = ref([])
const status = ref('')
const numberOfDataBits = ref(4)
const tableData = ref([])

const initDataBits = () => {
  dataBits.value = []
  for (let i = 0; i < numberOfDataBits.value; i++) {
    dataBits.value.push({ data: null })
  }
}

const send = async () => {
  if (validate(dataBits.value)) {
    const initialInput = dataBits.value.map(bit => bit.data).join('')
    const encodedMessage = encode(dataBits.value)
    status.value = `${encodedMessage} encoded sent to server`
    try {
      const response = await fetch('http://localhost:3000/message', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ bits: encodedMessage })
      })
      const data = await response.json()
      const distortedInput = data.distorted.join('')
      const correctedInput = data.corrected.join('')
      tableData.value.push({
        initial: initialInput,
        distorted: distortedInput,
        corrected: correctedInput
      })
      status.value = data.message
    } catch (error) {
      status.value = 'Error sending data to server'
    }
  } else {
    status.value = 'Input is not valid. Please use 0 or 1 as data bit values'
  }
}

const encode = (bits) => {
  const m = bits.length
  const r = Math.ceil(Math.log2(m + Math.ceil(Math.log2(m)) + 1))
  const n = m + r
  const encoded = new Array(n).fill(0)

  let j = 0
  for (let i = 0; i < n; i++) {
    if (Math.pow(2, j) === i + 1) {
      j++
    } else {
      encoded[i] = parseInt(bits.shift().data)
    }
  }

  for (let i = 0; i < r; i++) {
    const pos = Math.pow(2, i) - 1
    let parity = 0
    for (let k = pos; k < n; k += 2 * (pos + 1)) {
      for (let l = k; l < k + pos + 1 && l < n; l++) {
        parity ^= encoded[l]
      }
    }
    encoded[pos] = parity
  }

  return encoded
}

const validate = (bits) => {
  for (const bit of bits) {
    if (!validateBit(bit.data)) return false
  }
  return true
}

const validateBit = (character) => {
  if (character === null) return false
  return parseInt(character) === 0 || parseInt(character) === 1
}

watch(numberOfDataBits, initDataBits)

onMounted(() => {
  initDataBits()
})
</script>

<style scoped>
body {
  margin: 30px;
}

select {
  margin-top: -5px;
  padding: 5px;
}

ul {
  list-style: none;
  display: inline-block;
  margin: 0 0 20px;
  padding: 0 10px 0 0;
}

input {
  font-size: 16px;
  padding: 10px;
  width: 50px;
  text-align: center;
}

.invalid-input {
  border: 3px solid orange;
  transition: all 1000ms linear;
}

.valid-input {
  border: 3px solid green;
  background-color: green;
  color: white;
  transition: all 1000ms linear;
}

button {
  margin-top: 10px;
  padding: 10px;
}

code {
  background-color: #efffec;
  margin: 0;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
}

th {
  background-color: #f2f2f2;
  text-align: left;
}
</style>