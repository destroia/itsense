import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private http: HttpClient) { }

  Get(): Observable<any[]> {
    return this.http.get<any[]>(environment.urlService + "Productos");
  }
  GetById(id:number): Observable<any> {
    return this.http.get<any>(environment.urlService + "Productos/" + id);
  }
  Create(p : any): Observable<boolean> {
    return this.http.post<boolean>(environment.urlService + "Productos", p);
  }
  Update(p: any): Observable<boolean> {
    return this.http.put<boolean>(environment.urlService + "Productos", p);
  }
}
