import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'configuracion/dashboard',
    pathMatch: 'full',
  },
  {
    path: 'home',
    redirectTo: 'configuracion/dashboard',
    pathMatch: 'full',
  },
  {
    path: 'configuracion',
    loadChildren: () => import('./configuration/configuration.module').then(m => m.ConfigurationModule)
  },
  {
    path: 'pedidos',
    loadChildren: () => import('./deliveries/deliveries.module').then(m => m.DeliveriesModule)
  },
  {
    path: 'distribucion',
    loadChildren: () => import('./distribution/distribution.module').then(m => m.DistributionModule)
  },
  {
    path: 'produccion',
    loadChildren: () => import('./production/production.module').then(m => m.ProductionModule)
  }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: true,
      preloadingStrategy: PreloadAllModules
    })
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
