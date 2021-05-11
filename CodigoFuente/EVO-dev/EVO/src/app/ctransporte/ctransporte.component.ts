import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { LazyLoadEvent, Paginator } from 'primeng/primeng';
import { SettingService } from '../core/services/setting.service';
import { generalParamNames } from 'src/app/config/global';

export interface filterTable {
  rolId: String,
  nombre: String,
  activo: boolean
}

@Component({
  selector: 'app-ctransporte',
  templateUrl: './ctransporte.component.html',
  styleUrls: ['./ctransporte.component.scss']
})
export class CtransporteComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  rol;
  maxregister;
  NumRegistro;
  filterTable: filterTable;
  from: number;
  to: number;
  totalRow: number = 0;
  maxR = 0;
  numFilas = 0;
  nameCol;
  contentCol;


  constructor(private setting: SettingService) { 
    this.filterTable = <filterTable>{};
  }

  ngOnInit() {
    //encabezados de tabla
    this.columns=[
      {field: 'fecha', header: 'Fecha', class: ''},
      {field: 'puntoventa', header: 'Punto de Venta', class: ''},
      {field: 'codigoarticulo', header: 'Codigo Artículo', class: ''},
      {field: 'nombrearticulo', header: 'Nombre Artículo', class: ''},
      {field: 'costo', header: 'Costo Transporte', class: ''}
    ];

    this.getAllCosto();
  }

  //Get todos los Costos
  getAllCosto(){
    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.maxR = Number(this.NumRegistro.valor);
    this.getFromToCosto(1, Number(this.NumRegistro.valor));
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
        this.getFromToCosto(1, max);
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
        this.getFromToCosto(1, Number(this.NumRegistro.valor));

      }
    }
  }

  //Roles por rango
  getFromToCosto(from, to){
    // this.roles.getAllRoles(from, to).subscribe(
    //   resp=>{
    //     this.rol = resp["registros"];
    //     this.totalRow = resp["numeroTotalRegistros"];
    //     this.maxregister = [
    //       {name: to},
    //       {name: 5 },
    //       {name: 10 },
    //       {name: 25 },
    //       {name: 50 },
    //       {name: 100 }
    //     ];
    //     this.numPage(from, to, this.totalRow);
    //   }
    // )
  }

  //calcular numero de registros por pagina
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
  
  }

   //Filtros por columnas
   getFilter(event, nombreCampo, filter, desde, hasta ) {
    this.nameCol = nombreCampo;
    this.contentCol = event;

  }

}
