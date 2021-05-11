import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { generalParamNames } from 'src/app/config/global';
import { Observable } from 'rxjs/Rx';
import Swal from 'sweetalert2';

import { PedidosService } from 'src/app/core/services/pedidos.service';
import { SettingService } from 'src/app/core/services/setting.service';
import { CarsService } from 'src/app/core/services/cars.service';

export interface filterTable {
  tipoVehiculo: String,
  placa: String,
  pesoVehiculo: String,
  unidadMedida: String,
}

export interface vehiculos{
  vehiculoId: number,
  vehiculoEntregaId: number,
  conductorId: number,
  AuxiliarId: number,
  muelleId: number
}

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.scss']
})
export class CarsComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  NumRegistro;
  maxR;
  numFilas;
  filterTable: filterTable;
  from: number;
  to: number;
  totalRow: number = 0;
  nameCol;
  contentCol;
  maxregister;
  closeResult: string;
  vehiculos;
  driversOfVehicle: any;
  conductor: any[];
  auxiliarOfVehicle: any[];
  muellesVehicles;
  tipo: any; typeOfVehicles;
  tipoVehiculo;
  muelleVehiculo;
  conductorVehiculo;
  auxiliarVehiculo;
  nuevoVehiculo;
  enableCars;
  placasOfVehicles;
  vehicleToUpdate: vehiculos = {
    vehiculoId: null,
    vehiculoEntregaId: null,
    conductorId: null,
    AuxiliarId: null,
    muelleId: null
  };


  vehiculoToBeEdited;


  constructor(
    private setting: SettingService, 
    private modalService: NgbModal, 
    private pedidosService: PedidosService,
    private carsService: CarsService
    ) { }

  ngOnInit() {

    this.vehiculos = [];

    this.columns =[
      {field: 'tipoVehiculo', header: 'Tipo Vehículo', class: 'columnC'},
      {field: 'placa', header: 'Placa', class:''},
      {field: 'muelle', header: 'Muelle', class:''},
      {field: 'pesoVehiculo', header: 'Peso Vehículo Vacío', class:'text-right'},
      {field: 'capacidad', header:'Capacidad Vehículo', class:'text-right'},
      {field: 'totalentega', header:'Total Entregas', class:'text-right'},
      {field: 'acciones', header: 'Acciones', class: 'text-center'}
    ]

    this.getFillableProperties();

    this.getAllDistribucion();
  }

  getFillableProperties(){
    Observable.forkJoin(
        this.carsService.getTypeCars(),
        this.carsService.getAllDriver(),
        this.carsService.getAllMuelles()
      ).subscribe(([
        cars, 
        driver, 
        muelles
      ])=>{
        this.typeOfVehicles = cars;
        this.driversOfVehicle = driver;
        this.drivers(driver);
        this.muellesVehicles = muelles;
      },
      error => {
        console.log('error', error);
      });
  }

  // Captura cambios del dropdown Tipo Vehiculo 
  // y ejecuta el método para obtener las placas con esta 
  // caractertistica
  onChangeT(event){
    if(event.value !=null){
      this.carsService.getCars(event.value.TipoVehiculoId).subscribe(
        resp=>{
          this.enableCars = false;
          this.placasOfVehicles = resp;
          this.vehiculoToBeEdited.placa = null;
        },
        error=>{
        }
      )
    }else{
      this.enableCars = true;
      this.placasOfVehicles = [];
    }
  }

  // Método que permite separar los conductores y auxiliares
  drivers(data){
      const aux = [];
      const cond = [];
      for (let i = 0; i < data.length; i++) {
        if(data[i]["cargo"] === "Conductor"){
          const c = {
            id: data[i]["empleadoId"],
            name: data[i]["nombres"]+ ' ' +data[i]["apellidos"],
          }
          cond.push(c);
  
        }else{
          const a  = {
            id: data[i]["empleadoId"],
            name: data[i]["nombres"]+ ' ' +data[i]["apellidos"],
          }
          aux.push(a);
          
        }
            
      }
      this.conductor = cond;
      this.auxiliarOfVehicle = aux;
    }


  // Método para obtener el tamaño de registro e invocar la 
  // método para el llamado de los vehiculos
  getAllDistribucion(){
    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.maxR = Number(this.NumRegistro.valor);
    this.getFromToCars(1, Number(this.NumRegistro.valor));

  }

  // Método para el llamado de todos los vehiculos con carga
  // from: Número que indica el minimo de registro para la consulta
  // to: Número que indica el maximo de registros para la consulta
  getFromToCars(from, to){
    this.pedidosService.DeliveriesCars().subscribe(
      resp=>{
        this.vehiculos = resp;
      }
    );

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
        this.getFromToCars(1, Number(this.NumRegistro.valor));

      }else{
        this.getFromToCars(1, (event.first + event.rows));
      }
      return;
    }

    // const filter = this.filterTable; //variable tipo interface
    const isAnyFilterEmpty = Object.values(this.filterTable).every(x => (x === ''));

    if (filter === null || filter === undefined || (isAnyFilterEmpty)) {
      this.getFromToCars(event.first + 1, (event.first + event.rows) );
    }

    if (filter !== undefined && filter.tipoVehiculo !== undefined) {
      this.getFilter(filter.tipoVehiculo, 'tipoVehiculo', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.placa !== undefined) {
      this.getFilter(filter.placa, 'placa', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.pesoVehiculo !== undefined) {
      this.getFilter(filter.pesoVehiculo, 'pesoVehiculo', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.unidadMedida !== undefined) {
      this.getFilter(filter.unidadMedida, 'unidadMedida', undefined, event.first + 1, (event.first + event.rows));
    }

  }

  //Filtros por columnas
  getFilter(event, nombreCampo, filter, desde, hasta ) {
    this.nameCol = nombreCampo;
    this.contentCol = event;
    
    //Guardar en variable valor del input por columnas
    switch (nombreCampo) {
      case ('tipoVehiculo'):        
        this.filterTable.tipoVehiculo = event
        if(event === ''){
          this.filterTable.tipoVehiculo =  undefined;
        }
        break;
      case ('placa'):        
        this.filterTable.placa =  event;
        if(event === ''){
          this.filterTable.placa = undefined
        }
        break;
      case ('pesoVehiculo'):
          this.filterTable.pesoVehiculo =  event;
          if(event === ''){
            this.filterTable.pesoVehiculo = undefined
          }
          break;
      case ('unidadMedida'):
          this.filterTable.unidadMedida =  event;
          if(event === ''){
            this.filterTable.unidadMedida = undefined
          }
          break;
    }

    //Clear de inputs, se carga las varibales con el valor inicial
    if (this.filterTable.tipoVehiculo === ''  && this.filterTable.placa === ''
      && this.filterTable.pesoVehiculo === '' && this.filterTable.unidadMedida === ''|| this.filterTable.tipoVehiculo === undefined
      && this.filterTable.placa=== undefined && this.filterTable.pesoVehiculo === undefined
      && this.filterTable.unidadMedida === undefined ){
      
      this.getFromToCars(1, Number(this.NumRegistro.valor));
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
    // this.pedid.getFilter(data).subscribe(
    //   resp=>{
    //     this.distribucion = resp["registros"];
    //     this.totalRow = resp["numeroTotalRegistros"];
    //     this.numPage(this.from, this.to, this.totalRow);
    //     if ( desde === 1 ) {
    //       this.dt.first = 0;
    //       this.pg.first = 0;
    //     }
    //   }
    // );

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
        this.getFromToCars(1, max);
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
        this.getFromToCars(1, Number(this.NumRegistro.valor));

      }
    }
  }

  //Abrir modal para la asociación de vehiculos a entregas
  open(content) {
    this.modalService.open(content, {size:'lg'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
 
  //cerrar modal 
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  
  //Open a modal with it's content
  openModalEditVehicle(vehiculoToBeEdited, content, size) {
    this.vehiculoToBeEdited = vehiculoToBeEdited;
    this.asignParametersToVehicle();
    this.modalService.open(content, {size: size} );
  }
  asignParametersToVehicle() {
    this.vehiculoToBeEdited.tipo = this.typeOfVehicles.find(e=>{
      return e.TipoVehiculoId == this.vehiculoToBeEdited.tipoVehiculo.TipoVehiculoId;
    });
    this.carsService.getCars( this.vehiculoToBeEdited.tipoVehiculo.TipoVehiculoId ).subscribe(
      resp=>{
        this.enableCars = false;
        this.placasOfVehicles = resp;
        this.vehiculoToBeEdited.placa = this.placasOfVehicles.find(e=>{
          return e.placa == this.vehiculoToBeEdited.vehiculo.placa;
        });
      },
      error=>{
      }
    );

    this.vehiculoToBeEdited.muelle = this.muellesVehicles.find(e=>{
      return e.MuelleId == this.vehiculoToBeEdited.muelle.MuelleId;
    });

    this.vehiculoToBeEdited.driverOfVehicle = this.driversOfVehicle.find(e=>{
      return e.empleadoId == this.vehiculoToBeEdited.conductor.empleadoId;
    });
    
    this.vehiculoToBeEdited.auxiliarOfVehicle = this.auxiliarOfVehicle.find(e=>{
      return e.id == this.vehiculoToBeEdited.auxiliar.empleadoId;
    });
  }

  modifyVehicle(){
      // Validación capacidad del vehiculo
      if (this.vehiculoToBeEdited.placa === null) {
          
        // la suma de la cantidad del # de entregas seleccionadas supera la capacidad del
        // vehículo seleccionado
        Swal.fire(
          'Error.',
          'Debe seleccionar una placa para modificar el vehículo.',
          'warning'
        );
      }
      if(this.vehiculoToBeEdited.totalPeso > this.vehiculoToBeEdited.placa.capacidad){

        // la suma de la cantidad del # de entregas seleccionadas supera la capacidad del
        // vehículo seleccionado
        Swal.fire(
          'Error.',
          'Las entregas seleccionadas superan la capacidad del vehiculo',
          'error'
        );
        return;
      } else {
        this.vehicleToUpdate.vehiculoEntregaId = this.vehiculoToBeEdited.vehiculoEntregaId;
        this.vehicleToUpdate.muelleId = this.vehiculoToBeEdited.muelle.MuelleId;
        this.vehicleToUpdate.conductorId = this.vehiculoToBeEdited.driverOfVehicle.empleadoId;
        this.vehicleToUpdate.AuxiliarId = this.vehiculoToBeEdited.auxiliarOfVehicle.id;
        this.vehicleToUpdate.vehiculoId = this.vehiculoToBeEdited.placa.vehiculoId;

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
            this.pedidosService.updateVehicle(this.vehicleToUpdate).subscribe(
              resp=>{
                this.modalService.dismissAll();
                this.getAllDistribucion();
                this.getFillableProperties();
                Swal.fire(
                  'Vehículo Modificado Exitosamente',
                  '',
                  'success'
                );
    
              },
              error=>{
                Swal.fire(
                  'Error asociando Vehículo. Por favor, intentarlo de nuevo.',
                  '',
                  'error'
                );
              }
            );

          }
        })
       
      }
  }
}
