import { Component, OnInit, ViewChild } from '@angular/core';
import {NgbModal, ModalDismissReasons, NgbModalOptions} from '@ng-bootstrap/ng-bootstrap';
import {FormControl, FormGroupDirective, NgForm, Validators, FormGroup} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { FormBuilder, AbstractControl } from '@angular/forms';
import { PedidosService } from 'src/app/core/services/pedidos.service';
import { SettingService } from 'src/app/core/services/setting.service';
import { CarsService } from 'src/app/core/services/cars.service';
import Swal from 'sweetalert2';
import { ActivatedRoute } from '@angular/router';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';
import { DatePipe } from '@angular/common';
import { calendarFormat, generalParamNames } from 'src/app/config/global';
import { Accordion } from 'primeng/accordion';


declare var $: any;

export interface getArticulos{
    readonly length: number;
    /**
     * ID del artículo detalle en el pedido
     */
    detallePedidoId: number;
    codigoArticulo: String,
    nombreArticulo: String,
    Estado: String,
    UnidadMedida: number,
    cantidadSolicitada: number,
    cantidadGestionar: number,
    Pendiente: number,
    /**
     * Pendiente a Gestionar en la entrega
     */
    cantidadPendiente: number,
    HasPending: Boolean,
    stockAlmacen: number,
    cantidadFaltanteGestionar: number
}
export interface ArticulosGestionados{
    cantidad: number,
    cantidadSolicitada: number,
    codigoArticulo: string,
    detallePedidoId: number
    nombreArticulo: string,
    observaciones: string,
    ordenCompra: string,
    stockAlmacen: number,
    unidadMedida: string,
    edited: boolean
}

export interface getAcciones{
    accionId: number,
    articulos: ArticulosGestionados[],
    nombreAccion: string,
    fieldName: string
}

export interface EntregaId{
    PedidoId: Number,
    FechaEntrega: String,
    HoraEntrega: String,
    [Detalles: number]:{
        DetallePedidoId: number,
    }
}

  
@Component({
  selector: 'app-purchasedetail',
  templateUrl: './purchasedetail.component.html',
  styleUrls: ['./purchasedetail.component.scss']
})
export class PurchaseDetailComponent implements OnInit {
    @ViewChild('dt' ,  {static: true} )   dt: Table;
    @ViewChild('pg' ,  {static: true} )   pg: Paginator;
    @ViewChild('accordion',  {static: true}) accordion: Accordion;

    idOrdenCompra;
    closeResult: string;
    validNumberType: boolean = false;
    isAnyGestioned: boolean = false;    
    editMode: boolean = false;
    type: FormGroup;
    columns;
    columnsPedido;
    getArticulos: getArticulos[];
    getPedido: any;
    acciones: any;
    accionesBackUp: any;
    accion: any;
    getAcciones: getAcciones[];
    getEntregasIds;
    EntregaId: EntregaId;
    maxR;
    maxregister;
    NumRegistro;
    Eregular;
    totalWeightPendingForDelivery;
    totalE;
    btnDistr: boolean;
    buttonSelectAction: boolean;
    EntregasEnd: boolean;
    visibility: boolean;
    state: boolean;
    numEntr: number;
    maximoDecimales: number;
    Fecha: Date;
    Hora: Date;
    calendarFormat = calendarFormat;
    noAutorizado: boolean;
    today: Date;
    tiposVehiculo;
    tipoVehiculo;
    peso = 0;
    tipoVehiculoId;
  
    constructor(private modalService: NgbModal, private pedidosService: PedidosService,
                private actRoute: ActivatedRoute, private setting: SettingService) {
            this.getPedido = <any>{};
            this.EntregaId = <EntregaId>{};
        }
  
    ngOnInit() {
        this.noAutorizado = true;
        this.btnDistr = true;
        this.buttonSelectAction = true;
        this.EntregasEnd = true;
        this.visibility = true;
        this.numEntr = 0;
        this.totalWeightPendingForDelivery = 0;
        this.totalE = 0;

        // encabezados de tabla entregas
        this.columnsPedido = [
            {field: 'codigoArticulo', header: 'Código Artículo', class: '', width: '10%'},
            {field: 'nombre', header: 'Nombre', class: '', width: '20%'},
            {field: 'cantidadSolicitada', header: 'Cantidad Solicitada', class: '', width: '10%'},
            {field: 'cantidadGestionar', header: 'Cantidad a Gestionar',  class: 'text-right', width: '10%'},
            {field: 'cantidadPendiente', header: 'Pendiente a Gestionar',  class: 'text-right', width: '10%'},        
            {field: 'stockAlmacen', header: 'Stock Almacén',  class: 'text-right', width: '10%'},
            {field: 'observaciones', header: 'Observaciones',  class: 'text-right', width: '18%'},
        ];
  
        // encabezados de tabla entregas
        this.columns = [
            {field: 'codigoArticulo', header: 'Código Artículo', class: '', width: '10%'},
            {field: 'nombre', header: 'Nombre', class: '', width: '20%'},
            {field: 'cantidadSolicitada', header: 'Cantidad Solicitada', class: '', width: '10%'},
            {field: 'cantidadGestionar', header: 'Cantidad a Gestionar',  class: 'text-right', width: '10%'},
            {field: 'observaciones', header: 'Observaciones',  class: 'text-right', width: '18%'},
        ];
  
        this.today = new Date();

        this.idOrdenCompra = this.actRoute.snapshot.paramMap.get('id');
        this.editMode = this.actRoute.snapshot.paramMap.get('edit')==='true'?true:false;

        this.getPurchaseOrder(this.idOrdenCompra);
        this.getMotivos();
        this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
        this.Eregular = this.setting.getRegisterLocalStorage(generalParamNames.EXPRESION_REGULAR_ENTERO_DECIMAL);
        this.maximoDecimales = this.setting.getRegisterLocalStorage(generalParamNames.MAXIMO_DECIMALES);
    }
  
    // Detalle de las entregas del pedido
    getPurchaseOrder(id) {
        this.pedidosService.getPurchaseOrder(id).subscribe(
        resp => {
            this.getPedido = resp;
            this.getArticulos = resp["articulos"];
            this.getAcciones = resp["acciones"];
            this.maxR = this.getArticulos.length;
            this.getArticulos.map(article => {
                article.cantidadSolicitada = Number(Number(article.cantidadSolicitada).toFixed(this.maximoDecimales));
                article.cantidadFaltanteGestionar = Number(Number(article.cantidadFaltanteGestionar).toFixed(this.maximoDecimales));
            });

            this.getAcciones.forEach(accion => {
                accion.articulos.map(article => {
                    article.cantidad = Number(Number(article.cantidad).toFixed(this.maximoDecimales));
                    article.cantidadSolicitada = Number(Number(article.cantidadSolicitada).toFixed(this.maximoDecimales));
                });
            });

            this.totalArticulos();
        },
        error => {}
      )
    }
  
    //total de los articulos sin modificación
    totalArticulos() {
        let totalArticlesEnded = 0;
        this.getArticulos.map(article => {
            article.HasPending = true;
            if (article.cantidadFaltanteGestionar == 0) {
                totalArticlesEnded++;
                article.HasPending = false;
            }
            article.cantidadGestionar = article.cantidadFaltanteGestionar;
            article.cantidadPendiente = 0;
        });
  
        if(this.getArticulos.length <= totalArticlesEnded){ // se terminaron los articulos
            this.EntregasEnd = false;
            this.btnDistr = false;
            this.noAutorizado = false;
        }else{ //faltan articulos
            this.EntregasEnd = true;
            this.btnDistr = true;
        }

        this.getAcciones.forEach(function(accion){
            switch (accion.accionId) {
                case 1:
                    accion.fieldName = 'Solicitar Traslado';
                    break;
                case 2:
                case 3:
                    accion.fieldName = 'Con Gestión de Compra';
                    break;
            }
        });
        this.isAnyGestioned = Object.values<any>(this.getAcciones).every(x => (x.articulos.length === 0));
        this.checkButtonsDisability();
    }
  
    //captura cambios del dropdown #registros por fila
    onChange(event) {
        if(event.value!==null){
            this.maxR = Number(event.value.name);
        }
    }
  
    // KEY UP inputs de cantidad Aprobada
    // validar la activación de botones de agreagar y enviar
    checkButtonsDisability() {
        var totalWeightForDelivery = 0;
        this.buttonSelectAction = false;
  
        for (let i = 0; i < this.getArticulos.length; i++) {
            totalWeightForDelivery += this.getArticulos[i].cantidadGestionar;
        }
  
        this.buttonSelectAction = totalWeightForDelivery === 0;
    }

    getMotivos(){
        this.pedidosService.getAcciones().subscribe(
            resp=>{
                this.acciones = resp;
                this.accionesBackUp = this.acciones.map(a => ({...a}));
            }
        );
    }

    // Abri modal con informacion de fecha y hora para entrega;
    open(content) {
        this.acciones = this.accionesBackUp;

        const isAnyWithoutStock : boolean = Object.values<getArticulos>(this.getArticulos)
        .some(x => (x.stockAlmacen == 0 && x.cantidadGestionar > 0));

        if (isAnyWithoutStock) {
            this.acciones = this.acciones.filter(x => x.AccionId !== 1);
        }

        this.modalService.open(content).result.then((result) => {
            this.closeResult = `Closed with: ${result}`;
            this.clearModal();
        }, (reason) => {
            this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
            this.clearModal();
        });

    }
  
    clearModal(){
      this.accion = null;
    }
  
    // cerrar modal detalle Auditoria
    private getDismissReason(reason: any): string {
      if (reason === ModalDismissReasons.ESC) {
        return 'by pressing ESC';
      } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
        return 'by clicking on a backdrop';
      } else {
        return  `with: ${reason}`;
      }
    }
  
    async showVerificationAlert() {
      return Swal.fire({
        title: '¿Estás seguro?',
        text: "",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#47a44b',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Cancelar',
        confirmButtonText: 'Confirmar'
      });
    }

    /**
     * Limpia cambios realizados en el documento
     */
    limpiarDocumento(){
        this.showVerificationAlert().then(accept => {
            if (!accept.value) return;
            this.ngOnInit();
        });
    }
    finalizarDocumento(){
        this.showVerificationAlert().then(accept => {
            if (!accept.value) return;

            const dataRegister: Array<any> = [];
            this.getAcciones.forEach(accion => {
                accion.articulos.forEach(articulo => {
                    if (articulo.edited) {
                        dataRegister.push( {
                            'detallePedidoId': articulo.detallePedidoId,
                            'cantidadGestionar': articulo.cantidad,
                            'accionId': accion.accionId
                        });
                    }
                });
            });
            
            const data = {
                "pedidoId": this.idOrdenCompra,
                "articulosActualizarCompra": dataRegister
            };

            this.pedidosService.finalizarDocumentoGestionCompra(data).subscribe(
                resp => {
                    this.getPurchaseOrder(this.idOrdenCompra);
                    Swal.fire('Documento finalizado exitosamente!', '', 'success');
                },
                error => {
                    Swal.fire('Error al finalizar documento. Por favor, intentarlo de nuevo.', '', 'error');
                }
            );
        });
    }
    /**
     * Limpia cambios realizados en el documento
     */
    guardarBorrador(){
        this.showVerificationAlert().then(accept => {
            if (!accept.value) return;

            const dataRegister: Array<any> = [];
            this.getAcciones.forEach(accion => {
                accion.articulos.forEach(articulo => {
                    if (articulo.edited) {
                        dataRegister.push( {
                            'detallePedidoId': articulo.detallePedidoId,
                            'cantidadGestionar': articulo.cantidad,
                            'accionId': accion.accionId
                        });
                    }
                });
            });
            
            const data = {
                "pedidoId": this.idOrdenCompra,
                "articulosActualizarCompra": dataRegister
            };

            this.pedidosService.actualizarGestion(data).subscribe(
                resp => {
                    this.getPurchaseOrder(this.idOrdenCompra);
                    Swal.fire('Documento guardado exitosamente!', '', 'success');
                },
                error => {
                    Swal.fire('Error al guardar documento. Por favor, intentarlo de nuevo.', '', 'error');
                }
            );
        });
    }
    
    /**
     * Agrega las gestiones a los artículos seleccionados
     */
    AddEntregas() {
        this.showVerificationAlert().then(result => {
            const dataRegister = [];
            if (!result.value) return;
            // Error control
            let errors = [
                this.accion === undefined && 'Acción'
            ].filter(Boolean);

            if (errors.length) {
                Swal.fire(
                    'Error al guardar la entrega',
                    `Debe ingresar los siguientes campos: ${errors.join(', ')}`,
                    'error'
                );
                return;
            }

            // Armar array de entregas
            for (let i = 0; i < this.getArticulos.length; i++) {
                if (this.getArticulos[i].cantidadGestionar > this.getArticulos[i].cantidadFaltanteGestionar) {
                    
                    Swal.fire(
                        'Error con las cantidades a gestionar',
                        `El artículo: ${this.getArticulos[i].nombreArticulo} tinene una cantidad a gestionar superior la cantidad pendiente`,
                        'error'
                    )
                    this.modalService.dismissAll();
                    return;
                }

                if (this.getArticulos[i].cantidadGestionar > 0
                    && this.getArticulos[i].cantidadGestionar != undefined ) {
                    dataRegister.push( {
                        'detallePedidoId': this.getArticulos[i].detallePedidoId,
                        'codigoArticulo': this.getArticulos[i].nombreArticulo,
                        'cantidadGestionar': this.getArticulos[i].cantidadGestionar,
                        'stockActual': this.getArticulos[i].stockAlmacen
                    });
                }

                // disminuir a pendiente la cantidad agregada
                this.getArticulos[i].cantidadPendiente = this.getArticulos[i].cantidadPendiente - this.getArticulos[i].cantidadFaltanteGestionar;
            }

            const data = {
                "pedidoId": this.idOrdenCompra,
                "accionId": this.accion.AccionId,
                "articulosCompra": dataRegister
            };

            this.pedidosService.AddGestion(data).subscribe(
                resp => {
                    this.getPurchaseOrder(this.idOrdenCompra);
                    this.buttonSelectAction = true;
                    Swal.fire('Entrega agregada Exitosamente!', '', 'success');
                    this.Fecha = null;
                    this.Hora = null;
                    this.modalService.dismissAll();
                },
                error => {
                    Swal.fire('Error al Guardar Entrega. Por favor, intentarlo de nuevo.', '', 'error');
                }
            );
        });
    }
  
    // eliminar una entrega programada
    deletedEntregaId(ids) {
        const data = [ids];
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
                this.pedidosService.DeletedEntregas(data).subscribe(
                resp=>{
                    this.getPurchaseOrder(this.idOrdenCompra);
                    Swal.fire(
                        'Entrega Eliminada Exitosamente!',
                        '',
                        'success'
                    )
                },
                error=>{
                    let msg = error;
                    Swal.fire(
                        'Error al Eliminar Entrega. Por favor, intentarlo de nuevo.',
                        '',
                        'error'
                    )
                });
            }
        })
    }
  
    // Enviar a Distribución
    SaveDistribucion(id) {
      const data =  Number(id);
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
          this.pedidosService.SendDistribucion(data).subscribe(
            resp=>{
              this.getPurchaseOrder(Number(this.idOrdenCompra));
              Swal.fire(
                'Entregas enviadas a Distribución con Éxito!',
                '',
                'success'
              )
            },
            error=>{
              let msg = error;
              Swal.fire(
                'Error al enviar las entrega. Por favor, intentarlo de nuevo.',
                '',
                'error'
              )
            }
          )
  
        }
      })
    }

    actionDataEdit(e: any, row){
        this.actionHandlerChangeCantidad(row);
    }
  
    actionDataEditKeyUp(article) {
      ++article.cantidad;
      this.actionHandlerChangeCantidad(article);
    }

    actionDataEditKeyDown(article, data) {
        if (data > 0) {
            --article.cantidad;
        }
        this.actionHandlerChangeCantidad(article);
    }

    dataEdit(e: any, row){
        row.cantidadPendiente = 0;
        row.cantidadPendiente = row.cantidadFaltanteGestionar - row.cantidadGestionar;
        this.handlerChangeCantidad(row);
    }
  
    dataEditKeyUp(article) {
      ++article.cantidadGestionar;
      this.handlerChangeCantidad(article);
    }
  
    dataEditKeyDown(article, data) {
      if (data > 0) {
        --article.cantidadGestionar;
      }
      this.handlerChangeCantidad(article);
    }
  
    focusNextField(i) {
      setTimeout(() => {
        if (i !== this.getArticulos.length - 1) {
          $('tr').eq(i + 2).find('td').eq(3).click();
        }else{
          $('tr').eq(1).find('td').eq(3).click();
        }
      });
    }
  
    handlerChangeCantidad(article) {
        if (article.cantidadGestionar > article.cantidadSolicitada) {
            article.cantidadGestionar = article.cantidadSolicitada;
            article.cantidadPendiente = 0;
            Swal.fire(
                'Por favor ingrese un valor menor a la cantidad solicitada.',
                `El artículo: "${article.nombreArticulo}" tinene una cantidad a gestionar superior la cantidad pendiente`,
                'warning'
            );
        }

        article.edited = true;
        this.checkButtonsDisability();
    }

    actionHandlerChangeCantidad(article) {
        if (article.cantidad > article.cantidadSolicitada) {
            article.cantidad = article.cantidadSolicitada;
            Swal.fire(
                'Por favor ingrese un valor menor a la cantidad solicitada.',
                `El artículo: "${article.nombreArticulo}" tinene una cantidad a gestionar superior la cantidad solicitada`,
                'warning'
            );
        }

        article.edited = true;
    }
    
}
