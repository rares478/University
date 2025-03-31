<script setup>
import { ref, onMounted } from 'vue';

const users = ref([]);

const fetchUsers = async () => {
  try {
    const response = await fetch('http://localhost:3000/users');
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    users.value = await response.json();
  } catch (error) {
    console.error('Error fetching users:', error);
  }
};

onMounted(fetchUsers);
</script>

<template>
  <div>
    <ul class="user-list">
      <li v-for="(user, index) in users" :key="index">
        <div class="user-row">
          <div class="user-name"><b>{{ user.name }}</b></div>
          <div class="user-city"><i>{{ user.city }}</i></div>
        </div>
      </li>
    </ul>
  </div>
</template>

<style scoped>
.user-list {
  list-style-type: none;
  padding: 0;
}

.user-row {
  display: flex;
  justify-content: space-between;
  padding: 10px;
  border-bottom: 1px solid #ccc;
}

.user-name {
  font-weight: bold;
}

.user-city {
  font-style: italic;
}
</style>