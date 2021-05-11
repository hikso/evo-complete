import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';
import { ActivatedRoute } from '@angular/router';
import { generalParamNames } from 'src/app/config/global';

import { PedidosService } from 'src/app/core/services/pedidos.service';
import { SettingService } from 'src/app/core/services/setting.service';

export interface pedidoId{
  PedidoId: number,
  Estado: String,
  Detalles: any[]
}

export interface getArticulos{
  DetallePedidoId:number;   
  Codigo: String,
  Nombre: String,
  Estado: String,
  CantidadSolicitada: number,
  UnidadMedida: number,
  CantidadAprobada: number,
  StockDisponible: number
}

@Component({
  selector: 'app-indexdetails',
  templateUrl: './indexdetails.component.html',
  styleUrls: ['./indexdetails.component.scss']
})
export class IndexdetailsComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  Id;
  getPedido: any;
  getArticulos;
  maxR;
  maxregister;
  NumRegistro;
  Eregular;
  bGuardar: boolean;
  pedidoId: pedidoId;
  info: any;
  bdefinitivo: boolean;
  contBtn;
  decimal;

  constructor(private actRoute: ActivatedRoute, private pedid: PedidosService, private setting: SettingService) { }

  ngOnInit() {
    this.pedidoId = <pedidoId>{};
    this.bdefinitivo = true;
    this.bGuardar = true;
    this.contBtn = 0;

    //encabezados de tabla
    this.columns=[
      {field: 'codigoPedido', header: 'Código Artículo', class: ''},
      {field: 'nombre', header: 'Nombre', class: ''},
      {field: 'estado', header: 'Estado', class: ''},
      {field: 'cantidadSolicitada', header: 'Cantidad Solicitada', class: ''},
      {field: 'unidadMedida', header: 'Unidad de Medida', class: 'text-right'},
      {field: 'cantidadAprobada', header: 'Cantidad Aprobada', class:'thinput text-right'},
      {field: 'stock', header: 'Stock Disponible', class: 'text-center'}
    ];

    this.Id = this.actRoute.snapshot.paramMap.get('id');
    this.getPedidoId(this.Id);
    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);    
    this.Eregular = this.setting.getRegisterLocalStorage(generalParamNames.EXPRESION_REGULAR_ENTERO_DECIMAL);
    let mindecimal = this.setting.getRegisterLocalStorage(generalParamNames.MINIMO_DECIMALES);
    let maxdecimal = this.setting.getRegisterLocalStorage(generalParamNames.MAXIMO_DECIMALES);
    this.decimal = '.'+mindecimal.valor+'-'+maxdecimal.valor;
  }

  //Get detalles del pedido con Id
  getPedidoId(id){
    this.pedid.getPedidoId(id).subscribe(
      resp=>{
        this.getPedido = resp;
        this.getArticulos = resp["PedidoDetallesRespuesta"];
        this.maxR = 10;
        this.maxregister = [
          {name: this.NumRegistro.valor},
          {name: 5 },
          {name: 10 },
          {name: 25 },
          {name: 50 },
          {name: 100 }
        ];
      }
    )
  }

  //captura cambios del dropdown #registros por fila
  onChange(event){
    if(event.value!==null){
      this.maxR = Number(event.value.name);  
    } 
  }
  

}
