import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { ProductionComponent } from 'src/app/production/index/production.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'produccion'
  },
  {
    path: 'programacion',
    component: ProductionComponent
  }
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
export class ProductionRoutingModule { }
