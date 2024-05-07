<template>

    <p class="text-center">Lista de espaços card/ datatable</p>
    
    <p class="text-center" v-if="time" >DATA:{{ time }} <br>
        Ano:{{time.getYear()}} Mes:{{time.getMonth()}} Dia:{{time.getDate()}}<br>
        agora:{{Date()}}</p>
    
    <div class="card flex text-center">
        <Calendar class="bg-slate-200 text-black m-auto rounded-lg" view="date" v-model="time" inline :minDate="new Date()" >
        </calendar>
    </div>

    <div class="card flex justify-content-center ">
        <div class="card flex justify-center m-auto">
            <Button class="text-center" label="Agendar " raised v-if="time" @click="visible = true" />
        </div>
        
        <Dialog class="w-1/5 rounded bg-rose-100 text-black dark:bg-zinc-400 dark:text-white" v-model:visible="visible" modal header="Agendar" :pt="{
            root: 'border-none',
            mask: { style: 'background:rgba(0, 0, 0, 0.05); backdrop-filter: blur(1px)' }}">
            <template #container="{ closeCallback } ">
                <div class="flex-auto text-center">
                    <label for="calendar-timeonly" class="font-bold block"> Selecione o Horário: </label>
                    <Calendar panelClass="bg-slate-200 text-black " inputClass="w-full mb-2" id="calendar-timeonly" v-model="time" timeOnly :stepMinute="30"/>
                </div>
                <div class="flex align-items-center gap-3">
                    <Button label="Cancel" @click="closeCallback(); time.setHours(0); time.setMinutes(0)" text
                        class="p-3 w-full border-1 border-white-alpha-30 hover:bg-white-alpha-10"></Button>
                    <Button label="Sign-In" @click="closeCallback" text
                        class="p-3 w-full border-1 border-white-alpha-30 hover:bg-white-alpha-10"></Button>
                </div>
            </template>
        </Dialog>

    </div>



    <RouterLink to="/dashboard/agendar">
        <button class="mx-10">Agendar</button>
    </RouterLink>
</template>


<script setup lang="ts">
import Dialog from 'primevue/dialog';
import Button from 'primevue/button';
import Calendar from 'primevue/calendar';


import { ref } from "vue";
const visible = ref(false);
const time = ref();
const datasDesabilitadas=[new Date("2024-5-8")]//Date("year-month-date")


</script>

<style setup scoped>
button {
    background-color: rgb(115, 149, 185);
    border-color: rgb(20, 113, 194);
    border-width: 2px;
    margin-right: 4px;
    border-radius: 10%;
}

</style>
