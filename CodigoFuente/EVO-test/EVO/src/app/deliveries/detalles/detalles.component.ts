import { Component, OnInit, ViewChild, Pipe } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PedidosService } from 'src/app/core/services/pedidos.service';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';
import { SettingService } from 'src/app/core/services/setting.service';
import Swal from 'sweetalert2';
import { generalParamNames, calendarFormat } from 'src/app/config/global';
import * as moment from 'moment';

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

export interface EstadosArticulos{
    EstadoArticuloId: number,
    Nombre: string
}

export interface EmpaquesArticulos{
    empaqueId: number,
    empaqueNombre: string
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
  whscode;
  getPedido: any;
  getArticulos;
  maxR;
  maxregister;
  NumRegistro;
  Eregular;
  disableSaveEraserButton: boolean;
  pedidoId: pedidoId;
  estados: EstadosArticulos[];
  empaques: EmpaquesArticulos[];
  info: any;
  disableSaveButton: boolean;
  contBtn;
  decimal;
  calendarFormat = calendarFormat;
  today = new Date();

  constructor(private actRoute: ActivatedRoute, private pedidosService: PedidosService, private setting: SettingService) {
    this.getPedido = <any>{};
   }

  ngOnInit() {
    this.pedidoId = <pedidoId>{};
    this.disableSaveButton = true;
    this.disableSaveEraserButton = true;
    this.contBtn = 0;

    //encabezados de tabla
    this.columns=[
      {field: 'codigoPedido', header: 'Código Artículo', class: '', width: '10%', showOnWhsCode:false},
      {field: 'nombre', header: 'Nombre', class: '', width: '15%', showOnWhsCode:false},
      {field: 'estado', header: 'Estado', class: '', width: '10%', showOnWhsCode:false},
      {field: 'emapque', header: 'Empaque', class: '', width: '10%', showOnWhsCode:false},
      {field: 'cantidadSolicitada', header: 'Cantidad Solicitada', class:'text-right', width: '7%', showOnWhsCode:false},
      {field: 'unidadMedida', header: 'Unidad de Medida', class:'text-right', width: '5%', showOnWhsCode:false},
      {field: 'cantidadAprobada', header: 'Cantidad Aprobada', class:'thinput text-right', width: '7%', showOnWhsCode:false},
      {field: 'stock', header: 'Stock Disponible', class:'text-right', width: '7%', showOnWhsCode:false},
      {field: 'produccionFutura', header: 'Producción Futura', class:'text-right', width: '7%', showOnWhsCode:true}
    ];

    this.Id = this.actRoute.snapshot.paramMap.get('id');
    this.whscode = this.actRoute.snapshot.paramMap.get('whscode');

    this.getEstados();
    this.getEmpaques();
    this.getPedidoId(this.Id);

    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.Eregular = this.setting.getRegisterLocalStorage(generalParamNames.EXPRESION_REGULAR_ENTERO_DECIMAL);
    let mindecimal = this.setting.getRegisterLocalStorage(generalParamNames.MINIMO_DECIMALES);
    let maxdecimal = this.setting.getRegisterLocalStorage(generalParamNames.MAXIMO_DECIMALES);
    this.decimal = '.'+mindecimal.valor+'-'+maxdecimal.valor;
  }

    /**
     * Get detalles del pedido con Id
     * @param id 
     */
    getPedidoId(id){
        this.pedidosService.getPedidoId(id).subscribe(
            resp=>{
                this.getPedido = resp;
                this.getArticulos = resp["PedidoDetallesRespuesta"];
                this.getArticulos.forEach(element => {
                    element.BackStockDisponible = element.StockDisponible;
                    const empaque = this.empaques.filter(empaque => element.empaqueId == empaque.empaqueId);
                    const estado = this.estados.filter(estado => element.estadoId == estado.EstadoArticuloId);
                    element.empaque = empaque[0];
                    element.estado = estado[0];
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

    /**
     * Obtiene los estados de productos
     */
    getEstados(){
        this.pedidosService.getEstados().subscribe((estados: EstadosArticulos[])=>{
            this.estados = estados;
        });
    }
    
    /**
     * Obtiene los estados de productos
     */
    getEmpaques(){
        this.pedidosService.getEmpaques().subscribe((empaques: EmpaquesArticulos[])=>{
            this.empaques = empaques;
        });
    }

    
    /**
     * 
     */
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
        Swal.fire({
            title: '¿Estás seguro qué desea guardar borrador?',
            text: "",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#47a44b',
            cancelButtonColor: '#d33',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Confirmar'
          }).then((result) => {
            if (result.value) {
                const dateIsValid = moment(this.getPedido.FechaEntrega).isValid();
                const dataRegister = {
                    "pedidoId": this.Id,
                    "fechaLimiteSugerida": dateIsValid ? moment(this.getPedido.FechaEntrega).format('DD/MM/YYYY'):this.getPedido.FechaEntrega,
                    "articulos": []
                };

                const contad = 0;
                this.pedidoId.PedidoId = Number(this.Id);
                this.pedidoId.Estado = 'Abierto';
        
                for (let i = 0; i < this.getArticulos.length; i++) {
                    dataRegister.articulos.push({
                        'detallePedidoId':this.getArticulos[i].DetallePedidoId,
                        'cantidadAprobada':this.getArticulos[i].CantidadAprobada,
                        'estadoArticuloId':this.getArticulos[i].estado.EstadoArticuloId,
                        'empaqueId':this.getArticulos[i].empaque.empaqueId
                    });
                }
                
                this.pedidosService.saveEraserDelivery(dataRegister).subscribe(
                    resp=>{
                        this.disableSaveButton = false;
                        this.getPedidoId(Number(this.Id));
                        this.disableSaveEraserButton = true;
                        this.disableSaveButton = true;
                        if(resp){
                            Swal.fire(
                            'Pedio Guardado!',
                            'Documento guardado con exito',
                            'success');
                        }
                    },
                    error=>{
                        let msg = error.error;
                        Swal.fire(
                            'Error al Guardar Pedido. Por favor, intentarlo de nuevo.',
                            msg,
                            'error');
                    }
                );
            }
        })
    }


    // Enviar pedido a Distribución
    // Bussiness Rules: Una vez enviado como definitivo no
    // se puede modificar, se deshabilitan los inputs
    // Se manejan dos estados: Aceptado Parcial y Aceptado Total
    EnviarDistribucion(){
        const dataRegister = [];
        this.pedidoId.PedidoId = Number(this.Id);
        this.pedidoId.Estado = 'Aprobación Completa';

        for (let i = 0; i < this.getArticulos.length; i++) {
            dataRegister[i] = {
                'DetallePedidoId':this.getArticulos[i].DetallePedidoId,
                'CantidadAprobada':this.getArticulos[i].CantidadAprobada
            }

            if(this.getArticulos[i].CantidadAprobada < this.getArticulos[i].CantidadSolicitada){
                this.pedidoId.Estado = 'Aprobación Parcial';
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
            this.pedidosService.updatePedido(data).subscribe(
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
