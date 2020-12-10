import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-errores',
  templateUrl: './errores.component.html',
  styleUrls: ['./errores.component.css']
})
export class ErroresComponent implements OnInit {
  mensajeError = "";
  constructor(private actRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.actRoute.paramMap.subscribe(params => {
      this.mensajeError = params.get("mensaje")
    });
  }

  volver(){
    window.history.back();
  }

}
