import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { stringify } from 'querystring';

@Component({
  selector: 'app-teclado',
  templateUrl: './teclado.component.html',
  styleUrls: ['./teclado.component.css']
})
export class TecladoComponent implements OnInit {
  selectedNumber: string = "";

  constructor() { }
  @Output() NumeroIngresado = new EventEmitter<string>();
  @Output() NumeroAceptado = new EventEmitter<string>();
  @Output() NumeroBorrado = new EventEmitter<void>();


  ngOnInit(): void {
  }

  btnPushed(value: number)
  {
    this.selectedNumber += value.toString();
    this.NumeroIngresado.emit(this.selectedNumber);
    //console.log(this.selectedNumber);
  }

  btnAccept()
  {
    this.NumeroAceptado.emit(this.selectedNumber);
  }

  btnClear()
  {
    this.selectedNumber = "";
    this.NumeroBorrado.emit();
  }

}
