
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DeliveriesRoutingModule } from './deliveries-routing.module';
import { NgprimeModule } from "../ngprime/ngprime.module";
import { SharedModule } from "../shared/shared.module";
import { DecimalnumberPipe } from "../shared/pipes/decimalnumber.pipe";
import { IndexComponent } from 'src/app/deliveries/index/index.component';
import { IndexdetailsComponent } from 'src/app/deliveries/indexdetails/indexdetails.component';
import { ApprovedComponent } from 'src/app/deliveries/approved/approved.component';
import { DetallesComponent } from 'src/app/deliveries/detalles/detalles.component';
import { ProgrammingComponent } from 'src/app/deliveries/programming/programming.component';
import { DeliveriesComponent } from 'src/app/deliveries/deliveries/deliveries.component';
import { EditdeliveriesComponent } from 'src/app/deliveries/editdeliveries/editdeliveries.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { PurchaseDetailComponent } from './purchasedetail/purchasedetail.component';
import { MaterialModule } from "../material/material.module";

@NgModule({
  declarations: [
    IndexComponent,
    IndexdetailsComponent,
    ApprovedComponent,
    DetallesComponent,
    ProgrammingComponent,
    DeliveriesComponent,
    EditdeliveriesComponent,
    PurchaseComponent,
    PurchaseDetailComponent
  ],
  imports: [
    CommonModule,
    DeliveriesRoutingModule,
    NgprimeModule,
    MaterialModule,
    SharedModule
  ],
  providers: [
    DecimalnumberPipe
  ]
})
export class DeliveriesModule { }
