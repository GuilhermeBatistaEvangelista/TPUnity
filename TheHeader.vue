<template>
  <header>
    <nav>
      <darkMode />
      <RouterLink to="/"><button>Home</button></RouterLink>
      <RouterLink to="/login"><button>Login</button></RouterLink>
    </nav>
  </header>
</template>

<script setup lang="ts">
import darkMode from '../components/darkMode.vue';
</script>

<style setup scoped>
header {
  line-height: 1.5;
  height: 10vh;
  background-color: #436D87;
  place-content: center;
}

nav {
  height: 75%;
  width: 15%;
  margin-left: 85%;
}

button {
  height: 80%;
  min-height: 16px;
  width: 30%;
  align-content: center;
  background-color: rgb(187, 248, 228);
  border-radius: 10%;
  margin-right: 4px;
  font-size:3vh;
}
</style>
