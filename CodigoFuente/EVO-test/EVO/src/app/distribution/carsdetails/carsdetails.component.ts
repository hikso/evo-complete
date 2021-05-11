import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { Accordion } from 'primeng/accordion';
import { Paginator } from 'primeng/primeng';
import { ActivatedRoute } from '@angular/router';

import { PedidosService } from 'src/app/core/services/pedidos.service';

@Component({
  selector: 'app-carsdetails',
  templateUrl: './carsdetails.component.html',
  styleUrls: ['./carsdetails.component.scss']
})
export class CarsdetailsComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  @ViewChild('accordion',  {static: true}) accordion: Accordion;

  columns: any[];
  cars: any[];
  Id;
  car;
  entregas;
  objectKeys = Object.keys;
  entregaIndex: number[];
  typeOfCollapse: boolean = false;
  constructor(private actRoute: ActivatedRoute, private pedidosService: PedidosService) { }

  ngOnInit() {
    this.columns =[
      {field: 'codigo', header: '# Código Artículo', class: ''},
      {field: 'nombre', header: 'Nombre', class:''},
      {field: 'estado', header: 'Estado ', class:''},
      {field: 'cantidad', header:'Cantidad', class:'text-right'},
      {field: 'observaciones', header: 'Observaciones', class:''}
    ];

    this.cars = [];

    this.Id = this.actRoute.snapshot.paramMap.get('id');
    this.getPedidoId(this.Id);
  }

  ngAfterViewInit(){
    // this.entregaIndex = [0];
  }

  openAll(){
    this.entregaIndex = [0, 3];
  }

  collapseAllAccordionTabs() {      
    this.typeOfCollapse = !this.typeOfCollapse;
    for(let tab of this.accordion.tabs) {
      tab.selected = this.typeOfCollapse;
    }
  }
  
  getPedidoId(Id){
    this.pedidosService.getDetalleCars(Id).subscribe(
      resp=>{
        this.car = resp;
        this.entregas = resp["entregas"];
      }
    )
  }
}
