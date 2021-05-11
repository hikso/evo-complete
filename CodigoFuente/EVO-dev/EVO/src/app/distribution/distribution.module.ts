import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DistributionRoutingModule } from "./distribution-routing.module";

import { SharedModule } from "../shared/shared.module";
import { NgprimeModule } from "../ngprime/ngprime.module";

import { DistribucionComponent } from 'src/app/distribution/index/distribucion.component';
import { DetalleComponent } from 'src/app/distribution/detalle/detalle.component';
import { DetalleEditComponent } from 'src/app/distribution/detalle-edit/detalle-edit.component';
import { CarsComponent } from 'src/app/distribution/cars/cars.component';
import { CarsdetailsComponent } from 'src/app/distribution/carsdetails/carsdetails.component';
import { MaterialModule } from "../material/material.module";

@NgModule({
  declarations: [
    DistribucionComponent,
    DetalleComponent,
    DetalleEditComponent,
    CarsComponent,
    CarsdetailsComponent
  ],
  imports: [
    CommonModule,
    DistributionRoutingModule,
    SharedModule,
    MaterialModule,
    NgprimeModule,
  ]
})
export class DistributionModule { }
