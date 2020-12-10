import { Sessions } from './../commons/sistema/sessions';
import { TarjetaService } from './../services/tarjeta.service';
import { Component, OnInit } from '@angular/core';
import { Tarjeta } from '../commons/entities/tarjeta';
import { OperacionesService } from '../services/operaciones.service';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent implements OnInit {
  tarjeta: Tarjeta = new Tarjeta('', new Date(), 0);

  constructor(private tjSrv: TarjetaService,
    private srvOp: OperacionesService) { }

  ngOnInit(): void {
    this.tjSrv.traer(Sessions.tarjetaId).subscribe(result => this.tarjeta = result);
    this.srvOp.insertarBalance(Sessions.tarjetaId).subscribe(result => {});
  }



}
