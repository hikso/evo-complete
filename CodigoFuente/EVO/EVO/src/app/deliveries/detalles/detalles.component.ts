import { Component, OnInit, ViewChild, Pipe } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PedidosService } from 'src/app/core/services/pedidos.service';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';
import { SettingService } from 'src/app/core/services/setting.service';
import Swal from 'sweetalert2';
import { DecimalPipe } from '@angular/common';
import { debug } from 'util';
import { generalParamNames } from 'src/app/config/global';

declare var $: any;

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
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.scss']
})
export class DetallesComponent implements OnInit {

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
  disableSaveEraserButton: boolean;
  pedidoId: pedidoId;
  info: any;
  disableSaveButton: boolean;
  contBtn;
  decimal;

  constructor(private actRoute: ActivatedRoute, private pedid: PedidosService, private setting: SettingService) {
    this.getPedido = <any>{};
   }

  ngOnInit() {
    this.pedidoId = <pedidoId>{};
    this.disableSaveButton = true;
    this.disableSaveEraserButton = true;
    this.contBtn = 0;

    //encabezados de tabla
    this.columns=[
      {field: 'codigoPedido', header: 'Código Artículo', class: '', width: '5%'},
      {field: 'nombre', header: 'Nombre', class: '', width: '25%'},
      {field: 'estado', header: 'Estado', class: '', width: '7%'},
      {field: 'cantidadSolicitada', header: 'Cantidad Solicitada', class:'text-right', width: '7%'},
      {field: 'unidadMedida', header: 'Unidad de Medida', class:'text-right', width: '5%'},
      {field: 'cantidadAprobada', header: 'Cantidad Aprobada', class:'thinput text-right', width: '7%'},
      {field: 'stock', header: 'Stock Disponible', class:'text-right', width: '6%'}
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
        this.getArticulos.forEach(element => {
          element.BackStockDisponible = element.StockDisponible;
        });
        this.maxR = 10;
        this.maxregister = [
          {name: this.NumRegistro.valor},
          {name: 5 },
          {name: 10 },
          {name: 25 },
          {name: 50 },
          {name: 100 }
        ];
        this.checkButtonsState();
      }
    )
  }

  checkButtonsState(){

    this.contBtn = 0;
    let contStock = 0;
    let contCero = 0;

    // Estado: Aceptado total o Aceptado Parcial se bloquean los botones para no permitir ninguna
    // acción por parte del usuario, una vez aprobado no se puede modificar nada.
    // Si todos los valores en cantidad aprobada son cero los botones de bloquean, se habilitan
    // si existe por lo menos un cambio en algun campo.
    if(this.getPedido.Estado != 'Abierto'){
      this.disableSaveEraserButton = true;
      this.disableSaveButton = true;

    } else {
      for (let i = 0; i < this.getArticulos.length; i++) {
        contStock++;

        if(this.getArticulos[i].CantidadAprobada != 0){
          contCero++;

        }

        if(this.getArticulos[i].CantidadAprobada <= this.getArticulos[i].CantidadSolicitada ){
          this.contBtn++;
        }
      }

      if(contCero == 0){
        this.disableSaveEraserButton = true;
        this.disableSaveButton = true;

      }else if(this.contBtn === contStock){
        this.disableSaveEraserButton = false;
        this.disableSaveButton = false;

      }else{
        this.disableSaveEraserButton = true;
        this.disableSaveButton = true;
      }
    }

  }

  //captura cambios del dropdown #registros por fila
  onChange(event){
    if(event.value!==null){
      this.maxR = Number(event.value.name);
    }
  }

  // KEY UP inputs de cantidad Aprobada
  // validar la activación de botones de guardar y enviar
  //
  dataEdit(e: any, row, data){
    row.StockDisponible = row.BackStockDisponible;
    row.StockDisponible -= row.CantidadAprobada;
    if(data===null){
      this.disableSaveEraserButton = true;
      this.disableSaveButton = true;
      return;
    }
    this.handlerChangeCantidad(row);
    this.checkButtonsState();
  }

  dataEditKeyUp(article){
    ++article.CantidadAprobada;
    this.handlerChangeCantidad(article);
  }
  dataEditKeyDown(article, data){
    if (data > 0) {
      --article.CantidadAprobada;
    }
    this.handlerChangeCantidad(article);
  }

  focusNextField(i){
    setTimeout(() => {
      if (i !== this.getArticulos.length - 1) {
        $('tr').eq(i + 2).find('td').eq(5).click();
      }else{
        $('tr').eq(1).find('td').eq(5).click();
      }
    });
  }

  handlerChangeCantidad(article) {
    if (article.CantidadAprobada > article.CantidadSolicitada) {
      article.CantidadAprobada = article.CantidadSolicitada;
      article.StockDisponible = article.BackStockDisponible;
      article.StockDisponible -= article.CantidadAprobada;
      Swal.fire(
        "Por favor ingrese un valor menor a la cantidad solicitada.",
        "",
        "warning"
      );
    }
    article.edited = true;
  }
  //Guardar pedido en Borrador
  // Bussiness Rules: Botton cuando hay cambios en
  // el campo input de Cantidad Aprobada.
  borrador(){
    const dataRegister = [];
    const contad = 0;
    this.pedidoId.PedidoId = Number(this.Id);
    this.pedidoId.Estado = 'Abierto';

    for (let i = 0; i < this.getArticulos.length; i++) {
      dataRegister[i] = {
        'DetallePedidoId':this.getArticulos[i].DetallePedidoId,
        'CantidadAprobada':this.getArticulos[i].CantidadAprobada
      }

    }

    this.pedidoId.Detalles = dataRegister;
    this.savePedido(this.pedidoId, 'Guardado Temporalmente');


  }


  // Enviar pedido a Distribución
  // Bussiness Rules: Una vez enviado como definitivo no
  // se puede modificar, se deshabilitan los inputs
  // Se manejan dos estados: Aceptado Parcial y Aceptado Total
  EnviarDistribucion(){
    const dataRegister = [];
    this.pedidoId.PedidoId = Number(this.Id);
    this.pedidoId.Estado = 'Aceptado';

    for (let i = 0; i < this.getArticulos.length; i++) {
      dataRegister[i] = {
        'DetallePedidoId':this.getArticulos[i].DetallePedidoId,
        'CantidadAprobada':this.getArticulos[i].CantidadAprobada
      }

      if(this.getArticulos[i].CantidadAprobada < this.getArticulos[i].CantidadSolicitada){
        this.pedidoId.Estado = 'Aceptado Parcial';
      }
    }

    this.pedidoId.Detalles = dataRegister;

    this.savePedido(this.pedidoId, 'Enviado a Programación Entregas');

  }
  // Metodo que invoca el post para la actualización de pedido
  // en base de datos, consume API
  savePedido(data, description){

    //verificación envio de post
    Swal.fire({
      title: '¿Estás seguro?',
      text: "",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#47a44b',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Confirmar'
    }).then((result) => {
      if (result.value) {
        this.pedid.updatePedido(data).subscribe(
          resp=>{
            this.disableSaveButton = false;
            this.getPedidoId(Number(this.Id));
            this.disableSaveEraserButton = true;
            this.disableSaveButton = true;
            if(resp){
                Swal.fire(
                  'Pedio Aprobado!(La cantidad aprobada es mayor al stock disponible)',
                  description,
                  'success'
                )
              }else{
                Swal.fire(
                  'Pedio Aprobado!',
                  description,
                  'success'
                )
            }

          },
          error=>{
            let msg = error;
            Swal.fire(
              'Error al Guardar Pedido. Por favor, intentarlo de nuevo.',
              error.error,
              'error'
            )
          }
        )
      }
    })
  }

}
