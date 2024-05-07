<template>
    <TheHeader />
    <div class="content bg-white text-black dark:bg-zinc-800 dark:text-white">
        <RouterView />
    </div>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
import TheHeader from './components/TheHeader.vue'


</script>

<style>
.content{
    height:90vh;
}
</style>
