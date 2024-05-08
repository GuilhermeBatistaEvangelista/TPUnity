<template>
    <div class="min-h-screen flex-auto bg-white text-black dark:bg-zinc-800 dark:text-white">
        <TheHeader />
        <RouterView />
    </div>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import TheHeader from './components/TheHeader.vue'


</script>
