const { Server } = require('socket.io');
const server = new Server(8000, {
    cors: {
        origin: "*",
        methods: ["GET", "POST"]
    }
});

let connectedClients = new Map();

function getAllUsers() {
    const users = [];
    connectedClients.forEach((data, id) => {
        users.push({
            id,
            username: data.username,
            color: data.color
        });
    });
    return users;
}

function broadcastUsersList() {
    const users = getAllUsers();
    server.emit('users-list', users);
}

server.on('connection', (socket) => {
    console.info('Client connected:', socket.id);

    connectedClients.set(socket.id, {
        username: 'Anonymous',
        color: '#000000'
    });

    socket.on('user-connected', (userData) => {
        console.log('User identified:', socket.id, userData.username);
        connectedClients.set(socket.id, {
            username: userData.username,
            color: userData.color
        });
        broadcastUsersList();
    });

    socket.on('disconnect', () => {
        console.info('Client disconnected:', socket.id);
        connectedClients.delete(socket.id);
        broadcastUsersList();
    });

    socket.on("message-from-client", (payload) => {
        console.log('Received message from client:', payload);
        sendMessageToAllOtherClients(socket, payload);
    });

    broadcastUsersList();
});

function sendMessageToAllOtherClients(senderSocket, payload) {
    const senderData = connectedClients.get(senderSocket.id);

    const messageData = {
        text: payload.text,
        username: senderData ? senderData.username : 'Anonymous',
        color: senderData ? senderData.color : '#000000'
    };

    for (const [clientId, clientSocket] of connectedClients.entries()) {
        if (clientId !== senderSocket.id) {
            console.log('Sending message to client:', clientId);
            server.to(clientId).emit("message-from-server", messageData);
        }
    }
}