import { Component, OnInit, ViewChild } from '@angular/core';
import {NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { PedidosService } from '../../core/services/pedidos.service';
import { SettingService } from '../../core/services/setting.service';
import Swal from 'sweetalert2';
import { ActivatedRoute } from '@angular/router';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';
import { calendarFormat, generalParamNames } from '../../config/global';
import { Accordion } from 'primeng/accordion';
import { relativeTimeRounding } from 'moment';

declare var $: any;

export interface getArticulos{
    readonly length: number;
    /**
     * ID del artículo detalle en el pedido
     */
    detallePedidoId: number;
    /**
     * Código del artículo
     */
    codigoArticulo: String,
    /**
     * Nombre del artículo
     */
    nombreArticulo: String,
    /**
     * Estado del artículo
     */
    Estado: String,
    /**
     * Unidad de medida del artículo
     */
    UnidadMedida: number,
    /**
     * Cantidad solicitada del artículo
     */
    cantidadSolicitada: number,
    /**
     * La cantidad total que se ha gestionado
     */
    cantidadGestionar: number,
    /**
     * Cantidad que se encuentra pendiente de gestionar
     */
    Pendiente: number,
    /**
     * Pendiente a Gestionar en la entrega mientras el usuario realiza cambio de cantidades
     */
    cantidadPendiente: number,
    /**
     * Me indica si aún hay pendiente por gestionar
     */
    HasPending: Boolean,
    /**
     * Stock que viene de sap y me indica en almacen cuanto hay
     */
    stockAlmacen: number,
    /**
     * Cantidad faltante por gestionar
     */
    cantidadFaltanteGestionar: number,

    stockAlmacenBackUp: number
}

export interface ArticulosGestionados{
    cantidad: number,
    cantidadGestionada: number,
    cantidadFaltanteGestionar: number,
    cantidadSolicitada: number,
    codigoArticulo: string,
    detallePedidoId: number
    nombreArticulo: string,
    observaciones: string,
    ordenCompra: string,
    stockAlmacen: number,
    unidadMedida: string,
    edited: boolean,
    stockAlmacenBackUp: number
}

export interface getAcciones{
    accionId: number,
    articulos: ArticulosGestionados[],
    nombreAccion: string,
    fieldName: string
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
    columns;
    columnsPedido;
    getArticulos: getArticulos[];
    getPedido: any;
    acciones: any;
    accionesBackUp: any;
    accion: any;
    selectedItems: any;
    addWithoutStockItems: any;
    addWithStockItems: any;
    isAnyWithoutStock: boolean;
    isAnyWithStock: boolean;
    getAcciones: getAcciones[];
    getEntregasIds;
    maxR;
    maxregister;
    NumRegistro;
    Eregular;
    totalWeightPendingForDelivery;
    totalE;
    btnDistr: boolean;
    buttonSelectAction: boolean;
    buttonCleanEnable: boolean;
    EntregasEnd: boolean;
    visibility: boolean;
    state: boolean;
    numEntr: number;
    maximoDecimales: number;
    accionIdAddItems: number;
    Fecha: Date;
    Hora: Date;
    calendarFormat = calendarFormat;
    noAutorizado: boolean;
    today: Date;
    tiposVehiculo;
    tipoVehiculo;
    peso = 0;
    tipoVehiculoId;
    pendientes: any;
    columnsModal: any[];
  
    constructor(private modalService: NgbModal, private pedidosService: PedidosService,
                private actRoute: ActivatedRoute, private setting: SettingService) {
            this.getPedido = <any>{};
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
            {field: 'codigoArticulo', header: 'Código Artículo', class: '', width: '10%', showOnManagment: false, hiddeOnEdit: false},
            {field: 'nombre', header: 'Nombre', class: '', width: '20%', showOnManagment: false, hiddeOnEdit: false},
            {field: 'cantidadSolicitada', header: 'Cantidad Solicitada', class: '', width: '10%', showOnManagment: false, hiddeOnEdit: false},
            {field: 'cantidadGestionar', header: 'Cantidad a Gestionar',  class: 'text-right', width: '10%', showOnManagment: false, hiddeOnEdit: false},
            {field: 'stockAlmacen', header: 'Stock Almacén',  class: 'text-right', width: '10%', showOnManagment: false, hiddeOnEdit: false},
            {field: 'ordenCompra', header: 'Orden de Compra',  class: 'text-right', width: '10%', showOnManagment: true, hiddeOnEdit: false},
            {field: 'observaciones', header: 'Observaciones',  class: 'text-right', width: '18%', showOnManagment: false, hiddeOnEdit: false},
            {field: 'acciones', header: 'Acciones', class: 'text-center', width: '6%', showOnManagment: false, hiddeOnEdit: true}
        ];  
        
        //encabezados de tabla modal
        this.columnsModal = [
            { field: 'codigo', header: 'Código Articulo', class: '', width: '5%' },
            { field: 'nombre', header: 'Nombre', class: '', width: '10%' },
            {
                field: 'cantidadEntrega',
                header: 'Cantidad Solicitada',
                class: 'text-center',
                width: '5%'
            },
            {
            field: 'cantidadPendiente',
            header: 'Cantidad a Gestionar',
            class: 'text-center',
            width: '5%'
            },
            {
            field: 'stockAlmacen',
            header: 'Stock Almacen',
            class: 'text-center',
            width: '5%'
            },
            {
            field: 'observaciones',
            header: 'Observaciones',
            class: 'text-center',
            width: '5%'
            }
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
                    article.stockAlmacen = Number(Number(article.stockAlmacen).toFixed(this.maximoDecimales));
                    article.stockAlmacenBackUp = Number(Number(article.stockAlmacen).toFixed(this.maximoDecimales));
                });

                this.getAcciones.forEach((accion) => {
                    accion.articulos.map((article) => {
                        article.cantidad = Number(Number(article.cantidad).toFixed(this.maximoDecimales));
                        article.cantidadGestionada = article.cantidad;
                        article.cantidadFaltanteGestionar = Number(Number(article.cantidadFaltanteGestionar).toFixed(this.maximoDecimales));
                        article.cantidadSolicitada = Number(Number(article.cantidadSolicitada).toFixed(this.maximoDecimales));
                        article.stockAlmacen = Number(Number(article.stockAlmacen).toFixed(this.maximoDecimales));
                        article.stockAlmacenBackUp = Number(Number(article.stockAlmacen).toFixed(this.maximoDecimales));
                    });
                });
                
                this.totalArticulos();
            }
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

            article.cantidadGestionar = article.stockAlmacenBackUp > 0 &&
            article.cantidadFaltanteGestionar > article.stockAlmacenBackUp ? article.stockAlmacenBackUp : article.cantidadFaltanteGestionar;
            article.stockAlmacen = article.stockAlmacenBackUp - article.cantidadGestionar;
            if (article.stockAlmacen <= 0) {
                article.stockAlmacen = 0;
            }
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
                    accion.fieldName = 'Cantidad a Gestionar';
                    break;
                case 2:
                case 3:
                    accion.fieldName = 'Cantidad a Gestionar';
                    break;
            }

            accion.articulos.map(article => {
                article.stockAlmacen = article.stockAlmacenBackUp - article.cantidadGestionada;
                if (article.stockAlmacen <= 0) {
                    article.stockAlmacen = 0;
                }
            });
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

        this.buttonCleanEnable = !Object.values<any>(this.getAcciones)
        .some(x => (x.articulos.length > 0));
    }

    getMotivos(){
        this.pedidosService.getAcciones().subscribe(
            resp=>{
                this.acciones = resp;
                this.accionesBackUp = this.acciones.map(a => ({...a}));
            }
        );
    }

    // Abri modal asociación acción de gestion de compra
    open(content) {
        this.acciones = this.accionesBackUp;

        this.isAnyWithoutStock = Object.values<getArticulos>(this.getArticulos)
        .some(x => (x.stockAlmacenBackUp <= 0 && x.cantidadGestionar > 0));
        
        this.isAnyWithStock = Object.values<getArticulos>(this.getArticulos)
        .some(x => (x.stockAlmacenBackUp > 0 && x.cantidadGestionar > 0));

        if (this.isAnyWithoutStock) {
            this.acciones = this.acciones.filter(x => x.AccionId !== 1);
        }
        
        if (!this.isAnyWithoutStock && this.isAnyWithStock) {
            this.acciones = this.acciones.filter(x => x.AccionId === 1);
        }

        this.addWithoutStockItems = this.getArticulos.filter(x => x.stockAlmacenBackUp <= 0 && x.cantidadGestionar > 0);
        this.addWithStockItems = this.getArticulos.filter(x => x.stockAlmacenBackUp > 0 && x.cantidadGestionar > 0);

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
        this.isAnyWithoutStock = null;
        this.addWithoutStockItems = null;
        this.addWithStockItems = null;
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

            
            this.pedidosService.cleanPurchaceDocument(this.idOrdenCompra).subscribe(
                resp => {
                    this.getPurchaseOrder(this.idOrdenCompra);
                    Swal.fire('El Documento se ha Limpiado!', '', 'success');
                },
                error => {
                    Swal.fire('Error al limpiar documento. Por favor, intentarlo de nuevo.', '', 'error');
                }
            );

            this.ngOnInit();
        });
    }


    finalizarDocumento(){
        this.showVerificationAlert().then(accept => {
            if (!accept.value) return;
            let stop = false;
            const dataRegister: Array<any> = [];
            this.getAcciones.forEach(accion => {
                accion.articulos.forEach(articulo => {
                    if([2,3].includes(accion.accionId)){
                        const ShouldHaveOrder = this.setting.getRegisterLocalStorage(generalParamNames.GUARDAR_GESTION_COMPRA_CON_ORDENES);
                        if (articulo.ordenCompra === null && ShouldHaveOrder.valor === "true") {
                            Swal.fire(
                                'Error al finalizar el documento',
                                `El artículo: ${articulo.nombreArticulo} en la acción ${accion.nombreAccion} debe tener una orden de compra.`,
                                'error'
                            );
                            stop = true;
                        }
                    }
                    dataRegister.push( {
                        'detallePedidoId': articulo.detallePedidoId,
                        'cantidadGestionar': articulo.cantidad,
                        'accionId': accion.accionId
                    });
                });
            });
            if (stop) return;
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
                    Swal.fire(
                        'Error al finalizar documento. Por favor, intentarlo de nuevo.',
                        error.error, 
                        'error');
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
                    dataRegister.push( {
                        'detallePedidoId': articulo.detallePedidoId,
                        'cantidadGestionar': articulo.cantidad,
                        'accionId': accion.accionId
                    });
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
            let articlesToManage = [];
            if (this.isAnyWithoutStock) {
                articlesToManage = this.addWithoutStockItems;
            } else {
                articlesToManage = this.addWithStockItems;
            }
            // Armar array de entregas
            for (let i = 0; i < articlesToManage.length; i++) {
                var isRepeated = [];
                this.getAcciones.forEach((accion) => {
                    //ID 2 y 3, donde los artículos no pueden reperirse
                    if ([2,3].includes(accion.accionId) && isRepeated.length === 0) {
                        if (accion.accionId != this.accion.AccionId) {    
                            isRepeated = accion.articulos.filter(article => {
                                return articlesToManage[i].codigoArticulo === article.codigoArticulo;
                            });
                        }
                    }
                });
                if (isRepeated.length > 0) {
                    Swal.fire(
                        'Error al gestionar un artículo, ya se gestionó en otra acción',
                        `El artículo: ${articlesToManage[i].nombreArticulo} ya ha sido asociado a otra acción`,
                        'error'
                    );
                    continue;
                }
                if (articlesToManage[i].cantidadGestionar > articlesToManage[i].cantidadFaltanteGestionar) {
                    
                    Swal.fire(
                        'Error con las cantidades a gestionar',
                        `El artículo: ${articlesToManage[i].nombreArticulo} tinene una cantidad a gestionar superior la cantidad pendiente`,
                        'error'
                    )
                    this.modalService.dismissAll();
                    return;
                }

                if (articlesToManage[i].cantidadGestionar > 0
                    && articlesToManage[i].cantidadGestionar != undefined ) {
                    dataRegister.push( {
                        'detallePedidoId': articlesToManage[i].detallePedidoId,
                        'codigoArticulo': articlesToManage[i].nombreArticulo,
                        'cantidadGestionar': articlesToManage[i].cantidadGestionar,
                        'stockActual': articlesToManage[i].stockAlmacen
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
            
            this.acciones = this.accionesBackUp;
            if (this.addWithStockItems.length > 0) {
                this.acciones = this.acciones.filter(x => x.AccionId === 1);
            }
            if (dataRegister.length === 0) {
                if (!this.isAnyWithoutStock || this.addWithStockItems.length === 0) {
                    this.modalService.dismissAll();
                } else {
                    this.isAnyWithoutStock = false;
                }
                return;
            }
            this.pedidosService.AddGestion(data).subscribe(
                resp => {
                    this.getPurchaseOrder(this.idOrdenCompra);
                    this.buttonSelectAction = true;
                    Swal.fire('Tipo de gestión agregada correctamente!', '', 'success');

                    if (!this.isAnyWithoutStock || this.addWithStockItems.length === 0) {
                        this.modalService.dismissAll();
                    } else {
                        this.isAnyWithoutStock = false;
                    }
                },
                error => {
                    Swal.fire('Error al Guardar Gestión. Por favor, intentarlo de nuevo.', error.error, 'error');
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
                        'Artículo Eliminado Exitosamente!',
                        '',
                        'success'
                    )
                },
                error=>{
                    let msg = error;
                    Swal.fire(
                        'Error al Eliminar Artículo. Por favor, intentarlo de nuevo.',
                        '',
                        'error'
                    )
                });
            }
        })
    }
  
    // Enviar a Distribución
    SaveDistribucion(id): void {
        const data = Number(id);

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
                this.pedidosService.SendDistribucion(data).subscribe((resp)=>{
                    this.getPurchaseOrder(Number(this.idOrdenCompra));
                    Swal.fire(
                        'Entregas enviadas a Distribución con Éxito!',
                        '',
                        'success'
                    )
                },
                error=>{
                    Swal.fire(
                        'Error al enviar las entrega. Por favor, intentarlo de nuevo.',
                        error,
                        'error'
                    )
                })
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
  
    /**
     * Control de cambios de cantidades para articulos sin ser gestionados
     * @param article articulo que presenta cambios
     */
    handlerChangeCantidad(article) {
        let cantidadLimite = article.cantidadFaltanteGestionar;
        if (article.stockAlmacenBackUp > 0 && article.stockAlmacenBackUp < article.cantidadFaltanteGestionar) {
            cantidadLimite = article.stockAlmacenBackUp;
        }

        article.stockAlmacen = article.stockAlmacenBackUp - article.cantidadGestionar;
        if (article.stockAlmacen <= 0) {
            article.stockAlmacen = 0;
        }
        
        if (article.cantidadGestionar > cantidadLimite) {
            article.cantidadGestionar = cantidadLimite;
            article.cantidadPendiente = 0;
            if (article.stockAlmacenBackUp > 0) {
                Swal.fire(
                    'Por favor ingrese un valor menor a el Stock Almacen.',
                    `El artículo: "${article.nombreArticulo}" tinene una cantidad a gestionar superior la cantidad disponible almacen`,
                    'warning'
                );
            } else {
                Swal.fire(
                    'Por favor ingrese un valor menor a la cantidad solicitada.',
                    `El artículo: "${article.nombreArticulo}" tinene una cantidad a gestionar superior la cantidad pendiente`,
                    'warning'
                );
            }
        }

        article.edited = true;
        this.checkButtonsDisability();
    }

    /**
     * Control de cambios de cantidades para articulos dentro de una accion
     * @param article Artículo que presenta cambios
     */
    actionHandlerChangeCantidad(article) {
        let cantidadLimite  = 
        article.cantidadGestionada + article.cantidadFaltanteGestionar;

        if (article.stockAlmacenBackUp > 0) {
            cantidadLimite = article.stockAlmacenBackUp;
        }
        
        article.stockAlmacen = article.stockAlmacenBackUp - article.cantidad;
        if (article.stockAlmacen <= 0) {
            article.stockAlmacen = 0;
        }
        if (article.cantidad > cantidadLimite) {
            article.cantidad = cantidadLimite;
            if (article.stockAlmacenBackUp > 0) {
                Swal.fire(
                    'Por favor ingrese un valor menor a el Stock Almacen.',
                    `El artículo: "${article.nombreArticulo}" tinene una cantidad a gestionar superior la cantidad disponible almacen`,
                    'warning'
                );
            } else {
                Swal.fire(
                    'Por favor ingrese un valor menor a la cantidad solicitada.',
                    `El artículo: "${article.nombreArticulo}" tinene una cantidad a gestionar superior la cantidad pendiente`,
                    'warning'
                );
            }
        }

        article.edited = true;
    }

    /**
     * Elimina el artículo que se encontraba gestionado
     * @param articulo articulo a eliminar
     * @param accion accion de la que se eliminará el artículo
     */
    eliminarArticulo(articulo, accion) {
        this.showVerificationAlert().then(accept => {
            if (!accept.value) return;

            this.pedidosService.eliminarArticulo(articulo.detallePedidoId, accion.accionId).subscribe(
                resp => {
                    this.getPurchaseOrder(this.idOrdenCompra);
                    Swal.fire('El Artículo se ha Eliminado!', '', 'success');
                },
                error => {
                    Swal.fire('Error al eliminar artículo. Por favor, intentarlo de nuevo.', '', 'error');
                }
            );

            this.ngOnInit();
        });
        
    }

    /**
     * Abre el modal de edición de artículos pendientes
     * @param content contenido del modal
     * @param accionId Id de la acción a editar
     */
    openEditModal(content, accionId): void {
        this.accionIdAddItems = accionId;
        this.pedidosService.getArticulosPendientesGestion(this.idOrdenCompra, accionId).subscribe(
            resp => {
                this.pendientes = resp;
                this.modalService.open(content, { size: 'lg' }).result.then(
                    result => {
                      this.closeResult = `Closed with: ${result}`;
                    },
                    reason => {
                      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
                    }
                  );
            }
        )
    }

    /**
     * Agrega los items seleccionados a la acción en edición 
     */
    addItemsToAction(): void {
        this.getAcciones.forEach(accion => {
            if (accion.accionId === this.accionIdAddItems) {
                this.selectedItems.forEach(element => {
                    const selectedItem: ArticulosGestionados = {
                        cantidad: element.cantidadGestionar,
                        cantidadGestionada: element.cantidadGestionar,
                        cantidadFaltanteGestionar:  element.cantidadGestionar,
                        cantidadSolicitada:  element.cantidadSolicitada,
                        codigoArticulo: element.codigoArticulo,
                        detallePedidoId: element.detallePedidoId,
                        nombreArticulo: element.nombre,
                        observaciones: element.observaciones,
                        ordenCompra: "",
                        stockAlmacen: element.stockAlmacen,
                        unidadMedida: element.unidadMedida,
                        stockAlmacenBackUp: element.stockAlmacen,
                        edited: true
                    };

                    accion.articulos.push(selectedItem);
                });
            }
        });
    }
    
    
}
