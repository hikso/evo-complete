import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { FilterTable } from 'src/app/interface/filter-table';
import { generalParamNames } from 'src/app/config/global';

import { PedidosService } from 'src/app/core/services/pedidos.service';
import { SettingService } from 'src/app/core/services/setting.service';


@Component({
  selector: 'app-programming',
  templateUrl: './programming.component.html',
  styleUrls: ['./programming.component.scss']
})
export class ProgrammingComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  pedidos;
  maxregister;
  NumRegistro;
  filterTable: FilterTable;
  from: number;
  to: number;
  totalRow: number = 0;
  maxR = 0;
  numFilas = 0;
  closeResult: string;
  auditoriaId;
  nameCol;
  contentCol;

  constructor(private setting: SettingService, private pedid: PedidosService) { 
    this.filterTable = <FilterTable>{};
  }

  ngOnInit() {
    //encabezados de tabla
    this.columns=[
      {field: 'codigoPedido', header: 'Número Pedido', class: ''},
      {field: 'fechaSolicitud', header: 'Fecha Solicitud', class: ''},
      {field: 'fechaEntrega', header: 'Fecha Entrega', class: ''},
      {field: 'estado', header: 'Estado', class: ''},
      {field: 'cliente', header: 'Cliente', class: 'columnC'},
      {field: 'zona', header: 'Zona', class: ''},
      {field: 'dias', header: '# Días Entrega', class: 'text-right'},
      {field: 'acciones', header: 'Acciones', class: 'text-center'}
    ];

    this.getAllPedidos();
  }

  

  getAllPedidos(){
    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.maxR = Number(this.NumRegistro.valor);
    this.getFromToPedidos(1, Number(this.NumRegistro.valor));
  }

  getFromToPedidos(from, to){
    this.pedid.getAllProgramming(from, to).subscribe(
      resp=>{
        this.pedidos = resp["registros"];
        this.totalRow = resp["numeroTotalRegistros"];
        this.maxregister = [
          {name: to},
          {name: 5 },
          {name: 10 },
          {name: 25 },
          {name: 50 },
          {name: 100 }
        ];
        this.numPage(from, to, this.totalRow);
      }
    )

  }

  //captura cambios del dropdown #registros por fila
  onChange(event){
    if(event.value !=null){

      if(this.nameCol != null && this.contentCol != null){

        this.maxR =  Number(event.value.name)
        this.getFilter(this.contentCol, this.nameCol, '',1,Number(event.value.name));

      }else{
        const max = Number(event.value.name);   
        this.maxR = Number(event.value.name);
        this.getFromToPedidos(1, max);
      }

    }else{
      this.maxregister = [
        {name: this.NumRegistro.valor},
        {name: 5 },
        {name: 10 },
        {name: 25 },
        {name: 50 },
        {name: 100 }
      ];
      

      this.maxR = Number(this.NumRegistro.valor);
      
      if(this.nameCol != null && this.contentCol != null){

        this.maxR = Number(this.NumRegistro.valor);
        this.getFilter(this.contentCol, this.nameCol, '', 1 ,Number(this.NumRegistro.valor));

      }else{

        this.maxR = Number(this.NumRegistro.valor);
        this.getFromToPedidos(1, Number(this.NumRegistro.valor));

      }
    }
  }

  //calcular Numero de registros por página
  numPage(from, to, total){
    if(total > to ){
      this.numFilas = to;
    }else{
      this.numFilas = total;
    }

    if ( from === 1) {
      this.dt.first = 0;
      this.pg.first = 0;
    }

  }

  //función que controla comportamiento de la paginación
  loadCarsLazy(event: LazyLoadEvent){
    
    const filter = this.filterTable; //variable tipo interface
    if (event.first  === 0 ) {
      if(event.rows === undefined){
        this.getFromToPedidos(1, Number(this.NumRegistro.valor));

      }else{
        this.getFromToPedidos(1, (event.first + event.rows));
      }
      return;
    }

    if (filter === null || filter === undefined || (filter.codigoPedido === undefined
        &&  filter.fechaSolicitud === undefined  &&  filter.fechaEntrega === undefined
        &&  filter.estado === undefined  &&  filter.cliente === undefined
        &&  filter.diasEntrega === undefined  &&  filter.zona === undefined)) {
      
      this.getFromToPedidos(event.first + 1, (event.first + event.rows) );
    }

    if (filter !== undefined && filter.codigoPedido !== undefined) {
      this.getFilter(filter.codigoPedido, 'codigoPedido', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.fechaSolicitud !== undefined) {
      this.getFilter(filter.fechaSolicitud, 'fechaSolicitud', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.fechaEntrega !== undefined) {
      this.getFilter(filter.fechaEntrega, 'fechaEntrega', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.estado !== undefined) {
      this.getFilter(filter.estado, 'estado', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.cliente !== undefined) {
      this.getFilter(filter.cliente, 'cliente', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.diasEntrega !== undefined) {
      this.getFilter(filter.diasEntrega, 'dias', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.zona !== undefined) {
      this.getFilter(filter.zona, 'zona', undefined, event.first + 1, (event.first + event.rows));
    }

  }

  //Filtros por columnas
  getFilter(event, nombreCampo, filter, desde, hasta ) {
    this.nameCol = nombreCampo;
    this.contentCol = event;
    
    //Guardar en variable valor del input por columnas
    switch (nombreCampo) {
      case ('codigoPedido'):        
        this.filterTable.codigoPedido = event
        if(event === ''){
          this.filterTable.codigoPedido =  undefined;
        }
        break;
      case ('fechaSolicitud'):        
        this.filterTable.fechaSolicitud =  event;
        if(event === ''){
          this.filterTable.fechaSolicitud = undefined
        }
        break;
      case ('fechaEntrega'):
        this.filterTable.fechaEntrega =  event;
        if(event === ''){
          this.filterTable.fechaEntrega = undefined
        }
        break;
      case ('estado'):
        this.filterTable.estado =  event;
        if(event === ''){
          this.filterTable.estado = undefined
        }
        break;
      case ('cliente'):
        this.filterTable.cliente =  event;
        if(event === ''){
          this.filterTable.cliente = undefined
        }
        break;
      case ('dias'):
        this.filterTable.diasEntrega =  event;
        if(event === ''){
          this.filterTable.diasEntrega = undefined
        }
        break;
      case ('zona'):
        this.filterTable.zona =  event;
        if(event === ''){
          this.filterTable.zona = undefined
        }
        break;
    }

    //Clear de inputs, se carga las varibales con el valor inicial
    if (this.filterTable.codigoPedido === ''  && this.filterTable.fechaSolicitud === ''
      && this.filterTable.fechaEntrega === '' && this.filterTable.estado === ''
      && this.filterTable.cliente === '' && this.filterTable.diasEntrega === '' 
      && this.filterTable.zona === ''|| this.filterTable.codigoPedido === undefined
      && this.filterTable.fechaSolicitud === undefined && this.filterTable.fechaEntrega === undefined
      && this.filterTable.estado === undefined && this.filterTable.cliente === undefined
      && this.filterTable.diasEntrega === undefined && this.filterTable.zona === undefined){
      
      this.getFromToPedidos(1, Number(this.NumRegistro.valor));
      this.filterTable = <FilterTable>{};
      return;
    }

    // Rango de consulta
    if (desde === undefined ||  hasta === undefined) {
      this.from = 1;
      this.to = this.maxR;
    } else {
      this.from = desde;
      this.to= hasta;
    }

    const data = {
      desde: this.from,
      hasta: this.to,
      filtro: this.filterTable
    }

    //Petición a servidor con datos capturados
    this.pedid.getFilterProgramming(data).subscribe(
      resp=>{
        this.pedidos = resp["registros"];
        this.totalRow = resp["numeroTotalRegistros"];
        this.numPage(this.from, this.to, this.totalRow);
        if ( desde === 1 ) {
          this.dt.first = 0;
          this.pg.first = 0;
        }
      }
    );

  }

}
