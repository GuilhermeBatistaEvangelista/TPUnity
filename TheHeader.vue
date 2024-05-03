<template>
    <header>
      <nav >
        <RouterLink to="/"><button>Home</button></RouterLink>
        <RouterLink to="/login"><button>Login</button></RouterLink>
      </nav>
    </header>
</template>

<style scoped>
header {
  line-height: 1.5;
  height: 10vh;
  background-color: aquamarine;
  place-content: end;
}
nav{
  height: 75%;
  width: 15%;
  margin-left: 85%;
}
button{
  height: 80%;
  width: 40%;
  align-content: center;
  background-color: rgb(187, 248, 228);
  border-color:  rgb(62, 216, 165);
  border-radius: 10%;
  margin-right: 4px;
}
</style>