import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

import { DistribucionComponent } from 'src/app/distribution/index/distribucion.component';
import { DetalleComponent } from 'src/app/distribution/detalle/detalle.component';
import { DetalleEditComponent } from 'src/app/distribution/detalle-edit/detalle-edit.component';
import { CarsComponent } from 'src/app/distribution/cars/cars.component';
import { CarsdetailsComponent } from 'src/app/distribution/carsdetails/carsdetails.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'enrutamiento'
  },
  {
    path: 'enrutamiento',
    component: DistribucionComponent
  },
  {
    path: 'enrutamiento/entrega/:id',
    component: DetalleComponent
  },
  {
    path: 'enrutamiento/entrega/edit/:id',
    component: DetalleEditComponent
  },
  {
    path: 'enrutamiento/vehiculos',
    component: CarsComponent
  },
  {
    path: 'enrutamiento/vehiculos/detalles/:id',
    component: CarsdetailsComponent
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
export class DistributionRoutingModule { }
