import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductoService } from '../../Services/producto.service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  constructor(private fb: FormBuilder, private servicesPro: ProductoService,
    private router: Router) { }
  formulario: FormGroup;
  Productos: any[] = []
  pro: any = null;
  showCreateUpdate: boolean = false;
  ngOnInit(): void {
    this.InitForm();
    this.loadList();
  }

  InitForm() {

    this.formulario = this.fb.group(
      {

        id: [this.pro === null ? 0 : this.pro.id],
        nombre: [this.pro === null ? "" : this.pro.name, Validators.compose(
          [Validators.required,
          Validators.maxLength(200),
            Validators.minLength(4)])],
        cantidadOptimo: [this.pro === null ? 0 : this.pro.cantOptimo, Validators.required],
        cantidadDefectuoso: [this.pro === null ? 0 : this.pro.cantDefectuoso, Validators.required]

      });
  }

  Save() {
    let p: any =
    {
      id: Number(this.formulario.controls["id"].value),
      name: this.formulario.controls["nombre"].value,
      cantOptimo: Number(this.formulario.controls["cantidadOptimo"].value),
      cantDefectuoso: Number(this.formulario.controls["cantidadDefectuoso"].value)
    }

    if (p.id === 0) {

      this.servicesPro.Create(p)
        .subscribe(x => this.CreateUpdateProducto(x), err => console.log(err))
    }
    else {
      this.servicesPro.Update(p)
        .subscribe(x => this.CreateUpdateProducto(x), err => console.log(err))
    }

  }
  CreateUpdateProducto(x: boolean): void {
    this.pro = null;
    this.loadList();
    this.InitForm();
    this.showCreateUpdate = false;
  }
  loadList() {
    this.servicesPro.Get().subscribe(x => this.ConfirmGetPro(x), err => console.log(err))
  }
  ConfirmGetPro(x: any[]): void {
    this.Productos = x;
  }
  Close() {
    this.showCreateUpdate = false;
    this.pro = null;
    this.InitForm();

  }
  CreateUpdateProduct() {
    this.showCreateUpdate = true;
  }
  
  Update(li: any) {
    this.pro = li;
    this.InitForm();
    this.showCreateUpdate = true;
  }
  Defectuoso(li:any) {
    if (li.cantOptimo > 0) {
      li.cantDefectuoso += 1;
      li.cantOptimo -= 1;

      this.servicesPro.Update(li).subscribe(x => this.ConfirmUpdatePro(x), err => console.log(err))
    }
  }
    ConfirmUpdatePro(x: boolean): void {
      this.loadList();
    }
  Back() { this.router.navigate([""]) }
}
