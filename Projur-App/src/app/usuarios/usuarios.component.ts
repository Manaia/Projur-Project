import { Component, OnInit, TemplateRef } from '@angular/core';
import { UsuarioService } from '../_services/usuario/usuario.service';
import { Usuario } from '../_models/Usuario';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Escolaridade } from '../_models/Escolaridade';
import { EscolaridadeService } from '../_services/escolaridade/escolaridade.service';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css'],
  providers: [UsuarioService, EscolaridadeService]
})
export class UsuariosComponent implements OnInit {
  usuariosFiltrados: Usuario[];
  usuarios: Usuario[];
  escolaridades: Escolaridade[];

  usuario: Usuario;
  modoSalvar = 'post';
  registerForm: FormGroup;
  bodyDeletarUsuario = '';

  _filtroLista: string;

  constructor(
      private usuarioService: UsuarioService,
      private escolaridadeService: EscolaridadeService,
      private modalService: BsModalService,
      private fb: FormBuilder,
      private localeService: BsLocaleService
  ) {
    this.localeService.use('pt-br');
  }

  get filtroLista(): string{
    return this._filtroLista
  }

  set filtroLista(value: string){
    this._filtroLista = value;
    this.usuariosFiltrados = this.filtroLista ? this.filtrarUsuarios(this.filtroLista) : this.usuarios;
  }

  ngOnInit() {
    this.validation();
    this.getUsuarios();
    this.getEscolaridades();
  }

  openModal(template: any){
    this.registerForm.reset();
    template.show();
  }

  validation() {
    this.registerForm = this.fb.group({
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      dtNascimento: ['', Validators.required],
      escolaridadeId: ['', Validators.required],
    });
  }

  novoUsuario(template: any){
    this.modoSalvar = 'post';
    this.openModal(template);
  }

  editarUsuario(usuario: Usuario, template: any){
    console.log(usuario);
    this.modoSalvar = 'put';
    this.openModal(template);
    this.usuario = usuario;
    const parseData = new Date(Date.parse(this.usuario.dtNascimento.toLocaleString()));
    this.usuario.dtNascimento = parseData;
    this.registerForm.patchValue(usuario);
  }

  salvarAlteracao(template: any) {
    if(this.registerForm.valid){
      if(this.modoSalvar === 'post'){
        this.usuario = Object.assign({}, this.registerForm.value);
        this.usuarioService.postUsuario(this.usuario).subscribe(
          (res: any) => {
            template.hide();
            this.getUsuarios();
          }, error => console.error(error)
        );
      }else{
        this.usuario = Object.assign({usuarioId: this.usuario.usuarioId}, this.registerForm.value);
        this.usuarioService.putUsuario(this.usuario).subscribe(
          (res: any) => {
            template.hide();
            this.getUsuarios();
          }, error => console.error(error)
        );
      }
    }
  }

  excluirUsuario(usuario: Usuario, template: any) {
    this.openModal(template);
    this.usuario = usuario;
    this.bodyDeletarUsuario = `Tem certeza que deseja excluir o Usuario: ${usuario.nome}, Código: ${usuario.usuarioId}`;
  }

  confirmeDelete(template: any) {
    this.usuarioService.deleteUsuario(this.usuario.usuarioId).subscribe(
      (res: any) => {
          console.log(res);
          template.hide();
          this.getUsuarios();
        }, error => {
          console.error(error);
        }
    );
  }
  

  filtrarUsuarios(filtraPor: string): Usuario[] {
    filtraPor = filtraPor.toLocaleLowerCase();
    return this.usuarios.filter(
      usuario => usuario.nome.toLocaleLowerCase().indexOf(filtraPor) !== -1
    );
  }

  getUsuarios(){
    this.usuarioService.getAll().subscribe((_usuarios: Usuario[]) => {
      this.usuarios = _usuarios;
      this.usuariosFiltrados = this.usuarios;
    }, error => {
      console.error(error);
    });
  }

  getEscolaridades(){
    this.escolaridadeService.getAll().subscribe((_escolaridades: Escolaridade[]) => {
      this.escolaridades = _escolaridades;
    }, error => {
      console.error(error);
    });
  }
}
