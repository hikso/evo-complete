import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

import { DashboardComponent } from 'src/app/dashboard/dashboard.component';
import { SecurityComponent } from 'src/app/security/security.component';
import { AuditComponent } from 'src/app/configuration/audit/audit.component';
import { AdminrolComponent } from 'src/app/configuration/roles/adminrol/adminrol.component';
import { SaparticulosComponent } from 'src/app/configuration/saparticulos/saparticulos.component';
import { IndexComponent } from 'src/app/deliveries/index/index.component';
import { CreateComponent } from 'src/app/configuration/roles/create/create.component';
import { CtransporteComponent } from 'src/app/ctransporte/ctransporte.component';
import { DetallesComponent } from 'src/app/deliveries/detalles/detalles.component';
import { UsersrolComponent } from 'src/app/configuration/roles/usersrol/usersrol.component';
import { EditComponent } from 'src/app/configuration/roles/edit/edit.component';
import { DistribucionComponent } from 'src/app/distribution/index/distribucion.component';
import { DeliveriesComponent } from 'src/app/deliveries/deliveries/deliveries.component';
import { DetalleComponent } from 'src/app/distribution/detalle/detalle.component';
import { EditdeliveriesComponent } from 'src/app/deliveries/editdeliveries/editdeliveries.component';
import { CarsComponent } from 'src/app/distribution/cars/cars.component';
import { CarsdetailsComponent } from 'src/app/distribution/carsdetails/carsdetails.component';
import { ApprovedComponent } from 'src/app/deliveries/approved/approved.component';
import { ProgrammingComponent } from 'src/app/deliveries/programming/programming.component';
import { IndexdetailsComponent } from 'src/app/deliveries/indexdetails/indexdetails.component';
import { PurchaseComponent } from 'src/app/deliveries/purchase/purchase.component';
import { DetalleEditComponent } from 'src/app/distribution/detalle-edit/detalle-edit.component';

export const MasterRoutes: Routes = [
    { 
        path: 'dashboard', 
        component: DashboardComponent 
    },
    { 
        path: 'security', 
        component: SecurityComponent 
    },
    { 
        path: 'configuracion/auditoria',        
        component: AuditComponent 
    },
    { 
        path: 'configuracion/adminrol',         
        component: AdminrolComponent 
    },
    { 
        path: 'configuracion/adminrol/create',  
        component: CreateComponent 
    },
    {
        path: 'configuracion/adminrol/:name/:id',
        component: UsersrolComponent
    },
    {
        path: 'configuracion/adminrol/edit/:name/:id',
        component: EditComponent
    },
    { 
        path: 'configuracion/sap-articulos',        
        component: SaparticulosComponent 
    },
    {
        path: 'consultas/ctransporte',
        component: CtransporteComponent
    },
    { 
        path: 'pedidos/consulta',          
        component: IndexComponent
    },  
    { 
        path: 'pedidos/consulta/:id',          
        component: IndexdetailsComponent
    },   
    {
        path:'pedidos/aprobar',
        component: ApprovedComponent
    },
    {
        path: 'pedidos/programar',
        component: ProgrammingComponent
    }, 
    {
        path: 'pedidos/programar/entregas/:id',
        component: DeliveriesComponent
    },
    {
        path: 'pedidos/programar/entregas/edit/:id',
        component: EditdeliveriesComponent
    },
    {
        path: 'distribucion/enrutamiento',
        component: DistribucionComponent
    },
    {
        path: 'distribucion/enrutamiento/entrega/:id',
        component: DetalleComponent
    },
    {
        path: 'distribucion/enrutamiento/entrega/edit/:id',
        component: DetalleEditComponent
    },
    {
        path: 'distribucion/enrutamiento/vehiculos',
        component: CarsComponent
    },
    {
        path: 'distribucion/enrutamiento/vehiculos/detalles/:id',
        component: CarsdetailsComponent
    },
];


@NgModule({
    imports: [
      CommonModule,
      BrowserModule,
      RouterModule.forRoot(MasterRoutes, {
        useHash: true,
        preloadingStrategy: PreloadAllModules
      })
    ],
    exports: [
      RouterModule
    ]
  })
  export class MasterRoutingModule { }