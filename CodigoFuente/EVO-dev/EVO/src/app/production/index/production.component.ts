import { Component, OnInit, ViewChild } from '@angular/core';
import { LazyLoadEvent, Paginator } from 'primeng/primeng';
import {NgbModal, ModalDismissReasons, NgbModalOptions} from '@ng-bootstrap/ng-bootstrap';
import { Table } from 'primeng/table';
import { PedidosService } from '../../core/services/pedidos.service';
import { SettingService } from '../../core/services/setting.service';
import { NgForm, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { CarsService } from 'src/app/core/services/cars.service';
import Swal from 'sweetalert2';
import { generalParamNames, calendarFormat } from 'src/app/config/global';
import * as moment from 'moment';


export interface filterTable {
  codigoPedido: String,
  ordenCompra: String,
  fechaSolicitud: String,
  estado: String,
  cliente: String,
  entregas: String
}

export interface formV {
  tipo: number,
  placa: number,
  muelle: string,
  nuevo: boolean,
  conductor: number,
  auxiliar: number,
}

export interface vehiculos{
  vehiculoId: number,
  conductorId: number,
  auxiliarId: number,
  entregasIds: any[],
  nuevoViaje: boolean,
  MuelleId: number
}

@Component({
  selector: 'app-production',
  templateUrl: './production.component.html',
  styleUrls: ['./production.component.scss']
})
export class ProductionComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  @ViewChild('fileUpload', {static: true}) fileUpload: any;

  columns: any[];
  tipo: any;
  placa: any;
  conductor: any[];
  auxiliar: any[];
  transporte: any;
  vehiculo: formV;
  distribucion;
  maxregister;
  NumRegistro;
  filterTable: filterTable;
  from: number;
  to: number;
  calendarFormat = calendarFormat;
  totalRow: number = 0;
  maxR = 0;
  numFilas = 0;
  nameCol;
  contentCol;
  closeResult: string;
  form: FormGroup;
  addEntregas: any[] = [];
  enableCars: boolean;
  AddVehiculo: vehiculos;
  addCars: boolean;
  muelles;
  todayDate = new Date();
  initDate;
  endDate;
  files: any;
  today = new Date();

  constructor(
    private setting: SettingService, 
    private pedid: PedidosService, 
    private modalService: NgbModal, 
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.columns =[
      {field: 'fechaCarga', header: 'Fecha Carga Archivo', class: 'columnC'},
      {field: 'fechaInicial', header: 'Fecha Inicial', class:''},
      {field: 'fechaFinal', header: 'Fecha Final', class:''},
      {field: 'archivo', header:'Archivo', class:''},
    ]

    this.getAllDistribucion();
  }

  // Método para obtener el tamaño de registro e invocar la 
  // método para el llamado de las entregas
  getAllDistribucion(){
    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.maxR = Number(this.NumRegistro.valor);

    const data = {
        desde: 1,
        hasta: this.maxR,
        filtro: <filterTable>{}
    }
  
    this.pedid.getFilesByFilter(data).subscribe(files=>{
        this.files = files;
    });
  }

  // Método para el llamado de todas las entregas vigentes
  // from: Número que indica el minimo de registro para la consulta
  // to: Número que indica el maximo de registros para la consulta
  getFromToPedidos(from, to){
    this.pedid.getAllDistribucion(from, to).subscribe(
      resp=>{
        this.distribucion = resp["registros"];
        this.totalRow = resp["numeroTotalRegistros"];
        this.maxregister = [
          {name: to},
          {name: 5 },
          {name: 10 },
          {name: 25 },
          {name: 50 },
          {name: 100 }
        ];
        this.numPage(from, to, this.totalRow);
      }
    )
  }

  // Calcular Numero de registros por página
  // from: Número que indica el minimo de registro de la consulta
  // to: Número que indica el maximo de registros de la consulta
  // total: Número total de registro de la consulta
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
    
    const filter = this.filterTable; //variable tipo interface
    if (event.first  === 0 ) {
      if(event.rows === undefined){
        this.getFromToPedidos(1, Number(this.NumRegistro.valor));

      }else{
        this.getFromToPedidos(1, (event.first + event.rows));
      }
      return;
    }

    // const filter = this.filterTable; //variable tipo interface

    if (filter === null || filter === undefined || (filter.codigoPedido === undefined
        &&  filter.fechaSolicitud === undefined  &&  filter.estado === undefined
        &&  filter.cliente === undefined  &&  filter.entregas === undefined)) {
      
      this.getFromToPedidos(event.first + 1, (event.first + event.rows) );
    }

    if (filter !== undefined && filter.codigoPedido !== undefined) {
      this.getFilter(filter.codigoPedido, 'codigoPedido', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.fechaSolicitud !== undefined) {
      this.getFilter(filter.fechaSolicitud, 'fechaSolicitud', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.estado !== undefined) {
      this.getFilter(filter.estado, 'estado', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.cliente !== undefined) {
      this.getFilter(filter.cliente, 'cliente', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.entregas !== undefined) {
      this.getFilter(filter.entregas, 'entregas', undefined, event.first + 1, (event.first + event.rows));
    }
  }

  //Filtros por columnas
  getFilter(event, nombreCampo, filter, desde, hasta ) {
    this.nameCol = nombreCampo;
    this.contentCol = event;
    
    //Guardar en variable valor del input por columnas
    switch (nombreCampo) {
      case ('codigopedido'):        
        this.filterTable.codigoPedido = event
        if(event === ''){
          this.filterTable.codigoPedido =  undefined;
        }
        break;
      case ('ordenCompra'):        
        this.filterTable.ordenCompra =  event;
        if(event === ''){
          this.filterTable.ordenCompra = undefined
        }
        break;
      case ('fechaSolicitud'):
          this.filterTable.fechaSolicitud =  event;
          if(event === ''){
            this.filterTable.fechaSolicitud = undefined
          }
          break;
      case ('estado'):
          this.filterTable.estado =  event;
          if(event === ''){
            this.filterTable.estado = undefined
          }
          break;
      case ('cliente'):
          this.filterTable.cliente =  event;
          if(event === ''){
            this.filterTable.cliente = undefined
          }
          break;
      case ('entregas'):
            this.filterTable.entregas =  event;
            if(event === ''){
              this.filterTable.entregas = undefined
            }
            break;
    }

    //Clear de inputs, se carga las varibales con el valor inicial
    if (this.filterTable.codigoPedido === ''  && this.filterTable.ordenCompra === ''
      && this.filterTable.fechaSolicitud === '' && this.filterTable.estado === ''
      && this.filterTable.cliente === ''  && this.filterTable.entregas === ''|| this.filterTable.codigoPedido === undefined
      && this.filterTable.ordenCompra === undefined && this.filterTable.fechaSolicitud === undefined
      && this.filterTable.estado === undefined && this.filterTable.cliente === undefined && this.filterTable.entregas === undefined){
      
      this.getFromToPedidos(1, Number(this.NumRegistro.valor));
      this.filterTable = <filterTable>{};
      return;
    }

    // Rango de consulta
    if (desde === undefined ||  hasta === undefined) {
      this.from = 1;
      this.to = this.maxR;
    } else {
      this.from = desde;
      this.to= hasta;
    }

    const data = {
      desde: this.from,
      hasta: this.to,
      filtro: this.filterTable
    }

    //Petición a servidor con datos capturados
    this.pedid.getFilesByFilter(data).subscribe(
      resp=>{
        this.distribucion = resp["registros"];
        this.totalRow = resp["numeroTotalRegistros"];
        this.numPage(this.from, this.to, this.totalRow);
        if ( desde === 1 ) {
          this.dt.first = 0;
          this.pg.first = 0;
        }
      }
    );

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
        this.getFromToPedidos(1, max);
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
        this.getFromToPedidos(1, Number(this.NumRegistro.valor));

      }
    }
  }

    // Captura cambios del dropdown Tipo Vehiculo 
    // y ejecuta el método para obtener las placas con esta 
    // caractertistica
    onChangeT(event){

    }

    myUploader(event){

        const toBase64 = file => new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => resolve(reader.result);
            reader.onerror = error => reject(error);
        });
        toBase64(event.files[0]).then((base64Typo: string) =>{
            const base64File = base64Typo.slice(base64Typo.indexOf(',')+1,-1);
            const text = window.atob(base64File);
            const delimiter = this.guessDelimiters(text)[0];
            const fileToSave = {
                fechaInicial: moment(this.initDate).format('DD/MM/YYYY'),
                fechaFinal: moment(this.endDate).format('DD/MM/YYYY'),
                base64: base64Typo,
                NombreArchivo: event.files[0].name,
                separador: delimiter
            };

            this.pedid.saveFile(fileToSave).subscribe(result =>{
                Swal.fire(
                    'Archivo Cargad!',
                    'El archivo de producción futura ha sido cargado.',
                    'success'
                );
            });
        });
    }

    guessDelimiters (text, possibleDelimiters = [',',';','\t']) {
        return possibleDelimiters.filter(weedOut);
    
        function weedOut (delimiter) {
            var cache = -1;
            return text.split('\n').every(checkLength);
    
            function checkLength (line) {
                if (!line) {
                    return true;
                }
    
                var length = line.split(delimiter).length;
                if (cache < 0) {
                    cache = length;
                }
                return cache === length && length > 1;
            }
        }
    }

    //Abrir modal para la asociación de vehiculos a entregas
    open(content) {
        if (this.addEntregas.length > 0) {
            this.addCars = false;
        } else {
            this.addCars = true;
            return;
        }

    this.modalService.open(content ).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
 
  //cerrar modal asociación de vehiculos a entregas
  private getDismissReason(reason: any): string {
   this.getResetForms();
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  // Asociar Vehiculo a Entregas
  // form: recibe informacion de las entregas, tipo de vehiculo, viaje nuevo
  onSubmit(form: NgForm){
    const register = [];
    var totalDeliveries = 0;

    // BR: Minimo 1 entrega para asociar
    if(this.addEntregas.length > 0 ){

      for (let i = 0; i < this.addEntregas.length; i++) {
        register.push(this.addEntregas[i]["entregaId"]);  
        totalDeliveries += this.addEntregas[i]["peso"];
      }

      // Validación capacidad del vehiculo
      if(totalDeliveries > form.value.tipo["capacidad"]){

        // la suma de la cantidad del # de entregas seleccionadas supera la capacidad del
        // vehículo seleccionado
        Swal.fire(
          'Error.',
          'Las entregas seleccionadas superan la capacidad del vehiculo',
          'error'
        );

      } else{
        this.AddVehiculo.vehiculoId = form.value.placa["vehiculoId"];
        this.AddVehiculo.MuelleId = form.value.muelle["MuelleId"];
        this.AddVehiculo.conductorId = form.value.conductor["id"];
        this.AddVehiculo.auxiliarId = form.value.auxiliar["id"];
        this.AddVehiculo.entregasIds = register;
        this.AddVehiculo.nuevoViaje = form.value.nuevo;
        if(!form.value.nuevo){
          this.AddVehiculo.nuevoViaje = false;
        }
         
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
            this.pedid.associateCars(this.AddVehiculo).subscribe(
              resp=>{
                this.getResetForms();
                this.modalService.dismissAll();
                this.getAllDistribucion();
                Swal.fire(
                  'Vehículo Asociado exitosamente!',
                  'El vehículo seleccionado tiene capacidad disponible. Sigue agregando entregas hasta llenar la capacidad del vehículo',
                  'success'
                );
    
              },
              error=>{
                Swal.fire(
                  'Error asociando Vehículo. Por favor, intentarlo de nuevo.',
                  error.error,
                  'error'
                );
              }
            );

          }
        })
       
      }
      
      
    }else{

      // # de entregas seleccionadas es igual a cero o nulo
      Swal.fire(
        'Por favor relacione una entrega.',
        '',
        'error'
      );
    }
  }

  // Reset del formulario y modelo vehiculo
  getResetForms(){
    this.vehiculo = <formV>{};
    this.form.reset();
    this.AddVehiculo = <vehiculos>{};
    this.addEntregas = [];
  }
  
}
