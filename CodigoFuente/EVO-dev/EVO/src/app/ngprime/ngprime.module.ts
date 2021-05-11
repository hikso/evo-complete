import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TableModule } from 'primeng/table';
import { AccordionModule } from 'primeng/accordion';
import { DropdownModule } from 'primeng/dropdown';
import { PaginatorModule } from 'primeng/paginator';
import { CheckboxModule } from 'primeng/checkbox';
import { TabViewModule } from 'primeng/tabview';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CalendarModule } from 'primeng/calendar';
import { MultiSelectModule } from 'primeng/multiselect';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TableModule,
    AccordionModule,
    DropdownModule,
    PaginatorModule,
    CheckboxModule,
    TabViewModule,
    NgbModule,
    CalendarModule,
    MultiSelectModule
  ],
  exports: [
    TableModule,
    AccordionModule,
    DropdownModule,
    PaginatorModule,
    CheckboxModule,
    TabViewModule,
    NgbModule,
    CalendarModule,
    MultiSelectModule
  ]
})
export class NgprimeModule { }
