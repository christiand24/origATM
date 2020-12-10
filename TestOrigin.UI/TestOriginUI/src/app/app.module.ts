import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RouterModule, Routes } from '@angular/router';
import { TecladoComponent } from './commons/teclado/teclado.component';
import { FormsModule  } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './commons/interceptors/authInterceptor';
import { PINComponent } from './pin/pin.component';
import { OperacionesComponent } from './operaciones/operaciones.component';
import { BalanceComponent } from './balance/balance.component';
import { RetiroComponent } from './retiro/retiro.component';
import { ReporteComponent } from './reporte/reporte.component';
import { ErroresComponent } from './errores/errores.component';

const routes: Routes = [
  {path: '',  component: HomeComponent },
  {path: 'home',  component: HomeComponent },
  {path: 'teclado',  component: TecladoComponent },
  {path: 'balance',  component: BalanceComponent },
  {path: 'retiro',  component: RetiroComponent },
  {path: 'errores/:mensaje',  component: ErroresComponent },
  {path: 'reporte',  component: ReporteComponent },
  {path: 'operaciones',  component: OperacionesComponent },
  {path: 'PIN',  component: PINComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TecladoComponent,
    PINComponent,
    OperacionesComponent,
    BalanceComponent,
    RetiroComponent,
    ReporteComponent,
    ErroresComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
