var api = require('./api.js').app;
var hamming = require('./hamming.js');

api.put('/message', function(request, response) {
    var bits = request.body.bits;
    var distortedBits = distortBit([...bits]);

    var decoded = hamming.decode(distortedBits);
    if (decoded.errorCorrected) {
        return response.json({
            message: 'One error corrected on position: ' + decoded.errorPosition,
            distorted: distortedBits,
            corrected: decoded.bits
        });
    }
    return response.json({
        message: 'Message received without errors',
        distorted: distortedBits,
        corrected: decoded.bits
    });
});

api.listen(3000, function() {
    console.log('CORS-enabled web server is listening on port 3000...');
});

function distortBit(bits) {
    const index = Math.floor(Math.random() * bits.length);
    bits[index] = (bits[index] + 1) % 2;
    return bits;
}