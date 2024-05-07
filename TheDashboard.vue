<template>
    <p>nada ainda</p>
    <p>nada ainda</p>
    <p>nada ainda</p>
    <div class="card flex justify-content-center ">
        <div class="card flex justify-center">
            <Button label="agendar " raised @click="visible = true" />
        </div>
        <Dialog class="bg-rose-100 text-black dark:bg-zinc-200 dark:text-white" v-model:visible="visible" modal dismissableMask header="Agendar" :pt="{
            root: 'border-none',
            mask: { style: 'background:rgba(0, 0, 0, 0.05); backdrop-filter: blur(1px)' }
        }">
            <template #container="{ closeCallback } ">
                <div class="flex-auto text-center">
                    <label for="calendar-timeonly" class="font-bold block mb-2"> Hora: </label>
                    <Calendar id="calendar-timeonly" v-model="time" timeOnly stepMinute="30"/>
                </div>
                <div class="flex align-items-center gap-3">
                    <Button label="Cancel" @click="closeCallback" text
                        class="p-3 w-full text-primary-50 border-1 border-white-alpha-30 hover:bg-white-alpha-10"></Button>
                    <Button label="Sign-In" @click="closeCallback" text
                        class="p-3 w-full text-primary-50 border-1 border-white-alpha-30 hover:bg-white-alpha-10"></Button>
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
