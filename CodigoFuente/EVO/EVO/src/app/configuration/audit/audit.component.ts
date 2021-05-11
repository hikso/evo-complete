import { Component, OnInit, ViewChild } from '@angular/core';
import { LazyLoadEvent, Paginator } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { FormBuilder } from '@angular/forms';
import {NgbModal, ModalDismissReasons, NgbModalOptions} from '@ng-bootstrap/ng-bootstrap';
import { generalParamNames } from 'src/app/config/global';

import { AuditService } from 'src/app/core/services/audit.service';
import { SettingService } from 'src/app/core/services/setting.service';

export interface filterTable {
  fecha: String,
  accion: String,
  parametros: String,
  usuario: String,
  ip: String
}

@Component({
  selector: 'app-audit',
  templateUrl: './audit.component.html',
  styleUrls: ['./audit.component.scss']
})


export class AuditComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  auditoria;
  maxregister;
  NumRegistro;
  filterTable: filterTable;
  from: number;
  to: number;
  totalRow: number = 0;
  maxR = 0;
  numFilas = 0;
  closeResult: string;
  auditoriaId;
  nameCol;
  contentCol;
  

  constructor(private setting: SettingService, private audit: AuditService, private modalService: NgbModal) {
    this.filterTable = <filterTable>{};
  }

  ngOnInit() {

    //encabezados de tabla
    this.columns=[
      { field: 'fecha', header: 'Fecha', class:'' },
      { field: 'usuario', header: 'Usuario', class:'' },
      { field: 'detalle', header: 'Detalle',class:''  },
      { field: 'parametros', header: 'Parámetros',class:''  },
      { field: 'ip', header: 'IP',class:''  },
      { field: 'accion', header: 'Acciones',class:'text-center'}
    ];

    this.getAllAudit();

  }

  //Get todas las auditorias
  getAllAudit(){
   this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
   this.maxR = Number(this.NumRegistro.valor);
   this.getFromToAudit(1, Number(this.NumRegistro.valor));
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
        this.getFromToAudit(1, max);
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
        this.getFromToAudit(1, Number(this.NumRegistro.valor));

      }
    }
  }

  //Auditorias por rango
  getFromToAudit(from, to){
    this.audit.getAllAudit(from, to).subscribe(
      resp=>{
        this.auditoria = resp["registros"];
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
        this.getFromToAudit(1, Number(this.NumRegistro.valor));

      }else{
        this.getFromToAudit(1, (event.first + event.rows));
      }
      return;
    }

    // const filter = this.filterTable; //variable tipo interface

    if (filter === null || filter === undefined || (filter.accion === undefined
        &&  filter.fecha === undefined  &&  filter.usuario === undefined
        &&  filter.ip === undefined  &&  filter.parametros === undefined)) {
      
      this.getFromToAudit(event.first + 1, (event.first + event.rows) );
    }

    if (filter !== undefined && filter.accion !== undefined) {
      this.getFilter(filter.accion, 'accion', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.parametros !== undefined) {
      this.getFilter(filter.parametros, 'parametros', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.fecha !== undefined) {
      this.getFilter(filter.fecha, 'fecha', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.ip !== undefined) {
      this.getFilter(filter.ip, 'ip', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.usuario !== undefined) {
      this.getFilter(filter.usuario, 'usuario', undefined, event.first + 1, (event.first + event.rows));
    }
  }

  //Filtros por columnas
  getFilter(event, nombreCampo, filter, desde, hasta ) {
    this.nameCol = nombreCampo;
    this.contentCol = event;
    
    //Guardar en variable valor del input por columnas
    switch (nombreCampo) {
      case ('fecha'):        
        this.filterTable.fecha = event
        if(event === ''){
          this.filterTable.fecha =  undefined;
        }
        break;
      case ('detalle'):        
        this.filterTable.accion =  event;
        if(event === ''){
          this.filterTable.accion = undefined
        }
        break;
      case ('parametros'):
          this.filterTable.parametros =  event;
          if(event === ''){
            this.filterTable.parametros = undefined
          }
          break;
       case ('usuario'):
          this.filterTable.usuario =  event;
          if(event === ''){
            this.filterTable.usuario = undefined
          }
          break;
       case ('ip'):
          this.filterTable.ip =  event;
          if(event === ''){
            this.filterTable.ip = undefined
          }
          break;
    }

    //Clear de inputs, se carga las varibales con el valor inicial
    if (this.filterTable.fecha === ''  && this.filterTable.accion === ''
      && this.filterTable.parametros === '' && this.filterTable.usuario === ''
      && this.filterTable.ip === '' || this.filterTable.fecha === undefined
      && this.filterTable.accion === undefined && this.filterTable.parametros === undefined
      && this.filterTable.usuario === undefined && this.filterTable.ip === undefined){
      
      this.getFromToAudit(1, Number(this.NumRegistro.valor));
      this.filterTable = <filterTable>{};
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
    this.audit.getFilter(data).subscribe(
      resp=>{
        this.auditoria = resp["registros"];
        this.totalRow = resp["numeroTotalRegistros"];
        this.numPage(this.from, this.to, this.totalRow);
        if ( desde === 1 ) {
          this.dt.first = 0;
          this.pg.first = 0;
        }
      }
    );

  }

  //Abrir modal detalle Auditoria
  open(content, datos) {
    this.auditoriaId = datos;
    this.modalService.open(content, {size:'lg'} ).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
 
  //cerrar modal detalle Auditoria
  private getDismissReason(reason: any): string {
    this.auditoriaId = '';
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

}

