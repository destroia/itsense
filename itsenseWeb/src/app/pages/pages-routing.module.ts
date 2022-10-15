import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EntradaYSalidasComponent } from './entrada-ysalidas/entrada-ysalidas.component';

import { PagesComponent } from './pages.component';
import { ProductoComponent } from './producto/producto.component';

const routes: Routes = [

  { path: '', component: EntradaYSalidasComponent },
  { path: 'pro', component: ProductoComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
