import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from 'src/app/dashboard/dashboard.component';
import { SecurityComponent } from 'src/app/security/security.component';
import { AuditComponent } from 'src/app/configuration/audit/audit.component';
import { AdminrolComponent } from 'src/app/configuration/roles/adminrol/adminrol.component';
import { CreateComponent } from 'src/app/configuration/roles/create/create.component';
import { UsersrolComponent } from 'src/app/configuration/roles/usersrol/usersrol.component';
import { EditComponent } from 'src/app/configuration/roles/edit/edit.component';
import { SaparticulosComponent } from 'src/app/configuration/saparticulos/saparticulos.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'security',
    component: SecurityComponent
  },
  {
    path: 'auditoria',
    component: AuditComponent
  },
  {
    path: 'adminrol',
    component: AdminrolComponent
  },
  {
    path: 'adminrol/create',
    component: CreateComponent
  },
  {
    path: 'adminrol/:name/:id',
    component: UsersrolComponent
  },
  {
    path: 'adminrol/edit/:name/:id',
    component: EditComponent
  },
  {
    path: 'sap-articulos',
    component: SaparticulosComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class DeliveriesRoutingModule { }
