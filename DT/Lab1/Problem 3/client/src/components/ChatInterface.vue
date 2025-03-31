<script setup>
import { ref, onMounted } from 'vue';
import io from 'socket.io-client';

const socket = io('http://localhost:8000');
const messages = ref([]);
const newMessage = ref('');
const username = ref('');
const showUsernameModal = ref(true);
const connectedUsers = ref([]);
const userColor = ref(getRandomColor());

function getRandomColor() {
  const letters = '0123456789ABCDEF';
  let color = '#';
  for (let i = 0; i < 6; i++) {
    color += letters[Math.floor(Math.random() * 16)];
  }
  return color;
}

const setUsername = () => {
  if (username.value.trim() !== '') {
    showUsernameModal.value = false;
    socket.emit('user-connected', {
      username: username.value,
      color: userColor.value
    });
  }
};

const sendMessage = () => {
  if (newMessage.value.trim() !== '') {
    const message = newMessage.value;
    socket.emit('message-from-client', {
      text: message,
      username: username.value,
      color: userColor.value
    });
    messages.value.push({
      text: message,
      sender: 'You',
      color: userColor.value,
      self: true
    });
    newMessage.value = '';
  }
};

// Socket event handlers
socket.on('connect', () => {
  console.log('Connected to server');
});

socket.on('message-from-server', (data) => {
  console.log('Received message:', data);
  messages.value.push({
    text: data.text,
    sender: data.username,
    color: data.color,
    self: false
  });
});

socket.on('users-list', (users) => {
  connectedUsers.value = users;
});
</script>

<template>
  <div v-if="showUsernameModal" class="modal-overlay">
    <div class="username-modal">
      <h2>Enter your username</h2>
      <input
          v-model="username"
          @keyup.enter="setUsername"
          placeholder="Your username..."
          autofocus
      />
      <button @click="setUsername">Join Chat</button>
    </div>
  </div>

  <div v-else class="chat-layout">

    <div class="chat-container">
      <div class="messages">
        <div
            v-for="(message, index) in messages"
            :key="index"
            class="message"
            :class="{ 'message-self': message.self }"
        >
          <span class="sender" :style="{ color: message.color }">{{ message.sender }}:</span>
          <span class="text">{{ message.text }}</span>
        </div>
      </div>
      <div class="message-input">
        <input
            v-model="newMessage"
            @keyup.enter="sendMessage"
            placeholder="Type a message..."
            autofocus
        />
        <button @click="sendMessage">Send</button>
      </div>
    </div>

    <div class="users-panel">
      <h3>Connected Users</h3>
      <div class="users-list">
        <div
            v-for="(user, index) in connectedUsers"
            :key="index"
            class="user-item"
        >
          <span class="user-dot" :style="{ backgroundColor: user.color }"></span>
          <span>{{ user.username }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.chat-layout {
  display: flex;
  height: 100vh;
  width: 100%;
  border-radius: 0;
  overflow: hidden;
  box-shadow: none;
}

.chat-container {
  display: flex;
  flex-direction: column;
  flex: 3;
  height: 100%;
  background-color: #f9f9f9;
}

.messages {
  flex: 1;
  overflow-y: auto;
  padding: 20px;
  display: flex;
  flex-direction: column;
}

.message {
  padding: 10px 15px;
  margin-bottom: 10px;
  border-radius: 18px;
  max-width: 70%;
  background-color: #e9e9eb;
  align-self: flex-start;
}

.message-self {
  background-color: #42b983;
  color: white;
  align-self: flex-end;
}

.sender {
  font-weight: bold;
  margin-right: 5px;
}

.message-input {
  display: flex;
  padding: 15px;
  background-color: white;
  border-top: 1px solid #eaeaea;
}

.message-input input {
  padding: 12px 15px;
  border: 1px solid #ddd;
  border-radius: 24px;
  margin-right: 10px;
  flex: 1;
  font-size: 16px;
}

.message-input button {
  padding: 0 20px;
  border: none;
  background-color: #42b983;
  color: white;
  border-radius: 24px;
  cursor: pointer;
  font-size: 16px;
}

/* Users Panel */
.users-panel {
  flex: 1;
  padding: 15px;
  background-color: white;
  border-left: 1px solid #eaeaea;
  overflow-y: auto;
}

.users-panel h3 {
  margin-top: 0;
  padding-bottom: 10px;
  border-bottom: 1px solid #eaeaea;
}

.users-list {
  display: flex;
  flex-direction: column;
}

.user-item {
  display: flex;
  align-items: center;
  padding: 10px 5px;
  border-bottom: 1px solid #f5f5f5;
}

.user-dot {
  width: 10px;
  height: 10px;
  border-radius: 50%;
  margin-right: 8px;
}

/* Username Modal */
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.username-modal {
  background-color: white;
  padding: 30px;
  border-radius: 8px;
  width: 320px;
  text-align: center;
}

.username-modal h2 {
  margin-top: 0;
  margin-bottom: 20px;
}

.username-modal input {
  width: 100%;
  padding: 12px;
  margin-bottom: 15px;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 16px;
}

.username-modal button {
  width: 100%;
  padding: 12px;
  background-color: #42b983;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
}
</style>