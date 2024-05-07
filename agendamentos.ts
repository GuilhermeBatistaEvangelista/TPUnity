import http from "./api";
//import { APIResponse } from "./types";
type APIResponse<T> = {
    success: boolean
    content: T;
    status?: number;
}

type Agendamento = {
    id: number;
    name: string;
    description: string;
  };

async function getAgendamentos() {
    return await http.get<APIResponse<Agendamento[]>>("Agendamentos");
  }
  
  export default{
    getAgendamentos,
  };