class HuffmanNode {
    constructor(char, freq) {
        this.char = char;
        this.freq = freq;
        this.left = null;
        this.right = null;
    }

    isLeaf() {
        return this.left === null && this.right === null;
    }
}

function countFrequencies(data) {
    const frequencies = {};
    for (let i = 0; i < data.length; i++) {
        const char = data[i];
        frequencies[char] = (frequencies[char] || 0) + 1;
    }
    return frequencies;
}

function buildHuffmanTree(frequencies) {
    const queue = Object.keys(frequencies).map(
        char => new HuffmanNode(char, frequencies[char])
    );

    queue.sort((a, b) => a.freq - b.freq);

    while (queue.length > 1) {
        const left = queue.shift();
        const right = queue.shift();

        const parent = new HuffmanNode(null, left.freq + right.freq);
        parent.left = left;
        parent.right = right;

        let i = 0;
        while (i < queue.length && queue[i].freq < parent.freq) {
            i++;
        }
        queue.splice(i, 0, parent);
    }

    return queue[0] || new HuffmanNode('', 0);
}

function generateCodes(root) {
    const codes = {};

    function traverse(node, code) {
        if (!node) return;

        if (node.isLeaf()) {
            codes[node.char] = code.length > 0 ? code : '0'; // Handle single character case
            return;
        }

        traverse(node.left, code + '0');
        traverse(node.right, code + '1');
    }

    traverse(root, '');
    return codes;
}

function encode(data) {
    if (!data || data.length === 0) {
        return { encodedData: '', tree: null, codes: {} };
    }

    const frequencies = countFrequencies(data);
    const tree = buildHuffmanTree(frequencies);
    const codes = generateCodes(tree);

    let encodedData = '';
    for (let i = 0; i < data.length; i++) {
        encodedData += codes[data[i]];
    }

    return { encodedData, tree, codes };
}

function getCompressionStats(originalData, encodedData) {
    const originalBits = originalData.length * 8;
    const compressedBits = encodedData.length;

    return {
        originalSize: originalBits,
        compressedSize: compressedBits,
        compressionRatio: originalBits / compressedBits,
        spaceSavings: ((originalBits - compressedBits) / originalBits * 100).toFixed(2) + '%'
    };
}

export {
    encode,
    getCompressionStats,
    HuffmanNode
};