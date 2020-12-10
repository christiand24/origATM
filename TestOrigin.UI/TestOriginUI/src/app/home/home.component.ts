import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Sessions } from '../commons/sistema/sessions';
import { TarjetaService } from '../services/tarjeta.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  numeroSeleccionadoView: string = "";

  constructor(private srvTj: TarjetaService, private router: Router) { }

  ngOnInit(): void {
  }

  numeroBorrado($event)
  {
    this.numeroSeleccionadoView = "";
  }

  numeroAceptado($event)
  {
    let nroTj: string = $event;
    nroTj = nroTj.substr(0,16);
    //nroTj = "5645645646234323"; //test
    this.srvTj.validar(nroTj).subscribe(result =>{
      if (result.codigo == 0){
        Sessions.numeroTarjeta = nroTj;
        this.router.navigate(['PIN']);
      }else{
        this.router.navigate(['errores', result.mensaje]);
      }
    });

  }

  tecladoEvent($event)
  {
    if ($event != null && $event.length <= 16)
    this.numeroSeleccionadoView = this.formatTjNumber($event);
  }

  /*Agrega guiones al numero*/
  formatTjNumber(tjNumero: string): string
  {
    let result = "";
    for (let i = 0 ; i < tjNumero.length; i++) {
      if ((i+1) % 4 == 0)
      {
        if (i+1 == tjNumero.length)
          result += tjNumero.substr(i, 1);
        else
          result += tjNumero.substr(i, 1) + '-';
      }
      else
      {
        result += tjNumero.substr(i, 1);
      }
    }
    return result;
  }
}
