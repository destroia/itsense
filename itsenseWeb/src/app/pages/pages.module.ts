import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { PagesComponent } from './pages.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EntradaYSalidasComponent } from './entrada-ysalidas/entrada-ysalidas.component';
import { ProductoComponent } from './producto/producto.component';


@NgModule({
  declarations: [PagesComponent, EntradaYSalidasComponent, ProductoComponent],
  imports: [
    CommonModule,
    PagesRoutingModule,
    ReactiveFormsModule,
    FormsModule,
  ]
})
export class PagesModule { }
