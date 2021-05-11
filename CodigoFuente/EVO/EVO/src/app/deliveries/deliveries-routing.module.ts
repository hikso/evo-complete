import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

import { IndexComponent } from 'src/app/deliveries/index/index.component';
import { IndexdetailsComponent } from 'src/app/deliveries/indexdetails/indexdetails.component';
import { ApprovedComponent } from 'src/app/deliveries/approved/approved.component';
import { DetallesComponent } from 'src/app/deliveries/detalles/detalles.component';
import { ProgrammingComponent } from 'src/app/deliveries/programming/programming.component';
import { DeliveriesComponent } from 'src/app/deliveries/deliveries/deliveries.component';
import { EditdeliveriesComponent } from 'src/app/deliveries/editdeliveries/editdeliveries.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { PurchaseDetailComponent } from './purchasedetail/purchasedetail.component';

const routes: Routes = [
  {
    path: 'consulta',
    component: IndexComponent
  },
  {
    path: 'consulta/:id',
    component: IndexdetailsComponent
  },
  {
    path: 'aprobar',
    component: ApprovedComponent
  },
  {
    path: 'aprobar/:id',
    component: DetallesComponent
  },
  {
    path: 'programar',
    component: ProgrammingComponent
  },
  {
    path: 'programar/entregas/:id',
    component: DeliveriesComponent
  },
  {
    path: 'programar/entregas/edit/:id',
    component: EditdeliveriesComponent
  },
  {
    path: 'compras',
    component: PurchaseComponent
  },
  {
    path: 'compras/detalle/:id/:edit',
    component: PurchaseDetailComponent
  },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class DeliveriesRoutingModule { }
