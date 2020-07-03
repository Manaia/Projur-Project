import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';

import { UsuarioService } from './_services/usuario/usuario.service';
import { EscolaridadeService } from './_services/escolaridade/escolaridade.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { NavComponent } from './nav/nav.component';

import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';

@NgModule({
   declarations: [
      AppComponent,
      UsuariosComponent,
      NavComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      BsDatepickerModule.forRoot(),
      ModalModule.forRoot(),
      TooltipModule.forRoot(),
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule
   ],
   providers: [
      UsuarioService,
      EscolaridadeService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
