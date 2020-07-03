import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../../_models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  baseURL = 'https://localhost:5001/api/usuario';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Usuario[]>{
    return this.http.get<Usuario[]>(this.baseURL);
  }

  getUsuarioById(id: number): Observable<Usuario[]>{
    return this.http.get<Usuario[]>(`${this.baseURL}/${id}`);
  }

  postUsuario(usuario: Usuario){
    return this.http.post(this.baseURL, usuario);
  }

  putUsuario(usuario: Usuario){
    return this.http.put(`${this.baseURL}/${usuario.usuarioId}`, usuario);
  }

  deleteUsuario(id: number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
