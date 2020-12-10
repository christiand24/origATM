import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { constUrls } from '../commons/sistema/constUrls';

@Injectable({
  providedIn: 'root'
})
export class OperacionesService {

  private baseURL = constUrls.BASE_URL + 'Operacion/';

  constructor(private http: HttpClient) { }

  insertarBalance(tarjetId: number): Observable<boolean>
  {
    let filter = new HttpParams();
    filter = filter.append('tarjetId', tarjetId.toString());
    return this.http.post<boolean>(this.baseURL + 'Balance/Insertar', null, { params : filter });
  }

  insertarRetiro(tarjetId: number, cantidadRetirada: number): Observable<boolean>
  {
    let filter = new HttpParams();
    filter = filter.append('tarjetId', tarjetId.toString());
    filter = filter.append('cantidadRetirada', cantidadRetirada.toString());
    return this.http.post<boolean>(this.baseURL + 'Retiro/Insertar', null, { params : filter });
  }
}
