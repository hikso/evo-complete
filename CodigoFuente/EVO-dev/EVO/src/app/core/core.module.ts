import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuditService } from './services/audit.service';
import { CarsService } from './services/cars.service';
import { IntegracionService } from './services/integracion.service';
import { PedidosService } from './services/pedidos.service';
import { RolesService } from './services/roles.service';
import { SettingService } from './services/setting.service';
import { UsersService } from './services/users.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    AuditService,
    CarsService,
    IntegracionService,
    PedidosService,
    RolesService,
    SettingService,
    UsersService
  ]
})
export class CoreModule { }
