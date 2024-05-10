<template>

    <div class="w-fit justify-center rounded-md m-auto p-2">
        <TabMenu :model="tiposList" @tab-change="trocarTipo">
            <template #item="{ item, props, index }">
                <a v-bind="props.action" class="flex align-items-center gap-2">
                    <p>{{ item.descricao }}</p>
                </a>
            </template>
        </TabMenu>
    </div>

    <!--         Exibição/Seleção de possiveis locais     -->
    <div class="bg-gray-bg justify-center rounded-md m-2 p-2">


        <Carousel :value="tipoEspacosList" :numVisible="5" :circular="true">
            <template #header>
                <h3 class="text-center"> Espaços</h3>
            </template>
            <template #item="slotProps">
                <div class="card m-auto bg-white text-black rounded-md m-1 p-1 align-middle text-center">
                    <!--         Descrição     -->
                    <p class="m-auto">{{ slotProps.data.descricao }}(ID:{{ slotProps.data.id }})</p>
                    <!--         IMG     -->
                    <Image :src="slotProps.data.imagem_link" alt="Image" width="250" />
                    <!--         Horarios     -->
                    <p class="m-auto">Horarios: {{ slotProps.data.horario_inicial.slice(0, -3) }} -
                        {{ slotProps.data.horario_final.slice(0, -3) }}</p>
                    <p class="m-auto">Duração: {{ slotProps.data.duracao_padrao.slice(0, -3) }}</p>

                    <p v-if="time" class="m-2">IMG-{{ espacos.imageExists(slotProps.data.imagem_link) }}</p>


                    <div class="flex justify-center m-auto">
                        <Button class="text-center h-6" label="Agendar " raised
                            @click="visible = true; constructHorarios(slotProps.data.id);" />
                    </div>
                </div>
            </template>
        </Carousel>

        <div>
            <TabView :scrollable="true">
                <TabPanel v-for="(tab, index) in tipoEspacosList" :header="tab.descricao">
                    <p class="m-0">conteudo{{ tab }}</p>
                </TabPanel>
            </TabView>
        </div>


    </div>



    <!--###############-->


    <div class="flex justify-center m-auto">
        <Button class="text-center h-6" label="Agendar " raised @click="visible = true;" />
    </div>

    <!--         Dialog de agendamento         -->
    <Dialog class="w-1/5 rounded bg-gray-bg text-black dark:bg-zinc-400 dark:text-white" v-model:visible="visible" modal
        header="Agendar" :pt="{
            root: 'border-none',
            mask: { style: 'background:rgba(0, 0, 0, 0.05); backdrop-filter: blur(1px)' }
        }">
        <template #container="{ closeCallback }">
            <div class="flex-auto text-center"><!--         Horarios         -->
                <label for="calendar-timeonly" class="font-bold block"> Selecione o Horário para reserva do local:
                </label>
            </div>
            <div v-if="existeAgenda" class="flex flex-col">
                <!--         Seleção de horarios se existir agenda        -->
                <div v-for="(item, index) in horarios" class="flex m-auto">
                    <RadioButton v-model="horariosSelecionados" :disabled="index == 1" inputId="item" name="category"
                        :value="item" />
                    <label :for="item">{{ item }}</label>
                </div>
                <p>horariosSelecionados:{{ horariosSelecionados }} agenda:{{ agenda.id}}</p>
                <!--         Botões         -->
                <div class="flex align-items-center gap-3">
                    <Button label="Cancelar" @click="closeCallback(); espaco=ref();" text
                        class="p-2 w-3/4 m-1 text-black border-white-alpha-30 hover:bg-white-alpha-10"></Button>
                    <Button label="Cadastrar" @click="closeCallback()" text
                        class="p-2 w-3/4 m-1 text-black border-white-alpha-30 hover:bg-white-alpha-10"></Button>
                </div>
            </div>
            <div v-else>
                <p class="text-red">Não existe uma agenda aberta para esse local</p>
                <!--         Botão         -->
                <div>
                    <Button label="OK" @click="closeCallback(); espaco=ref();" text
                        class="p-2 w-3/4 m-1 text-black border-white-alpha-30 hover:bg-white-alpha-10"></Button>
                </div>
            </div>
            <!--######-->


        </template>
    </Dialog>
    <!--###############-->



    <p class="text-center" v-if="time">DATA:{{ time }} <br>
        agora:{{ Date() }}</p>

    <!--         Calendario         -->
    <div class="flex text-center">
        <Calendar class="bg-slate-200 text-black m-auto rounded-lg" view="date" v-model="time" inline
            :minDate="new Date()">
        </calendar>
    </div>

    <div class="flex justify-center m-auto">
        <Button class="text-center" label="Agendar " raised v-if="time" @click="visible = true" />
    </div>
    <!--###############-->

    <!--
    <RouterLink to="/dashboard/agendar">
        <button class="mx-10">Agendar</button>
    </RouterLink>
    -->
</template>




<script setup lang="ts">
//imports API
import espacos from '@/services/espacos';
import tipos from '@/services/tipos';
import agendas from '@/services/agendas';
//
//imports Components Primevue
import Carousel from 'primevue/carousel';

import TabView from 'primevue/tabview';
import TabPanel from 'primevue/tabpanel';

import VirtualScroller from 'primevue/virtualscroller';

import Image from 'primevue/image';
import Dialog from 'primevue/dialog';
import Button from 'primevue/button';
import Calendar from 'primevue/calendar';
import RadioButton from 'primevue/radiobutton';
import TabMenu from 'primevue/tabmenu';
//

import { ref } from "vue";

const visible = ref(false);
const time = ref();

const datasDesabilitadas = [new Date("2024-5-8")];//Date("year-month-date")
//const templist = [1, 3, 5, 2, 7, 11, 22, 55, 88, 99, 120];
const temp = ref();

const tiposList = ref();//Armazena uma lista de locais
const tipoEspacosList = ref();//Armazena uma lista de locais
const espacosList = ref();//Armazena uma lista de locais
const Localagendamentos = ref();//Armazena os agendamentos de um determinado local

//recebe um resultado de uma função da API
const load = async (resultado: { value: typeof ref; }, funcao: any) => {
    try {
        resultado.value = await funcao;
        console.log(`try.`)
        console.log(resultado.value)
    } catch (error) {
        // handle any error state, rejected promises, etc..
    }
};

load(tiposList, tipos.getTipos());
//console.log(`tiposlist: ${tiposList.value == null}`)
const trocarTipo = async (tab: any) => {
    console.log(tiposList.value[tab.index].id)
    await load(tipoEspacosList, tipos.getTipo(tiposList.value[tab.index].id));
}
load(tipoEspacosList, tipos.getTipo(1));
//load(espacosList, espacos.getEspacos());


const espaco = ref();//Armazena o local selecionado
const agenda = ref();//Armazena a genda selecionada
const horariosSelecionados = ref();
const horarios = ref(['']);
const existeAgenda = ref(false)
const constructHorarios = async (id: number) => {
    try {
        await load(espaco, espacos.getEspaco(id));//carrega o espaço
        //limpa as variaveis
        horariosSelecionados.value = []
        horarios.value = []
        let agendaAtiva
        if (espaco.value.agendas == 0) {//se não houver agendas cadastradas para o espaço
            existeAgenda.value = false
        } else {
            for (let i of espaco.value.agendas) {//percorre as agendas e verifica se existem alguma ativa
                if (i.ativo) {
                    existeAgenda.value = true;
                    agendaAtiva = i.id;
                }
            }
        }
        if (existeAgenda.value) {//se existe uma agenda valida
            ///////montar um array com horarios : ["hh:mm",...]
            //console.log("horarios");
            const duracao = espaco.value.duracao_padrao.split(":").map(Number)
            const inicio = espaco.value.horario_inicial.split(":").map(Number)
            const final = espaco.value.horario_final.split(":").map(Number)
            //console.log(duracao)
            //variaveis com data, usada para contagem
            let datainicio = ref()
            let datafim = ref()
            datainicio.value = new Date()
            datafim.value = new Date()
            datainicio.value.setHours(inicio[0])
            datainicio.value.setMinutes(inicio[1])
            datafim.value.setHours(final[0])
            datafim.value.setMinutes(final[1])
            do {//partindo do horario incial salva o horarios e some a duração padrão até chegar no horario final
                horarios.value.push(
                    String(datainicio.value.getHours()).padStart(2, '0') + ':' + String(datainicio.value.getMinutes()).padStart(2, '0')
                )
                datainicio.value.setTime(
                    datainicio.value.getTime() + duracao[0] * 60 * 60 * 1000 + duracao[1] * 60 * 1000
                )
            } while (datainicio.value.getTime() < datafim.value.getTime())

            ///////verificar os horarios ocupados
            await load(agenda, agendas.getAgenda(agendaAtiva));//carrega a agenda
            
        }
    } catch (error) {
        // handle any error state, rejected promises, etc..
    }
}

</script>



<style setup scoped>
button {
    background-color: rgb(115, 149, 185);
    border-color: rgb(20, 113, 194);
    border-width: 2px;
    margin-right: 4px;
    border-radius: 10%;
}

.card {
    max-width: 270px;
}
</style>
