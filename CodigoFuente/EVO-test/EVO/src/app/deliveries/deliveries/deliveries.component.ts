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
declare var $: any;

export interface getArticulos{
  readonly length: number;
  DetallePedidoId:number;
  Codigo: String,
  Nombre: String,
  Estado: String,
  UnidadMedida: number,
  CantidadAprobada: number,
  CantidadEntrega: number,
  Pendiente: number,
  DeliveryPendiente: number,
  HasPending: Boolean
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
  selector: 'app-deliveries',
  templateUrl: './deliveries.component.html',
  styleUrls: ['./deliveries.component.scss']
})
export class DeliveriesComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  Id;
  closeResult: string;
  validNumberType: boolean = false;
  type: FormGroup;
  columns;
  columnsPedido;
  getArticulos: getArticulos[];
  getPedido: any;
  getEntregas;
  getEntregasIds;
  EntregaId: EntregaId;
  maxR;
  maxregister;
  NumRegistro;
  Eregular;
  totalWeightPendingForDelivery;
  totalE;
  btnDistr: boolean;
  btnEntreg: boolean;
  EntregasEnd: boolean;
  visibility: boolean;
  state: boolean;
  numEntr: number;
  Fecha: Date;
  Hora: Date;
  calendarFormat = calendarFormat;
  noAutorizado: boolean;
  today: Date;
  tiposVehiculo;
  tipoVehiculo;
  peso = 0;
  tipoVehiculoId;

  constructor(
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private pedid: PedidosService,
    private carsService: CarsService,
    private actRoute: ActivatedRoute,
    private setting: SettingService) {
      this.getPedido = <any>{};
      this.EntregaId = <EntregaId>{};
  }

  ngOnInit() {
    this.noAutorizado = true;
    this.btnDistr = true;
    this.btnEntreg = true;
    this.EntregasEnd = true;
    this.visibility = true;
    this.numEntr = 0;
    this.totalWeightPendingForDelivery = 0;
    this.totalE = 0;

    // encabezados de tabla entregas
    this.columnsPedido = [
      {field: 'codigo', header: 'Código Artículo', class: '', width: '5%'},
      {field: 'nombre', header: 'Nombre', class: '', width: '25%'},
      {field: 'estado', header: 'Estado', class: '', width: '5%'},
      {field: 'cantidadaprobada', header: 'Cantidad Aprobada',  class: 'text-right', width: '5%'},
      {field: 'cantidadentrega', header: 'Cantidad Entrega',  class: 'text-right', width: '5%'},
      {field: 'pendiente', header: 'Cantidad Pendiente',  class: 'text-right', width: '5%'},
    ];

    // encabezados de tabla entregas
    this.columns = [
      {field: 'codigoPedido', header: 'Código Artículo', class: '', width: '5%'},
      {field: 'nombre', header: 'Nombre', class: '', width: '25%'},
      {field: 'cantidadentrega', header: 'Cantidad Entrega', class: 'text-right', width: '5%'},
    ];

    this.today = new Date();

    this.Id = this.actRoute.snapshot.paramMap.get('id');
    this.getEntregasId(this.Id);
    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.Eregular = this.setting.getRegisterLocalStorage(generalParamNames.EXPRESION_REGULAR_ENTERO_DECIMAL);

  }

  // Detalle de las entregas del pedido
  getEntregasId(id) {
    this.pedid.getEntregas(id).subscribe(
      resp => {
        console.log(resp);
        this.getPedido = resp;
        this.getArticulos = resp["Articulos"];
        this.getEntregas = resp["Entregas"];
        this.maxR = this.getArticulos.length;
        this.totalArticulos();
        this.visible();
      },
      error => {}
    )
  }

  //total de los articulos sin modificación
  totalArticulos() {
    // var pendiente = 0;
    let totalArticlesEnded = 0;
    this.getArticulos.map(article => {
      let pending = article.CantidadAprobada;
      this.getEntregas.forEach(function(delivery){
        delivery.Detalles.forEach(function(detail) {
          if(detail["DetallePedidoId"] == article["DetallePedidoId"] ){
            pending = pending - detail["Cantidad"];
          }
        });
      });
      article.HasPending = true;
      if (pending == 0) {
        totalArticlesEnded++;
        article.HasPending = false;
      }
      this.totalWeightPendingForDelivery += pending;
      article.DeliveryPendiente = pending;
      article.CantidadEntrega = article.DeliveryPendiente;
      article.Pendiente = 0;
      article.Pendiente += article.DeliveryPendiente - article.CantidadEntrega;
    });

    if(this.getArticulos.length <= totalArticlesEnded){ // se terminaron los articulos
      this.EntregasEnd = false;
      this.btnDistr = false;
      this.noAutorizado = false;
    }else{//faltan articulos
      this.EntregasEnd = true;
      this.btnDistr = true;
    }

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
    this.btnEntreg = false;

    for (let i = 0; i < this.getArticulos.length; i++) {
      totalWeightForDelivery += this.getArticulos[i].CantidadEntrega;
    }

    this.btnEntreg = totalWeightForDelivery === 0;
  }

  // Abri modal con informacion de fecha y hora para entrega;
  open(content) {
    this.modalService.open(content).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      this.clearModal();
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      this.clearModal();
    });

    this.carsService.getTypeCarsByWeight(this.peso).subscribe(resp => {
      this.tiposVehiculo = resp;
    });
  }

  clearModal(){
    this.Fecha = null;
    this.Hora = null;
    this.tipoVehiculo = null;
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

  // Agregar Entregas
  AddEntregas() {
    this.showVerificationAlert().then(result => {
      if (result.value) {
        const datePipe = new DatePipe('en-ES');
        const fff = datePipe.transform(this.Fecha, 'dd/MM/yyyy');  // formato de fecha para backend
        const hh = datePipe.transform(this.Hora, 'HH:mm'); // formato de hora para backend
        const dataRegister = [];

        // Error control
        let errors = [
          this.tipoVehiculoId === undefined && 'Tipo Vehiculo',
          hh === null && 'Hora de entrega',
          fff === null && 'Fecha de entrega'
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

          if (this.getArticulos[i].CantidadEntrega > this.getArticulos[i].DeliveryPendiente) {
            Swal.fire(
              'Cambiar cantidad a entregar.',
              'La cantidad a entregar supera la cantidad pendiente',
              'error'
            )
            this.Fecha = null;
            this.Hora = null;
            this.modalService.dismissAll();
            return;
          }

          if (this.getArticulos[i].CantidadEntrega > 0
            && this.getArticulos[i].CantidadEntrega != undefined ) {
            dataRegister.push( {
              'DetallePedidoId': this.getArticulos[i].DetallePedidoId,
              'Cantidad': this.getArticulos[i].CantidadEntrega,
            });
          }

          // disminuir a pendiente la cantidad agregada
          this.getArticulos[i].Pendiente = this.getArticulos[i].DeliveryPendiente - this.getArticulos[i].CantidadEntrega;
        }

        const data = [{
          "PedidoId": Number(this.Id),
          "FechaEntrega": fff,
          "HoraEntrega": hh,
          "TipoVehiculoId": this.tipoVehiculoId,
          "Detalles": dataRegister
        }];

        this.pedid.AddEntregas(data).subscribe(
          resp => {
            this.getEntregasId(this.Id);
            this.btnEntreg = true;
            Swal.fire('Entrega agregada Exitosamente!', '', 'success');
            this.Fecha = null;
            this.Hora = null;
            this.modalService.dismissAll();
          },
          error => {
            Swal.fire('Error al Guardar Entrega. Por favor, intentarlo de nuevo.', '', 'error');
          }
        );
      }
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
        this.pedid.DeletedEntregas(data).subscribe(
          resp=>{
            this.getEntregasId(this.Id);
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
          }
        )

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
        this.pedid.SendDistribucion(data).subscribe(
          resp=>{
            this.getEntregasId(Number(this.Id));
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

  // habilitar btn para agregar entregas
  // BR: Si el estado es abierto no permite agregar pedido ni
  // visualizar información
  visible() {
    if(this.getPedido.Estado === "Abierto"){
      this.visibility = false;
      this.EntregasEnd = false;
      this.noAutorizado = true;

    }else if(this.getPedido.Estado === "Aceptado parcial" || this.getPedido.Estado === "Aceptado"){
      this.state = true;
      this.noAutorizado = false;

    }else if(this.getPedido.Estado === "Distribución"){
      this.state = false;
      this.EntregasEnd = false;
      this.noAutorizado = false;

    }else{
      this.state= false;
      this.noAutorizado = false;
    }

  }

  dataEdit(e: any, row){
    row.Pendiente = 0;
    row.Pendiente += row.DeliveryPendiente - row.CantidadEntrega;
    this.handlerChangeCantidad(row);
  }

  dataEditKeyUp(article) {
    ++article.CantidadEntrega;
    this.handlerChangeCantidad(article);
  }

  dataEditKeyDown(article, data) {
    if (data > 0) {
      --article.CantidadEntrega;
    }
    this.handlerChangeCantidad(article);
  }

  focusNextField(i) {
    setTimeout(() => {
      if (i !== this.getArticulos.length - 1) {
        $('tr').eq(i + 2).find('td').eq(4).click();
      }else{
        $('tr').eq(1).find('td').eq(4).click();
      }
    });
  }

  handlerChangeCantidad(article) {
    if (article.CantidadEntrega > article.DeliveryPendiente) {
      article.CantidadEntrega = article.DeliveryPendiente;
      article.Pendiente = 0;
      article.Pendiente += article.DeliveryPendiente - article.CantidadEntrega;
      Swal.fire(
        "Por favor ingrese un valor menor a la cantidad aprobada.",
        "",
        "warning"
      );
    }
    this.peso = 0;
    for (let i = 0; i < this.getArticulos.length; i++) {
      this.peso += this.getArticulos[i].CantidadEntrega;
    }
    article.edited = true;
    this.checkButtonsDisability();
  }

  handlerChangeTipoVehiculo(e) {
    this.tipoVehiculoId = e.value.TipoVehiculoId;
  }
}
