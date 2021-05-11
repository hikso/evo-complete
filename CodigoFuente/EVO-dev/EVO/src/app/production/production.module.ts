import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductionRoutingModule } from "./production-routing.module";

import { SharedModule } from "../shared/shared.module";
import { NgprimeModule } from "../ngprime/ngprime.module";

import { ProductionComponent } from 'src/app/production/index/production.component';
import { MaterialModule } from "../material/material.module";

@NgModule({
  declarations: [
    ProductionComponent
  ],
  imports: [
    CommonModule,
    ProductionRoutingModule,
    SharedModule,
    MaterialModule,
    NgprimeModule,
  ]
})
export class ProductionModule { }
