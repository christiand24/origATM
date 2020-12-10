import { Tarjeta } from './../commons/entities/tarjeta';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { constUrls } from '../commons/sistema/constUrls';
import { Observable } from 'rxjs';
import { ValidacionTarjeta } from '../commons/entities/validacionTarjeta';


@Injectable({
  providedIn: 'root'
})
export class TarjetaService {
  private baseURL = constUrls.BASE_URL + 'Tarjeta/';

  constructor(private http: HttpClient) { }

  traer(tarjetaId: number): Observable<Tarjeta>
  {
    let filter = new HttpParams();
    filter = filter.append('tarjetaId', tarjetaId.toString());
    return this.http.get<Tarjeta>(this.baseURL + 'Traer', {params: filter});
  }

  validar(numeroTarjeta: string): Observable<ValidacionTarjeta>
  {
    let filter = new HttpParams();
    filter = filter.append('numeroTarjeta', numeroTarjeta);
    return this.http.get<ValidacionTarjeta>(this.baseURL + 'EsTarjetaOperativa', {params: filter});
  }

  validarPIN(numeroTarjeta: string, PIN: number): Observable<number>
  {
    let filter = new HttpParams();
    filter = filter.append('numeroTarjeta', numeroTarjeta);
    filter = filter.append('PIN', PIN.toString());
    return this.http.get<number>(this.baseURL + 'ValidarPIN', {params: filter});
  }

}
