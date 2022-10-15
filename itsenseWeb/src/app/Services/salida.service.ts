import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SalidaService {

  constructor(private http: HttpClient) { }

  Get(): Observable<any[]> {
    return this.http.get<any[]>(environment.urlService + "Salidas");
  }
  Create(e: any): Observable<boolean> {
    return this.http.post<boolean>(environment.urlService + "Salidas", e);
  }
  Update(e: any): Observable<boolean> {
    return this.http.put<boolean>(environment.urlService + "Salidas", e);
  }
  Delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(environment.urlService + "Salidas/" + id);
  }
}
