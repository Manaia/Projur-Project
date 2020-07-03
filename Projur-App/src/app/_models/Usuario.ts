import { Escolaridade } from './Escolaridade';

export interface Usuario {
  usuarioId: number;
  escolaridadeId: number;
  escolaridade: Escolaridade;
  nome: string;
  sobrenome: string;
  email: string;
  dtNascimento: Date;
}
