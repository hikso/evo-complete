import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';
import Swal from 'sweetalert2';
import { FilterTable } from 'src/app/interface/filter-table';
import {NgbModal, ModalDismissReasons, NgbModalOptions} from '@ng-bootstrap/ng-bootstrap';
import { NgForm, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { DatePipe } from "@angular/common";
import { calendarFormat, generalParamNames } from 'src/app/config/global';

import { PedidosService } from 'src/app/core/services/pedidos.service';
import { SettingService } from 'src/app/core/services/setting.service';
import * as moment from 'moment';

declare var $: any;

export interface Articulos{
  codigo: string,
  idEstadoArticulo: number,
  cantidadEntrega: number,
  cantidadAprobada: number,
  cantidadPendiente: number,
  detalleEntregaId: number,
  nombre: string,
  isDeleted: boolean
}

export interface Entrega{
  MotivoID: number,
  EntregaId: number,
  FechaEntrega: string,
  HoraEntrega: string,
  Articulos: Articulos[]
}

@Component({
  selector: 'app-detalle-edit',
  templateUrl: './detalle-edit.component.html',
  styleUrls: ['./detalle-edit.component.scss']
})
export class DetalleEditComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  Id;
  delivery: any;
  articulos: Articulos[];
  maxR;
  maxregister;
  NumRegistro;
  filterTable: FilterTable;
  closeResult: string;
  calendarFormat = calendarFormat;
  motivos;
  motivo;
  Fecha;
  Eregular;
  Hora;
  today: Date;
  motivosArticulos;
  motivoEliminacionArticulos;
  motivosEdicionArticulos;
  articleSelected;
  articulosPendientes;
  columnsForPending;
  entregasToAdd;

  constructor(
    private actRoute: ActivatedRoute,
    private pedidosService: PedidosService, 
    private settingService: SettingService,
    private modalService: NgbModal) { }

  ngOnInit() {

    this.delivery = [];
    
    //encabezados de tabla
    this.columns=[
      {field: 'codigoPedido', header: 'Código Artículo', class: '', width: '5%'},
      {field: 'nombre', header: 'Nombre', class: '', width: '25%'},
      {field: 'cantidadAprobada', header: 'Cantidad aprobada', class:'text-right', width: '5%'},
      {field: 'cantidadPendiente', header: 'Cantidad pendiente', class:'text-right', width: '5%'},
      {field: 'cantidadEntrega', header: 'Cantidad entrega', class:'text-right', width: '5%'},
      {field: 'acciones', header: 'Acciones', class: 'text-center', width: '5%'}
    ];
    this.columnsForPending=[
      {field: 'codigoPedido', header: 'Código Artículo', class: '', width: '5%'},
      {field: 'nombre', header: 'Nombre', class: '', width: '20%'},
      {field: 'cantidadAprobada', header: 'Cantidad aprobada', class:'text-right', width: '5%'},
      {field: 'cantidadPendiente', header: 'Cantidad pendiente', class:'text-right', width: '5%'}
    ];
    this.Eregular = this.settingService.getRegisterLocalStorage(generalParamNames.EXPRESION_REGULAR_ENTERO_DECIMAL);

    this.Id = this.actRoute.snapshot.paramMap.get('id');
    this.getPedidoId(this.Id);
    this.getMotivos();
  }
  getMotivos(){
    this.settingService.getMotivos(2).subscribe(
      resp=>{
        this.motivosArticulos = resp;
        
      }
    );

    this.settingService.getMotivos(1).subscribe(
      resp=>{
        this.motivosEdicionArticulos = resp;
      }
    );
  }
  addArticlesToDelivery(){
    this.entregasToAdd.forEach(article => {
      const articlesToBeAdded: Articulos = {
        codigo: article.codigo,
        idEstadoArticulo: article.idEstadoArticulo,
        cantidadEntrega: 0,
        detalleEntregaId: undefined,
        cantidadAprobada: article.cantidadAprobada,
        cantidadPendiente: article.cantidadPendiente,
        nombre: article.nombre,
        isDeleted: false
      };
      this.articulos.push(articlesToBeAdded);
      this.articulosPendientes.find(({ codigo }, i) => {
        if(codigo === article.codigo){
          this.articulosPendientes.splice(i, 1);;
        }
      });
      this.modalService.dismissAll();
    });
    this.entregasToAdd = [];
  }
  //Get detalles del pedido con Id 
  // Estado == distribucion
  getPedidoId(id){
    this.pedidosService.getEntregasId(id).subscribe(
      resp=>{
        this.articulos = resp["Detalles"];
        this.articulos.forEach(e => {
          e.cantidadPendiente = e.cantidadAprobada - e.cantidadEntrega;
          e.cantidadEntrega = parseFloat(e.cantidadEntrega.toString());
          if(e.cantidadEntrega == 0){
            e.isDeleted = true;
          }
        });
        this.delivery = resp;
        this.Fecha = moment(this.delivery.fechaEntrega, "DD-MM-YYYY").toDate();
        this.Hora = moment(`${this.delivery.fechaEntrega.replace("/", "-").replace("/", "-")} ${this.delivery.horaEntrega}`, "DD-MM-YYYY HH:mm").toDate();
      }
    );
    this.pedidosService.getEntregasPendientes(id).subscribe(
      resp=>{
        this.articulosPendientes = resp;
      }
    );
  }


  deleteArticle(){
    if (this.motivoEliminacionArticulos === undefined) {
      Swal.fire(
        'Error.',
        'Debe seleccionar un motivo de eliminación.',
        'error'
      );
      return;
    }
    if (this.articleSelected.detalleEntregaId === undefined) {
      this.articulos.find((article, i) => {
        if(article.codigo === this.articleSelected.codigo && article.detalleEntregaId === undefined){
          this.articulosPendientes.push(article);
          this.articulos.splice(i, 1);;
          return;
        }
      });
      this.modalService.dismissAll();
      return;
    }
    const data = {
        MotivoId: this.motivoEliminacionArticulos.MotivoId,
        DetalleEntregaId: this.articleSelected.detalleEntregaId
    }
    this.pedidosService.deleteArticleAtDelivery(data).subscribe(
      resp => {
        if (resp) {
          Swal.fire(
            'Artículo Eliminado de la Entrega Exitosamente!',
            '',
            'success'
          );
          this.getPedidoId(this.Id);
          this.modalService.dismissAll(); 
        }
      },
      error => {
        Swal.fire(
           `Hubo un Error Eliminando Artículo.`,
          '',
          'error'
        );
      }
    );
  }

  aceptarActualizaEntrega(){

    // Error control
    let errors = [
      this.motivo === undefined && 'Motivo',
      this.Hora === null && 'Hora de entrega',
      this.Fecha === null && 'Fecha de entrega'
    ].filter(Boolean);

    if (errors.length) {

      Swal.fire(
        'Error al guardar la entrega',
        `Debe ingresar los siguientes campos: ${errors.join(', ')}`,
        'error'
      );
      return;
    }

    var datePipe = new DatePipe("en-ES");

    const articles = this.articulos.filter(function(item){
      return item.cantidadEntrega > 0;
    });

    const entrega: Entrega = {
      MotivoID: this.motivo.MotivoId,
      EntregaId: this.Id,
      FechaEntrega: datePipe.transform(this.Fecha, "dd/MM/yyyy"),
      HoraEntrega: datePipe.transform(this.Hora, "HH:mm"),
      Articulos: articles
    }
    this.pedidosService.updateDelivery(entrega).subscribe(
      resp=>{
        if (resp) {
          Swal.fire(
            '¡Entrega actualizada correctamente!',
            '',
            'success'
          );
          this.getPedidoId(this.Id);
          this.modalService.dismissAll();
        }
      },
      error=>{
        let msg = error;
        Swal.fire(
          'Ha ocurrido un error al actualizar la entrega.',
          error.error,
          'error'
        )
      }
    );
  }

  //Open a modal with it's content
  openModal(content, size) {
    this.modalService.open(content, {size: size} );
  }


  dataEdit(e: any, article, data){
    this.handlerChangeCantidad(article);
  }

  dataEditKeyUp(article){
    ++article.cantidadEntrega;
    this.handlerChangeCantidad(article);
  }

  dataEditKeyDown(article, data){
    if (data > 0) {
      --article.cantidadEntrega;
    }
  }

  focusNextField(i){
    setTimeout(() => {
      if (i !== this.articulos.length - 1) {
        $('tr').eq(i + 2).find('td').eq(4).click();
      }else{
        $('tr').eq(1).find('td').eq(4).click();
      }
    });
  }

  handlerChangeCantidad(article) {
    if (parseFloat(article.cantidadEntrega) > parseFloat(article.cantidadAprobada)) {
      article.cantidadEntrega = article.cantidadAprobada;
      Swal.fire(
        "Por favor ingrese un valor menor a la cantidad pendiente.",
        "",
        "warning"
      );
    }
    article.edited = true;
  }
}
