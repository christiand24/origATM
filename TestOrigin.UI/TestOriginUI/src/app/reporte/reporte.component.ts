import { Component, OnInit } from '@angular/core';
import { Tarjeta } from '../commons/entities/tarjeta';
import { Sessions } from '../commons/sistema/sessions';
import { TarjetaService } from '../services/tarjeta.service';

@Component({
  selector: 'app-reporte',
  templateUrl: './reporte.component.html',
  styleUrls: ['./reporte.component.css']
})
export class ReporteComponent implements OnInit {
  tarjeta: Tarjeta = new Tarjeta('', new Date(), 0);
  fechahora = new Date();

  constructor(private tjSrv: TarjetaService) { }

  ngOnInit(): void {
    this.tjSrv.traer(Sessions.tarjetaId).subscribe(result => this.tarjeta = result);
  }
}
