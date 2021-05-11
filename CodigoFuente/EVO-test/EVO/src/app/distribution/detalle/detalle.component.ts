import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';
import { SettingService } from 'src/app/core/services/setting.service';
import { PedidosService } from 'src/app/core/services/pedidos.service';

@Component({
  selector: 'app-detalle',
  templateUrl: './detalle.component.html',
  styleUrls: ['./detalle.component.scss']
})
export class DetalleComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  Id;
  getPedido: any;
  getArticulos;
  maxR;
  maxregister;
  NumRegistro;

  constructor(private actRoute: ActivatedRoute, private setting: SettingService, private pedid: PedidosService) { }

  ngOnInit() {

    this.getPedido = [];
    
    //encabezados de tabla
    this.columns=[
      {field: 'codigo', header: 'Código Artículo', class: ''},
      {field: 'nombre', header: 'Nombre', class: ''},
      {field: 'cantidad', header: 'Cantidad', class:'text-right'}
    ];

    this.Id = this.actRoute.snapshot.paramMap.get('id');
    this.getPedidoId(this.Id);

  }


  //Get detalles del pedido con Id 
  // Estado == distribucion
  getPedidoId(id){
    this.pedid.getEntregasId(id).subscribe(
      resp=>{
        this.getArticulos = resp["Detalles"];
        this.getPedido = resp;
      }
    )
  }

}
