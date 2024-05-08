import api from "./api";
import type { APIResponse } from "./types";

type Agendamento = {
  id: number;
  title: string;
  url: string;
};

async function getAgendamentos() {
  try {
    const response = await api.get();
    //const response = await api.get("1",{query:'url:"${data.url}"'});
    //const response = await api.get<APIResponse<Agendamento>>('2');
    /*const response: AxiosResponse<Agendamento[]> = await api.get("1");
    const temp: Agendamento = response.data
    console.log(temp);*/
    console.log(response.data);
    return response.data.slice(1,10)

  } catch (error) {
    console.error(error);
  }
}
async function getAgendamento(id: string) {
  try {
    const response = await api.get(id);
    console.log(response);
    return response.data

  } catch (error) {
    console.error(error);
  }
}

export default {
  getAgendamentos,
  getAgendamento,
};
