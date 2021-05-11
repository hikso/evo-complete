import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';
import { ActivatedRoute } from '@angular/router';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { generalParamNames } from 'src/app/config/global';
import { calendarFormat } from 'src/app/config/global';
import Swal from 'sweetalert2';
import * as moment from 'moment';

import { DecimalnumberPipe } from "src/app/shared/pipes/decimalnumber.pipe";

import { PedidosService } from 'src/app/core/services/pedidos.service';
import { SettingService } from 'src/app/core/services/setting.service';
import { CarsService } from 'src/app/core/services/cars.service';



declare var $: any;

export interface EntregaId {
  PedidoId: Number;
  FechaEntrega: String;
  HoraEntrega: String;
  [Detalles: number]: {
    DetallePedidoId: number;
  };
}

@Component({
  selector: 'app-editdeliveries',
  templateUrl: './editdeliveries.component.html',
  styleUrls: ['./editdeliveries.component.scss']
})
export class EditdeliveriesComponent implements OnInit {
  @ViewChild('dt', { static: true }) dt: Table;
  @ViewChild('pg', { static: true }) pg: Paginator;
  colu;
  columns: any[];
  columnsModal: any[];
  Id;
  es: any;
  getArticulos: any[];
  selectedItems: any[] = [];
  getPedido: any;
  pendientes;
  getEntregas;
  Eregular;
  calendarFormat = calendarFormat;
  Hora;
  Fecha;
  closeResult: string;
  motivos;
  motivoId: number;
  today: Date;
  tiposVehiculo;
  tipoVehiculo;
  peso: number;
  tipoVehiculoId;

  constructor(
    private actRoute: ActivatedRoute,
    private pedid: PedidosService,
    private carsService: CarsService,
    private setting: SettingService,
    private modalService: NgbModal,
    private decimalnumber: DecimalnumberPipe
  ) {
    this.getPedido = <any>{};
  }

  ngOnInit() {
    this.today = new Date();

    //encabezados de tabla
    this.columns = [
      { field: 'codigoPedido', header: 'Código Artículo', class: '', width: '5%' },
      { field: 'nombre', header: 'Nombre', class: '', width: '20%' },
      {
        field: 'cantidaAprobada',
        header: 'Cantidad Aprobada',
        class: 'text-center', width: '5%'
      },
      {
        field: 'cantidaPendiente',
        header: 'Cantidad Pendiente',
        class: 'text-center', width: '5%'
      },
      {
        field: 'cantidadentrega',
        header: 'Cantidad Entrega',
        class: 'text-center', width: '5%'
      },
      { field: '', header: 'Acciones', class: 'text-center', width: '5%' }
    ];

    //encabezados de tabla modal
    this.columnsModal = [
      { field: 'codigo', header: 'Código Articulo', class: '', width: '5%' },
      { field: 'nombre', header: 'Nombre', class: '', width: '20%' },
      {
        field: 'cantidadEntrega',
        header: 'Cantidad Entrega',
        class: 'text-center',
        width: '5%'
      },
      {
        field: 'cantidadPendiente',
        header: 'Cantidad Pendiente',
        class: 'text-center',
        width: '5%'
      }
    ];


    this.Id = this.actRoute.snapshot.paramMap.get('id');
    this.getEntregasId(this.Id);
    this.getArticulosPendientes(this.Id);
    this.Eregular = this.setting.getRegisterLocalStorage(
      generalParamNames.EXPRESION_REGULAR_ENTERO_DECIMAL
    );

  }

  getEntregasId(id) {
    this.pedid.getEntregasId(id).subscribe(
      resp => {
        resp['Detalles'].forEach((item) => {
          this.peso =+ Number(item['cantidadEntrega']);
        });
        this.getPedido = resp;
        this.getArticulos = resp['Detalles'];
        this.getArticulos.forEach(element => {
          element.cantidadEntrega = this.decimalnumber.transform(element.cantidadEntrega).replace(/,/, '');
          element.cantidaAprobada = parseFloat(element.cantidaAprobada);
          element.DeliveryPendiente = parseFloat(element.cantidadPendiente) + parseFloat(element.cantidadEntrega);
        });
        this.Fecha = this.getPedido.fechaEntrega;
        this.Hora = this.getPedido.horaEntrega;

      },
      error => {}
    );
  }

  getArticulosPendientes(id) {
    this.pedid.getArticulosPendientes(id).subscribe(resp => {
      this.pendientes = resp;
    });
  }

  // Obtener motivos para la edición
  // BR: son visibles unicamente cuando el estado de la esntrega
  // es Distribución
  getMotivos() {
    this.pedid.getMotivos().subscribe(resp => {
      this.motivos = resp;
    });
  }

  // Abri modal con informacion de fecha y hora para entrega;
  open(content) {
    this.modalService.open(content).result.then(
      result => {
        this.closeResult = `Closed with: ${result}`;
      },
      reason => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      }
    );

    this.carsService.getTypeCarsByWeight(this.peso).subscribe(resp => {
      this.tiposVehiculo = resp;
      this.tipoVehiculo = this.tiposVehiculo.find((e) =>{
          return e.TipoVehiculoId === this.getPedido.tipoVehiculoId
      });
    });
  }

  // cerrar modal detalle Auditoria
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  openEditModal(content) {
    this.modalService.open(content, { size: 'lg' }).result.then(
      result => {
        this.closeResult = `Closed with: ${result}`;
      },
      reason => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      }
    );
  }

  deletedArticulo(articulo) {
    const data = [articulo.detalleEntregaId];

    // verificación Eliminar
    Swal.fire({
      title: '¿Estás seguro?',
      text: '',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#47a44b',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Confirmar'
    }).then(result => {
      if (result.value) {
        console.log(articulo.detalleEntregaId);
        if (articulo.detalleEntregaId === 0) {
          this.getArticulos.find((article, i) => {
            if(article.codigo === articulo.codigo && article.detalleEntregaId === 0){
              this.pendientes.push(article);
              this.getArticulos.splice(i, 1);;
              return;
            }
          });
          return;
        }
        this.pedid.DeleteArticulo(articulo.detalleEntregaId).subscribe(
          resp => {
            this.getEntregasId(this.Id);
            this.getArticulosPendientes(this.Id);
            Swal.fire('Articulo Eliminado Exitosamente!', '', 'success');
          },
          error => {
            Swal.fire(
              'Error al Eliminar el articulo. Por favor, intentarlo de nuevo.',
              '',
              'error'
            );
          }
        );
      }
    });
  }

  changeDate(){
  this.getPedido.fechaEntrega =
    this.Fecha.length === undefined
      ? moment(this.Fecha).format('DD/MM/YYYY')
      : this.Fecha;
  this.getPedido.horaEntrega =
    this.Hora.length === undefined
      ? moment(this.Hora).format('HH:mm')
      : this.Hora;
  }

  save() {
    Swal.fire({
      title: '¿Estás seguro?',
      text: '',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#47a44b',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Confirmar'
    }).then(result => {
      if (result.value) {
        if (this.validateArticulos(this.getArticulos)) {
          return;
        }

        let fechaM =
          this.Fecha.length === undefined
            ? moment(this.Fecha).format('DD/MM/YYYY')
            : this.Fecha;
        let horaM =
          this.Hora.length === undefined
            ? moment(this.Hora).format('HH:mm')
            : this.Hora;

        this.tipoVehiculoId = this.tipoVehiculo ? this.tipoVehiculo.TipoVehiculoId : this.getPedido.tipoVehiculoId;

        this.pedid
          .saveEditEntrega({
            EntregaId: this.Id,
            FechaEntrega: fechaM,
            HoraEntrega: horaM,
            tipoVehiculoId: this.tipoVehiculoId,
            Articulos: this.getArticulos
          })
          .subscribe(
            resp => {
              this.getEntregasId(this.Id);
              Swal.fire('La entrega fue actualizada exitosamente!', '', 'success');
            },
            error => {
              console.log(error);
              Swal.fire('Error al actualizar la entrega. Por favor, intentarlo de nuevo.', '', 'error');
            }
          );
      }
    });
  }

  addItems() {
    this.selectedItems.forEach(item => {
      this.getArticulos.push({
        detalleEntregaId: 0,
        codigo: item.codigo,
        cantidadEntrega: 0,
        cantidadAprobada: item.cantidadAprobada,
        cantidadPendiente: item.cantidadPendiente,
        idEstadoArticulo: item.idEstadoArticulo,
        nombre: item.nombre
      });

      this.pendientes.find((article, i) => {
        if (article !== undefined) {
          if(article.codigo === item.codigo){
            this.pendientes.splice(i, 1);;
          }
        }
    });
    });
    this.modalService.dismissAll();
    this.selectedItems = [];
  }

  dataEdit(e: any, row){
    row.cantidadPendiente = 0;
    row.cantidadPendiente += row.DeliveryPendiente - row.cantidadEntrega;
    this.handlerChangeCantidad(row);
  }

  dataEditKeyUp(article){
    ++article.cantidadEntrega;
    this.handlerChangeCantidad(article);
  }

  dataEditKeyDown(article, data){
    if (data > 0) {
      --article.cantidadEntrega;
    }
    this.handlerChangeCantidad(article);
  }

  handlerChangeCantidad(articulo) {
    this.validateArticulos([articulo]);
    articulo.edited = true;
  }

  handlerChangeTipoVehiculo(e) {
    this.tipoVehiculoId = e.value.TipoVehiculoId;
  }

  validateArticulos(artiulos: any[]) {
    const wrongs = [];
    artiulos.forEach(item => {
      if (item.cantidadEntrega === 0 || item.cantidadEntrega === '') {
        Swal.fire('Error, la cantidad de entrega no puede ser vacía o igual a 0.', '', 'error');
        wrongs.push(item);
      } else if (item.detalleEntregaId === 0) {
          if (Number(item.cantidadEntrega) > Number(item.cantidadPendiente)) {
            item.cantidadEntrega = item.cantidadAprobada;
            Swal.fire('Error, la cantidad de entrega debe ser menor a la cantidad pendiente.', '', 'error');
            wrongs.push(item);
          }
      } else if (Number(item.cantidadEntrega) > Number(item.DeliveryPendiente)) {
        item.cantidadEntrega = parseFloat(item.DeliveryPendiente);
        item.cantidadPendiente = 0;
        item.cantidadPendiente += item.DeliveryPendiente - item.cantidadEntrega;
        Swal.fire('Error, la cantidad de entrega debe ser menor a la cantidad pendiente.', '', 'error');
        wrongs.push(item);
      }
    });
    return wrongs.length > 0;
  }

  focusNextField(i) {
    setTimeout(() => {
      if (i !== this.getArticulos.length - 1) {
        $('tr').eq(i + 2).find('td').eq(5).click();
      } else{
        $('tr').eq(1).find('td').eq(5).click();
      }
    });
  }

}
