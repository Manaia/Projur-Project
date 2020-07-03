import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Escolaridade } from '../../_models/Escolaridade';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EscolaridadeService {
  baseURL = 'https://localhost:5001/api/escolaridade';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Escolaridade[]>{
    return this.http.get<Escolaridade[]>(this.baseURL);
  }
}