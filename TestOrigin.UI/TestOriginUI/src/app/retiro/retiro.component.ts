import { OperacionesService } from './../services/operaciones.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Sessions } from '../commons/sistema/sessions';

@Component({
  selector: 'app-retiro',
  templateUrl: './retiro.component.html',
  styleUrls: ['./retiro.component.css']
})
export class RetiroComponent implements OnInit {
  numeroSeleccionadoView: string = "";

  constructor(private srvOp: OperacionesService,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  numeroBorrado($event)
  {
    this.numeroSeleccionadoView = "";
  }

  numeroAceptado($event)
  {
    let dinero = $event;
     this.srvOp.insertarRetiro(Sessions.tarjetaId, dinero).subscribe(result =>{
      if (result){
        this.router.navigate(['reporte']);
      }else{
        this.router.navigate(['errores', "No se pudo realizar la operacion"]);
      }
    });

  }

  tecladoEvent($event)
  {
    this.numeroSeleccionadoView = $event;
  }


}
