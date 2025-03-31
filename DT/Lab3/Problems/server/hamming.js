function decode(bits) {
    const n = bits.length
    const r = Math.ceil(Math.log2(n + 1))
    let errorPosition = 0

    for (let i = 0; i < r; i++) {
        const pos = Math.pow(2, i) - 1
        let parity = 0
        for (let k = pos; k < n; k += 2 * (pos + 1)) {
            for (let l = k; l < k + pos + 1 && l < n; l++) {
                parity ^= bits[l]
            }
        }
        if (parity !== 0) {
            errorPosition += pos + 1
        }
    }

    const errorDetected = errorPosition !== 0
    if (errorDetected) {
        bits[errorPosition - 1] ^= 1
    }

    return { errorCorrected: errorDetected, errorPosition: errorPosition - 1, bits: bits }
}


exports.decode = decode