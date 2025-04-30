export function getManchesterLevelEncoding(bits) {
    var result = [];
    for (var i = 0; i < bits.length; i++) {
        let symbol = '|--|--|';
        if (parseInt(bits[i].value) === 1) symbol = '|__|--|';
        if (parseInt(bits[i].value) === 1 && i > 0 &&
            parseInt(bits[i- 1].value) === 1) symbol = '|__|--|';
        if (parseInt(bits[i].value) === 0) symbol = '|--|__|';
        if (parseInt(bits[i].value) === 0 && i > 0 &&
            parseInt(bits[i- 1].value) === 0) symbol = '|--|__|';
        result.push(symbol);
    }
    return result;
}

export function getAMIEncoding(bits) {
    let result = [];
    let polarity = 1; // Start with positive polarity

    for (let i = 0; i < bits.length; i++) {
        const bit = parseInt(bits[i].value);
        if (bit === 0) {
            result.push('|_____|');
        } else {
            // For 1, alternate between positive and negative voltage
            if (polarity === 1) {
                result.push('|/¯¯¯\\|');
            } else {
                result.push('|\\___/|');
            }
            polarity *= -1; // Switch polarity for next '1'
        }
    }
    return result;
}

export function getMLT3Encoding(bits) {
    let result = [];
    // MLT-3 states: 0, +V, 0, -V in sequence
    let states = [0, 1, 0, -1];
    let currentStateIndex = 0;

    for (let i = 0; i < bits.length; i++) {
        const bit = parseInt(bits[i].value);

        if (bit === 1) {
            // For 1, transition to next state
            currentStateIndex = (currentStateIndex + 1) % 4;
        }
        // For 0, stay at current state

        // Output symbol based on current state
        if (states[currentStateIndex] === 0) {
            result.push('|_____|');
        } else if (states[currentStateIndex] === 1) {
            result.push('|/¯¯¯\\|');
        } else {
            result.push('|\\___/|');
        }
    }
    return result;
}

export function get4B5BNRZIEncoding(bits) {
    const mapping = {
        '0000': '11110', '0001': '01001', '0010': '10100', '0011': '10101',
        '0100': '01010', '0101': '01011', '0110': '01110', '0111': '01111',
        '1000': '10010', '1001': '10011', '1010': '10110', '1011': '10111',
        '1100': '11010', '1101': '11011', '1110': '11100', '1111': '11101'
    };

    let chunks = [];
    let currentChunk = '';

    for (let i = 0; i < bits.length; i++) {
        if (bits[i].value !== null) {
            currentChunk += bits[i].value;
            if (currentChunk.length === 4) {
                chunks.push(currentChunk);
                currentChunk = '';
            }
        }
    }

    if (currentChunk.length > 0 && currentChunk.length < 4) {
        currentChunk = currentChunk.padEnd(4, '0');
        chunks.push(currentChunk);
    }

    let mappedBits = '';
    for (let chunk of chunks) {
        mappedBits += mapping[chunk] || '';
    }

    let result = [];
    let currentLevel = true;

    for (let i = 0; i < mappedBits.length; i++) {
        if (mappedBits[i] === '1') {
            currentLevel = !currentLevel;
        }

        result.push(currentLevel ? '|¯¯¯¯¯|' : '|_____|');
    }

    return result;
}

export function getDifferentialManchesterEncoding(bits) {
    let result = [];
    let currentPhase = true;

    for (let i = 0; i < bits.length; i++) {
        const bit = parseInt(bits[i].value);

        if (bit === 1) {
            if (currentPhase) {
                result.push('|¯¯\\__|');
            } else {
                result.push('|__/¯¯|');
            }
        } else {
            currentPhase = !currentPhase;
            if (currentPhase) {
                result.push('|¯¯\\__|');
            } else {
                result.push('|__/¯¯|');
            }
        }
    }
    return result;
}

export function getHDB3Encoding(bits) {
    let result = [];
    let consecutiveZeros = 0;
    let lastPolarity = 1;
    let polarityViolations = 0;

    for (let i = 0; i < bits.length; i++) {
        const bit = parseInt(bits[i].value);

        if (bit === 1) {
            if (lastPolarity === 1) {
                result.push('|/¯¯¯\\|');
                lastPolarity = -1;
            } else {
                result.push('|\\___/|');
                lastPolarity = 1;
            }
            polarityViolations++;
            consecutiveZeros = 0;
        } else { // bit === 0
            consecutiveZeros++;

            if (consecutiveZeros === 4) {
                result[result.length - 3] = (polarityViolations % 2 === 0) ?
                    (lastPolarity === 1 ? '|/¯¯¯\\|' : '|\\___/|') : // B (Bipolar)
                    '|_____|'; // 0

                const violation = (lastPolarity === 1) ? '|/¯¯¯\\|' : '|\\___/|';
                result.push(violation);

                polarityViolations += (result[result.length - 3] !== '|_____|' ? 1 : 0) + 1;
                lastPolarity = lastPolarity; // Violation doesn't change polarity
                consecutiveZeros = 0;
            } else {
                result.push('|_____|');
            }
        }
    }
    return result;
}

export function getB8ZSEncoding(bits) {
    let result = [];
    let consecutiveZeros = 0;
    let lastPolarity = 1;

    for (let i = 0; i < bits.length; i++) {
        const bit = parseInt(bits[i].value);

        if (bit === 1) {
            if (lastPolarity === 1) {
                result.push('|/¯¯¯\\|');
                lastPolarity = -1;
            } else {
                result.push('|\\___/|');
                lastPolarity = 1;
            }
            consecutiveZeros = 0;
        } else {
            consecutiveZeros++;

            if (consecutiveZeros === 8) {
                result.splice(result.length - 7, 5);

                result.push('|_____|');
                result.push('|_____|');
                result.push('|_____|');

                result.push(lastPolarity === 1 ? '|/¯¯¯\\|' : '|\\___/|');

                result.push(lastPolarity === 1 ? '|/¯¯¯\\|' : '|\\___/|');

                result.push('|_____|');

                result.push(lastPolarity === 1 ? '|/¯¯¯\\|' : '|\\___/|');

                lastPolarity = -lastPolarity;
                result.push(lastPolarity === 1 ? '|/¯¯¯\\|' : '|\\___/|');

                consecutiveZeros = 0;
            } else {
                result.push('|_____|');
            }
        }
    }
    return result;
}
