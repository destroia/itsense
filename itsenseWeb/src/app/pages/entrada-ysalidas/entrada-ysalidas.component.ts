import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EntradaService } from '../../Services/entrada.service';
import { ProductoService } from '../../Services/producto.service';
import { SalidaService } from '../../Services/salida.service';

@Component({
  selector: 'app-entrada-ysalidas',
  templateUrl: './entrada-ysalidas.component.html',
  styleUrls: ['./entrada-ysalidas.component.css']
})
export class EntradaYSalidasComponent implements OnInit {

  constructor(private fb: FormBuilder, private servicesSalida: SalidaService,
    private serviceEntrda: EntradaService, private servicesPro: ProductoService,
    private router: Router) { }
  formulario: FormGroup;
  Salidas: any[] = [];
  Entradas: any[] = [];
  IsEntrada: boolean = false;
  IsSalida: boolean = false;
  showCreate: boolean = false;
  Productos: any[] = [];
  str: string = "";
  titulo: string = "";
  ngOnInit(): void {
    this.InitForm();
    this.LoadInfo();
    this.loadList();
  }
  InitForm() {

    this.formulario = this.fb.group(
      {

        productoId: [0, Validators.required],
        count: [0, Validators.compose( [ Validators.required, Validators.min(1)])],
         
      });
  }
  Save() {
    console.log(this.formulario.controls["productoId"].value)
    this.servicesPro.GetById(this.formulario.controls["productoId"].value)
      .subscribe(x => this.ConfirGetByIdPro(x), err => console.log(err))
  }
  ConfirGetByIdPro(x: any): void {
    console.log(x.cantOptimo)
    if (this.IsSalida) {
      if (x.cantOptimo >= this.formulario.controls["count"].value) {
        x.cantOptimo -= Number(this.formulario.controls["count"].value);

        
      } else {
        this.str = "La cantidad del producto no es suficiente ";
        return;
      }
    }

    if (this.IsEntrada) {
      x.cantOptimo += Number(this.formulario.controls["count"].value);
    }
    this.servicesPro.Update(x).subscribe(x => this.ConfirmUpdatePro(x), err => console.log(err))
  }
    ConfirmUpdatePro(x: boolean): void {
      let es: any = {
        id : 0 ,
        productoId : this.formulario.controls["productoId"].value,
        count: this.formulario.controls["count"].value,
        date: new Date()
      }
      if (this.IsEntrada) {

        this.serviceEntrda.Create(es).subscribe(x => this.ConfirmCreateES(es), err => console.log(err))
      }
      if (this.IsSalida) {
        this.servicesSalida.Create(es).subscribe(x => this.ConfirmCreateES(es), err => console.log(err))
      }
    }
    ConfirmCreateES(es: any): void {
      this.Close();
      this.str = "";
      this.LoadInfo();
    }
  LoadInfo()
  {
    this.serviceEntrda.Get().subscribe(x => this.ConfirmGetEntrada(x), err => console.log(err))
    this.servicesSalida.Get().subscribe(x => this.ConfirmGetSalida(x), err => console.log(err))
  }
  ConfirmGetSalida(x: any[]): void {
    this.Salidas = x;
  }
  ConfirmGetEntrada(x: any[]): void {
    this.Entradas = x;
  }
  CreateEntredaProduct() {
    this.titulo = "Crear nueva entrada";
    this.showCreate = true;
    this.IsEntrada = true;
    this.IsSalida = false;
  }
  CreateSalidaProduct() {
    this.titulo = "Crear nueva salida";
    this.showCreate = true;
    this.IsEntrada = false;
    this.IsSalida = true;
  }
  loadList() {
    this.servicesPro.Get().subscribe(x => this.ConfirmGetPro(x), err => console.log(err))
  }
  ConfirmGetPro(x: any[]): void {
    this.Productos = x;
  }
  Close() { this.showCreate = false;}
  GoToProducts() { this.router.navigate(["pro"]) }
}
