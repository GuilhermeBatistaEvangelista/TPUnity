import './assets/main.css'
import './assets/tailwinds.css'
import 'primevue/resources/themes/md-light-indigo/theme.css'
import pt_br from './utils/PrimeVueLocale-pt-br.json'

import { createApp } from 'vue'
import PrimeVue from 'primevue/config';
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

const app = createApp(App);

app.use(createPinia());
app.use(router);
app.use(PrimeVue, { locale: pt_br });
app.provide('axios', app.config.globalProperties.axios)

app.mount('#app')
