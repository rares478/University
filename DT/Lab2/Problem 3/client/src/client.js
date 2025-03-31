import io from 'socket.io-client';
const socket = io('http://localhost:8000');

try {
    socket.on('connect', function() {
        console.log('Connected to server');
        socket.emit("message-from-client", "Hello from " + checkBrowser());
    });

    socket.on('message-from-server', function(message) {
        console.log('Received message from server:', message);
    });
} catch (err) {
    alert('Error: ' + err);
}

function checkBrowser() {
    var browser = "Unknown";
    if (navigator.userAgent.indexOf('Chrome') > -1) {
        browser = "Chrome";
    } else if (navigator.userAgent.indexOf('Firefox') > -1) {
        browser = "Firefox";
    } else if (navigator.userAgent.indexOf('Safari') > -1) {
        browser = "Safari";
    } else if (navigator.userAgent.indexOf('Opera') > -1) {
        browser = "Opera";
    } else if (navigator.userAgent.indexOf('MSIE') > -1 || navigator.userAgent.indexOf('Trident') > -1) {
        browser = "Internet Explorer";
    }
    return browser;
}

document.getElementById("send").addEventListener("click", sendMessage);
function sendMessage() {
    var message = document.getElementById("message").value;
    console.log('Sending message to server:', message);
    socket.emit('message-from-client', message);
}