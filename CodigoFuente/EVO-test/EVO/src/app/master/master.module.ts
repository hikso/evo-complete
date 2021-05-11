import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module'
import { MasterComponent } from './components/master/master.component';
import { MasterRoutingModule } from './master-routing.module';
import { CtransporteComponent } from '../ctransporte/ctransporte.component';

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
    CtransporteComponent,
  ]
})

export class MasterModule {}
