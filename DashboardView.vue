<template>
    <TheDashboard />
    <RouterView />
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';
import TheDashboard from '../components/TheDashboard.vue';
</script>
