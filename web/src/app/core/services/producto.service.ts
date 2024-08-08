import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { producto } from '../../shared/entity/producto';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  private apiUrl = 'https://localhost:7047/api';

  constructor(private http: HttpClient) { }

  listarProducto(id: string, nombre: string): Observable<producto[]> {
    const url = `${this.apiUrl}/producto?id=${id}&nombre=${nombre}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.get<any>(url, { headers });
  }

  guardarProducto(item: producto): Observable<producto[]> {
    const url = `${this.apiUrl}/producto`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(url, item, { headers });
  }
}
