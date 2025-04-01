class ShannonFanoNode {
    constructor(char, freq) {
        this.char = char;
        this.freq = freq;
        this.code = '';
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

function buildShannonFanoTree(nodes) {
    if (nodes.length <= 1) return;

    nodes.sort((a, b) => b.freq - a.freq);

    const totalFreq = nodes.reduce((sum, node) => sum + node.freq, 0);
    let bestDiff = Infinity;
    let middleIndex = 0;

    let currentSum = 0;

    for (let i = 0; i < nodes.length - 1; i++) {
        currentSum += nodes[i].freq;
        const diff = Math.abs((2 * currentSum) - totalFreq);

        if (diff < bestDiff) {
            bestDiff = diff;
            middleIndex = i + 1;
        }
    }

    const leftNodes = nodes.slice(0, middleIndex);
    const rightNodes = nodes.slice(middleIndex);

    leftNodes.forEach(node => node.code += '0');
    rightNodes.forEach(node => node.code += '1');

    if (leftNodes.length > 1) buildShannonFanoTree(leftNodes);
    if (rightNodes.length > 1) buildShannonFanoTree(rightNodes);
}

function generateShannonFanoCodes(frequencies) {
    const nodes = Object.keys(frequencies).map(
        char => new ShannonFanoNode(char, frequencies[char])
    );

    nodes.sort((a, b) => b.freq - a.freq);

    buildShannonFanoTree(nodes);

    const codes = {};
    nodes.forEach(node => {
        codes[node.char] = node.code;
    });

    return { codes, nodes };
}

function constructTree(nodes) {
    if (nodes.length === 0) return null;

    const root = new ShannonFanoNode(null,
        nodes.reduce((sum, node) => sum + node.freq, 0));

    const leftNodes = nodes.filter(node => node.code.startsWith('0'));
    const rightNodes = nodes.filter(node => node.code.startsWith('1'));

    if (leftNodes.length > 0) {
        const leftFreq = leftNodes.reduce((sum, node) => sum + node.freq, 0);
        if (leftNodes.length === 1) {
            root.left = leftNodes[0];
        } else {
            root.left = new ShannonFanoNode(null, leftFreq);
            buildSubtree(root.left, leftNodes, 1);
        }
    }

    if (rightNodes.length > 0) {
        const rightFreq = rightNodes.reduce((sum, node) => sum + node.freq, 0);
        if (rightNodes.length === 1) {
            root.right = rightNodes[0];
        } else {
            root.right = new ShannonFanoNode(null, rightFreq);
            buildSubtree(root.right, rightNodes, 1);
        }
    }

    return root;
}

function buildSubtree(parent, nodes, depth) {
    const leftNodes = nodes.filter(n => n.code.length > depth && n.code[depth] === '0');
    const rightNodes = nodes.filter(n => n.code.length > depth && n.code[depth] === '1');
    const currentNodes = nodes.filter(n => n.code.length === depth);

    for (const node of currentNodes) {
        if (node.code[depth-1] === '0') {
            parent.left = node;
        } else {
            parent.right = node;
        }
    }

    if (leftNodes.length > 0) {
        const leftFreq = leftNodes.reduce((sum, n) => sum + n.freq, 0);
        if (leftNodes.length === 1) {
            parent.left = leftNodes[0];
        } else {
            parent.left = new ShannonFanoNode(null, leftFreq);
            buildSubtree(parent.left, leftNodes, depth + 1);
        }
    }

    if (rightNodes.length > 0) {
        const rightFreq = rightNodes.reduce((sum, n) => sum + n.freq, 0);
        if (rightNodes.length === 1) {
            parent.right = rightNodes[0];
        } else {
            parent.right = new ShannonFanoNode(null, rightFreq);
            buildSubtree(parent.right, rightNodes, depth + 1);
        }
    }
}

function encode(data) {
    if (!data || data.length === 0) {
        return { encodedData: '', tree: null, codes: {} };
    }

    const frequencies = countFrequencies(data);
    const { codes, nodes } = generateShannonFanoCodes(frequencies);
    const tree = constructTree(nodes);

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
    ShannonFanoNode
};