import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module'
import { MasterComponent } from './components/master/master.component';
import { MasterRoutingModule } from './master-routing.module';

// import { DashboardComponent } from '../dashboard/dashboard.component';
// import { SecurityComponent } from '../security/security.component';
// import { AuditComponent } from '../configuration/audit/audit.component';
// import { AdminrolComponent } from '../configuration/roles/adminrol/adminrol.component';
// import { SaparticulosComponent } from '../configuration/saparticulos/saparticulos.component';
// import { IndexComponent } from '../deliveries/index/index.component';
// import { CreateComponent } from '../configuration/roles/create/create.component';
import { CtransporteComponent } from '../ctransporte/ctransporte.component';
// import { DetallesComponent } from '../deliveries/detalles/detalles.component';
// import { UsersrolComponent } from '../configuration/roles/usersrol/usersrol.component';
// import { EditComponent } from '../configuration/roles/edit/edit.component';
// import { DistribucionComponent } from '../distribution/index/distribucion.component';
// import { DeliveriesComponent } from '../deliveries/deliveries/deliveries.component';
// import { DetalleComponent } from '../distribution/detalle/detalle.component';
// import { DetalleEditComponent } from '../distribution/detalle-edit/detalle-edit.component';
// import { EditdeliveriesComponent } from '../deliveries/editdeliveries/editdeliveries.component';
// import { CarsComponent } from '../distribution/cars/cars.component';
// import { CarsdetailsComponent } from '../distribution/carsdetails/carsdetails.component';
// import { ApprovedComponent } from 'src/app/deliveries/approved/approved.component';
// import { SplashComponent } from '../shared/components/splash/splash.component';

// import { ProgrammingComponent } from 'src/app/deliveries/programming/programming.component';
// import { IndexdetailsComponent } from 'src/app/deliveries/indexdetails/indexdetails.component';
// import { NgprimeModule } from "../ngprime/ngprime.module";

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    MasterRoutingModule,
  ],
  declarations: [
    MasterComponent,
    // DashboardComponent,
    // SecurityComponent,
    // AuditComponent,
    // AdminrolComponent,
    // SaparticulosComponent,
    // IndexComponent,
    // CreateComponent,    
    CtransporteComponent,
    // DetallesComponent,    
    // UsersrolComponent,
    // EditComponent,
    // DistribucionComponent,    
    // DeliveriesComponent,
    // DetalleComponent,
    // DetalleEditComponent,
    // EditdeliveriesComponent,
    // CarsComponent,    
    // CarsdetailsComponent,    
    // ApprovedComponent,
    // ProgrammingComponent,
    // IndexdetailsComponent,
    // SplashComponent,
    // NgprimeModule,
  ]
})

export class MasterModule {}
