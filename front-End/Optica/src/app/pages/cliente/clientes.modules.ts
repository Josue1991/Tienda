import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule} from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';

import { SharedModule } from '../../shared/shared.module';
import { AdministrarCliente } from './components/Administrar/administrarCliente';
import { ClientesRoutingModule } from './clientes-routing.module';

@NgModule({
  declarations: [
      AdministrarCliente
  ],
  imports: [
    CommonModule,
    ClientesRoutingModule,
    MatCardModule,
    MatIconModule,
    MatMenuModule,
    MatTableModule,
    MatButtonModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatPaginatorModule,
    MatFormFieldModule,
    SharedModule
  ],
  providers: [
  ]
})
export class ClientesModule { }
