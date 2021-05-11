import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { FilterTable } from 'src/app/interface/filter-table';
import { calendarFormat, generalParamNames } from 'src/app/config/global';

import { PedidosService } from 'src/app/core/services/pedidos.service';
import { SettingService } from 'src/app/core/services/setting.service';
import * as moment from 'moment';

  
@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.scss']
})
export class PurchaseComponent implements OnInit {

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
    calendarFormat = calendarFormat;
  
    constructor(private setting: SettingService, private pedidosService: PedidosService) { 
      this.filterTable = <FilterTable>{};
    }
  
    ngOnInit() {
      //encabezados de tabla
      this.columns=[
        {field: 'numeroPedido', header: 'Número Pedido', class: '', width: '10%', hasFilter: true, isDate: false},
        {field: 'fechaSolicitud', header: 'Fecha Solicitud', class: '', width: '15%', hasFilter: true, isDate: true},
        {field: 'fechaLimiteSugerida', header: 'Fecha Límite Sugerida', class: '', width: '20%', hasFilter: true, isDate: true},
        {field: 'estadoPedido', header: 'Estado Pedido', class: '', width: '15%', hasFilter: true, isDate: false},
        {field: 'cliente', header: 'Cliente', class: 'columnC', width: '20%', hasFilter: true, isDate: false},
        {field: 'diasEntrega', header: 'Días para la Entrega', class:'', width: '10%', hasFilter: true, isDate: false},
        {field: 'acciones', header: 'Acciones', class: 'text-center', width: '12%', hasFilter: false, isDate: false}
      ];
  
      this.getAllPurchaseOrders();
    }
  
    getAllPurchaseOrders(){
      this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
      this.maxR = Number(this.NumRegistro.valor);
      this.getFromToPurchaseOrders(1, Number(this.NumRegistro.valor));
    }
  
    getFromToPurchaseOrders(from, to){
        const data = {
            desde: from,
            hasta: to,
            filtrar: {
                numeroPedido: "",
                fechaSolicitud: "",
                fechaLimiteSugerida: "",
                estadoPedido: "",
                cliente: "",
                diasEntrega: ""
            }
        }
        this.pedidosService.getAllPurchaseOrders(data).subscribe(
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
        );
    }
  
    //captura cambios del dropdown #registros por fila
    onChange(event){
      if(event.value !=null){
  
        if(this.nameCol != null && this.contentCol != null){
          this.maxR =  Number(event.value.name)
          this.getFilter(this.contentCol, this.nameCol, 1,Number(event.value.name));
  
        }else{
            const max = Number(event.value.name);   
            this.maxR = Number(event.value.name);
            const data = {
                desde: 0,
                hasta: max,
                filtrar: {
                    numeroPedido: "",
                    fechaSolicitud: "",
                    fechaLimiteSugerida: "",
                    estadoPedido: "",
                    cliente: "",
                    diasEntrega: ""
                }
            }
            this.getFromToPurchaseOrders(1, max);
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
          this.getFilter(this.contentCol, this.nameCol, 1 ,Number(this.NumRegistro.valor));
  
        }else{
  
          this.maxR = Number(this.NumRegistro.valor);
          this.getFromToPurchaseOrders(1, Number(this.NumRegistro.valor));
  
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
          this.getFromToPurchaseOrders(1, Number(this.NumRegistro.valor));
  
        }else{
          this.getFromToPurchaseOrders(1, (event.first + event.rows));
        }
        return;
      }
  
      const isAnyFilterEmpty = Object.values(filter).every(x => (x === ''));
  
      if (filter === null || filter === undefined || isAnyFilterEmpty) {
        
        this.getFromToPurchaseOrders(event.first + 1, (event.first + event.rows) );
      }
  
      if (filter !== undefined && filter.codigoPedido !== undefined) {
        this.getFilter(filter.codigoPedido, 'codigoPedido', event.first + 1, (event.first + event.rows));
      }
  
      if (filter !== undefined && filter.fechaSolicitud !== undefined) {
        this.getFilter(filter.fechaSolicitud, 'fechaSolicitud', event.first + 1, (event.first + event.rows));
      }
  
      if (filter !== undefined && filter.fechaEntrega !== undefined) {
        this.getFilter(filter.fechaEntrega, 'fechaEntrega', event.first + 1, (event.first + event.rows));
      }
  
      if (filter !== undefined && filter.estado !== undefined) {
        this.getFilter(filter.estado, 'estado', event.first + 1, (event.first + event.rows));
      }
  
      if (filter !== undefined && filter.cliente !== undefined) {
        this.getFilter(filter.cliente, 'cliente', event.first + 1, (event.first + event.rows));
      }
  
      if (filter !== undefined && filter.diasEntrega !== undefined) {
        this.getFilter(filter.diasEntrega, 'dias', event.first + 1, (event.first + event.rows));
      }
  
      if (filter !== undefined && filter.zona !== undefined) {
        this.getFilter(filter.zona, 'zona', event.first + 1, (event.first + event.rows));
      }
  
    }
  
    //Filtros por columnas
    getFilter(event, nombreCampo, desde, hasta ) {
        this.nameCol = nombreCampo;
        this.contentCol = event;

        this.columns.map(col =>{
            if (col.field == nombreCampo && col.isDate && event !== '') {
                event = moment(event).format('DD/MM/YYYY')
            }
        });
        
        //Guardar en variable valor del input por columnas
        this.filterTable[nombreCampo] = event;
        const isAnyFilterEmpty = Object.values(this.filterTable).every(x => (x === ''));

        //Clear de inputs, se carga las varibales con el valor inicial
        if (isAnyFilterEmpty){
            this.getFromToPurchaseOrders(1, Number(this.NumRegistro.valor));
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
        this.pedidosService.getAllPurchaseOrders(data).subscribe(
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
