import { Component } from '@angular/core';
import { producto } from '../../shared/entity/producto';
import { CommonModule } from '@angular/common';
import { ProductoService } from '../../core/services/producto.service';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent {
  mostrarNuevoRegistro: boolean = false;
  id: string = "";
  nombre: string = "";
  lista: producto[] = [];
  registro: producto = {};

  constructor(private productoService: ProductoService){
  }

  ngOnInit(){
    this.listarProducto();
  }

  listarProducto(){
    this.productoService.listarProducto(this.id, this.nombre)
    .subscribe(x => {
      this.lista = x;
    });
  }

  irNuevoRegistro(){
    this.mostrarNuevoRegistro = true;
  }

  buscar(){
    this.listarProducto();
  }

  guardar(){
    this.productoService.guardarProducto(this.registro)
    .subscribe(x => {
      this.mostrarNuevoRegistro = false;
      this.registro = {};
      this.buscar();
    })
  }

  regresar(){
    this.mostrarNuevoRegistro = false;
  }
}
