<template>
   <div class="agendamento bg-rose-100 dark:bg-zinc-400 dark:text-white">
    <p>Agendamentos aqui</p>
    <p>Agendamentos aqui</p>
    <p>Agendamentos aqui</p>
    <p>Agendamentos aqui</p>
    <a @click="$router.go(-1)">
        <button class="mx-10">Cancelar</button>
    </a>
    </div>
</template>

<style>
.agendamento{
    width: 30%;
    height: 50%;
    /*background-color: antiquewhite;*/
    position: absolute;
    top: 25%; left: 35%;
    align-content: center;
    text-align: center;
    border-width: 2px;
    border-color: grey;
    border-radius: 5%;
}
</style>
