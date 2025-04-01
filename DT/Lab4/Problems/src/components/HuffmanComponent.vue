<template>
  <div class="huffman-container">
    <h1>Huffman Compression</h1>

    <div class="input-section">
      <textarea
          v-model="inputText"
          placeholder="Enter text to compress..."
          rows="5"
          class="text-input"
      ></textarea>
      <button @click="compressText" class="compress-btn">Compress</button>
    </div>

    <div v-if="compressionResult" class="results-container">
      <div class="stats-container">
        <h2>Compression Statistics</h2>
        <div class="stats">
          <p>Original size: {{ stats.originalSize }} bits</p>
          <p>Compressed size: {{ stats.compressedSize }} bits</p>
          <p>Compression ratio: {{ stats.compressionRatio.toFixed(2) }}x</p>
          <p>Space savings: {{ stats.spaceSavings }}</p>
        </div>
      </div>

      <div class="codes-container">
        <h2>Huffman Codes</h2>
        <table class="codes-table">
          <thead>
          <tr>
            <th>Character</th>
            <th>Frequency</th>
            <th>Code</th>
          </tr>
          </thead>
          <tbody>
          <tr v-for="(code, char) in codes" :key="char">
            <td>{{ char === ' ' ? 'Space' : char }}</td>
            <td>{{ frequencies[char] }}</td>
            <td class="code">{{ code }}</td>
          </tr>
          </tbody>
        </table>
      </div>
    </div>

    <div id="huffman-tree-container" class="tree-container"></div>
  </div>
</template>

<script>
import { encode, getCompressionStats } from '../Huffman.js';
import * as d3 from 'd3';

export default {
  data() {
    return {
      inputText: '',
      compressionResult: null,
      encodedData: '',
      huffmanTree: null,
      codes: {},
      frequencies: {},
      stats: {}
    };
  },
  methods: {
    compressText() {
      if (!this.inputText.trim()) {
        alert("Please enter some text to compress");
        return;
      }

      // Perform Huffman encoding
      this.compressionResult = encode(this.inputText);
      this.encodedData = this.compressionResult.encodedData;
      this.huffmanTree = this.compressionResult.tree;
      this.codes = this.compressionResult.codes;

      // Calculate frequencies
      this.frequencies = {};
      for (let char of this.inputText) {
        this.frequencies[char] = (this.frequencies[char] || 0) + 1;
      }

      // Calculate stats
      this.stats = getCompressionStats(this.inputText, this.encodedData);

      // Render the tree
      this.$nextTick(() => {
        this.renderHuffmanTree();
      });
    },

    renderHuffmanTree() {
      if (!this.huffmanTree) return;

      const container = d3.select('#huffman-tree-container');
      container.selectAll("*").remove();

      // Convert Huffman tree to hierarchical format for D3
      const hierarchyData = this.convertToHierarchy(this.huffmanTree);

      const margin = {top: 40, right: 90, bottom: 50, left: 90};
      const width = 800 - margin.left - margin.right;
      const height = 500 - margin.top - margin.bottom;

      const svg = container.append("svg")
          .attr("width", width + margin.left + margin.right)
          .attr("height", height + margin.top + margin.bottom)
          .append("g")
          .attr("transform", `translate(${margin.left},${margin.top})`);

      const treemap = d3.tree().size([height, width]);

      const root = d3.hierarchy(hierarchyData);
      const treeData = treemap(root);

      // Add links
      svg.selectAll(".link")
          .data(treeData.links())
          .enter()
          .append("path")
          .attr("class", "link")
          .style("fill", "none")
          .style("stroke", "white")
          .style("stroke-width", "2px")
          .attr("d", d3.linkHorizontal()
              .x(d => d.y)
              .y(d => d.x));

      // Add nodes
      const node = svg.selectAll(".node")
          .data(treeData.descendants())
          .enter()
          .append("g")
          .attr("class", "node")
          .attr("transform", d => `translate(${d.y},${d.x})`);

      // Add circles to nodes
      node.append("circle")
          .attr("r", 10)
          .style("fill", d => d.data.isLeaf ? "lightsteelblue" : "#fff")
          .style("stroke", "steelblue")
          .style("stroke-width", "3px");

      // Add labels to nodes
      node.append("text")
          .attr("dy", ".35em")
          .attr("x", d => d.children ? -13 : 13)
          .attr("text-anchor", d => d.children ? "end" : "start")
          .style("fill", "white")
          .text(d => d.data.name);

      // Add path labels (0/1)
      svg.selectAll(".path-label")
          .data(treeData.links())
          .enter()
          .append("text")
          .attr("class", "path-label")
          .attr("x", d => (d.source.y + d.target.y) / 2)
          .attr("y", d => (d.source.x + d.target.x) / 2)
          .attr("dy", -5)
          .style("fill", "white")
          .style("font-size", "12px")
          .style("text-anchor", "middle")
          .text(d => d.target.data.edgeLabel);
    },

    convertToHierarchy(node) {
      if (!node) return null;

      const result = {
        name: node.char !== null ? node.char : node.freq.toString(),
        isLeaf: node.isLeaf(),
        freq: node.freq
      };

      if (node.left || node.right) {
        result.children = [];

        if (node.left) {
          const leftChild = this.convertToHierarchy(node.left);
          leftChild.edgeLabel = "0";
          result.children.push(leftChild);
        }

        if (node.right) {
          const rightChild = this.convertToHierarchy(node.right);
          rightChild.edgeLabel = "1";
          result.children.push(rightChild);
        }
      }

      return result;
    }
  }
};
</script>

<style scoped>
.huffman-container {
  padding: 20px;
  color: white;
}

.input-section {
  margin-bottom: 20px;
  display: flex;
  gap: 10px;
  align-items: flex-start;
}

.text-input {
  width: 100%;
  padding: 10px;
  font-size: 16px;
  background-color: #2c3e50;
  color: white;
  border: 1px solid #3e5972;
  border-radius: 4px;
}

.compress-btn {
  padding: 10px 20px;
  background-color: #42b983;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
}

.compress-btn:hover {
  background-color: #3aa876;
}

.results-container {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 20px;
  margin-bottom: 30px;
}

.stats-container, .codes-container {
  background-color: #2c3e50;
  padding: 15px;
  border-radius: 5px;
}

.codes-table {
  width: 100%;
  border-collapse: collapse;
}

.codes-table th, .codes-table td {
  padding: 8px 12px;
  text-align: left;
  border-bottom: 1px solid #3e5972;
}

.code {
  font-family: monospace;
  letter-spacing: 1px;
}

.tree-container {
  width: 100%;
  height: 500px;
  background-color: #2c3e50;
  border-radius: 5px;
  margin-top: 20px;
}
</style>