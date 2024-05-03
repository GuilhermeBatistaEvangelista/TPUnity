<template>
   <div class="login mx-auto">
      <p>Nome: </p>
      <input placeholder="Nome de Usuario">
      <p>Senha:</p>
      <input placeholder="Senha">
      <p class>
         <RouterLink to="/dashboard"><button class="mx-10">Confirmar</button></RouterLink>
      </p>
   </div>
</template>

<script setup lang="ts">


</script>

<style scoped>
.login {
   place-content: center;
   width: 20%;
   margin: auto;
   background-color: aliceblue;
   border-style: solid;
   border-color: rgb(188, 217, 243);
   border-width: 2px;
   border-bottom-left-radius: 1%;
   border-bottom-right-radius: 1%
}

p {
   color: black;
}

button {
   height: 80%;
   width: 40%;
   background-color: aliceblue;
   border-color: rgb(188, 217, 243);
   margin-right: 4px;
   border-radius: 10%;
}
</style>