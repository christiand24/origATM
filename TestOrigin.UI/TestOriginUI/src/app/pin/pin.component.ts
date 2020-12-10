import { Sessions } from './../commons/sistema/sessions';
import { ValidacionTarjeta } from './../commons/entities/validacionTarjeta';
import { Component, OnInit } from '@angular/core';
import { TarjetaService } from '../services/tarjeta.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pin',
  templateUrl: './pin.component.html',
  styleUrls: ['./pin.component.css']
})
export class PINComponent implements OnInit {
  numeroSeleccionadoView: string = "";
  resultado: ValidacionTarjeta;

  constructor(private srvTj: TarjetaService, private router: Router) { }

  ngOnInit(): void {
  }

  numeroBorrado($event)
  {
    this.numeroSeleccionadoView = "";
  }

  numeroAceptado($event)
  {
    this.srvTj.validarPIN(Sessions.numeroTarjeta, $event).subscribe(result =>{
      if (result >= 0)
      {
        Sessions.tarjetaId = result;
        this.router.navigate(['operaciones']);
      }
      else if (result == -1)
        this.router.navigate(['errores', "PIN incorrecto"]);
      else if (result == -2)
        this.router.navigate(['errores', "Tarjeta bloqueada"]);
    });
  }

  tecladoEvent($event)
  {
    this.numeroSeleccionadoView = $event;
  }


}
