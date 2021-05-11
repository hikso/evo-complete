import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DeliveriesRoutingModule } from "./configuration-routing.module";
import { NgprimeModule } from "../ngprime/ngprime.module";
import { MaterialModule } from "../material/material.module";
import { SharedModule } from "../shared/shared.module";

import { DashboardComponent } from 'src/app/dashboard/dashboard.component';
import { SecurityComponent } from 'src/app/security/security.component';
import { AuditComponent } from 'src/app/configuration/audit/audit.component';
import { AdminrolComponent } from 'src/app/configuration/roles/adminrol/adminrol.component';
import { CreateComponent } from 'src/app/configuration/roles/create/create.component';
import { UsersrolComponent } from 'src/app/configuration/roles/usersrol/usersrol.component';
import { EditComponent } from 'src/app/configuration/roles/edit/edit.component';
import { SaparticulosComponent } from 'src/app/configuration/saparticulos/saparticulos.component';

@NgModule({
  declarations: [
    DashboardComponent,
    SecurityComponent,
    AuditComponent,
    AdminrolComponent,
    CreateComponent,
    UsersrolComponent,
    EditComponent,
    SaparticulosComponent,
  ],
  imports: [
    CommonModule,
    DeliveriesRoutingModule,
    NgprimeModule,
    MaterialModule,
    SharedModule
  ]
})
export class ConfigurationModule { }
