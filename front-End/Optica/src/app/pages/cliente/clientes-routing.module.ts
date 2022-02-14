import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AdministrarCliente } from './components/Administrar/administrarCliente';


const routes: Routes = [
  {
    path: '',
    component: AdministrarCliente
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})

export class ClientesRoutingModule {
}
