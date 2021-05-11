import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { LazyLoadEvent, Paginator } from 'primeng/primeng';
import { SettingService } from 'src/app/core/services/setting.service';
import { IntegracionService } from '../../core/services/integracion.service';
import { NgbModal, ModalDismissReasons, NgbModalOptions} from '@ng-bootstrap/ng-bootstrap';
import { Validators, FormControl, FormGroup, FormBuilder, NgForm, FormArray } from '@angular/forms';
import { Integracion } from '../../interface/integracion';
import { generalParamNames } from 'src/app/config/global';
import Swal from 'sweetalert2';

export interface filterTable {
  estado: Boolean,
  fechaInicio: String,
  fechaFin: String,
  logJob: String,
  logIntegracion: String
}

@Component({
  selector: 'app-saparticulos',
  templateUrl: './saparticulos.component.html',
  styleUrls: ['./saparticulos.component.scss']
})
export class SaparticulosComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  state: any[];
  logs;
  logsId;
  maxregister;
  NumRegistro;
  filterTable: filterTable;
  from: number;
  to: number;
  totalRow: number = 0;
  maxR = 0;
  numFilas = 0;
  nameCol;
  contentCol;  
  closeResult: string;
  selectedItem: {
    name: String,
    value: Boolean
  }
  meridian = true;
  ejecutionH: Integracion;
  form: FormGroup;
  formH: FormGroup;

  constructor(private setting: SettingService, private integr: IntegracionService, private modalService: NgbModal,
    private fb: FormBuilder) { 
    this.filterTable = <filterTable>{};
  }

  ngOnInit() {
    this.ejecutionH = <Integracion>{};

    //encabezados de tabla
    this.columns=[
      {field: 'estado',         header: 'Estado', class: ''},
      {field: 'fechaInicio',    header: 'Fecha Inicio', class: ''},
      {field: 'fechaFin',       header: 'Fecha Fin', class: ''},
      {field: 'logJob',         header: 'log Job', class: ''},
      {field: 'logIntegracion', header: 'Log de Integración', class: ''},
      {field: 'acciones',       header: 'Acciones', class:"text-center"}
    ];

    //estados filtro tabla
    this.state = [
      { name: 'Mostrar todos', value: undefined },
      { name: 'Exitosa', value: true },
      { name: 'Fallido', value: false },
    ];

    //form programación de jobs
    this.form = this.fb.group({
      horaEjecucion: new FormControl(new Date(), Validators.required),

    });

    this.formH = this.fb.group({
      frecuencia: new FormControl('', Validators.required),
      horaFin: new FormControl(new Date(), Validators.required),
      horaInicio: new FormControl(new Date(), Validators.required)

    });    

    this.getForm();
    this.getLogsEstado();
    this.getLog();

  }

  getForm(){
    //form programación de jobs
    this.form = this.fb.group({
      horaEjecucion: new FormControl('', Validators.required),

    });

    this.formH = this.fb.group({
      frecuencia: new FormControl('', [Validators.required]),
      horaFin: new FormControl('', [Validators.required]),
      horaInicio: new FormControl('', [Validators.required]),

    }); 

  }

  //Get Estado horas de ejecución
  getLogsEstado(){
    this.integr.getLogsEstado().subscribe(
      resp=>{
        console.log(resp);
        // this.ejecutionH = resp;
      }
    )
  }

  //Get todos los log
  getLog(){
    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.maxR = Number(this.NumRegistro.valor);
    this.getFromToLog(1, Number(this.NumRegistro.valor));
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
        this.getFromToLog(1, max);
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
        this.getFromToLog(1, Number(this.NumRegistro.valor));

      }
    }
  }

  //Log
  getFromToLog(from, to){
    this.integr.getAllLog(from, to).subscribe(
      resp=>{
        this.logs = resp["registros"];
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

  //calcular numero de registros por pagina
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
        this.getFromToLog(1, Number(this.NumRegistro.valor));

      }else{
        this.getFromToLog(1, (event.first + event.rows));
      }
      return;
    }

    if (filter === null || filter === undefined || (filter.estado === undefined
      &&  filter.fechaInicio === undefined  &&  filter.fechaFin === undefined
      &&  filter.logJob === undefined  &&  filter.logIntegracion === undefined)) {
      
      this.getFromToLog(event.first + 1, (event.first + event.rows) );
    }

    if (filter !== undefined && filter.estado !== undefined) {
      this.getFilter(filter.estado, 'estado', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.fechaInicio !== undefined) {
      this.getFilter(filter.fechaInicio, 'fechaInicio', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.fechaFin !== undefined) {
      this.getFilter(filter.fechaFin, 'fechaFin', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.logJob !== undefined) {
      this.getFilter(filter.logJob, 'logJob', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.logIntegracion !== undefined) {
      this.getFilter(filter.logIntegracion, 'logIntegracion', undefined, event.first + 1, (event.first + event.rows));
    }

  }

  //Filtros por columnas
  getFilter(event, nombreCampo, filter, desde, hasta ) {
    this.nameCol = nombreCampo;
    this.contentCol = event;

    //Guardar en variable valor del input por columnas
    switch (nombreCampo) {
      case ('estado'):
        this.filterTable.estado = event;
        if (event === undefined) {
          this.filterTable.estado = undefined;
        }
        break;

      case ('fechaInicio'):        
        this.filterTable.fechaInicio = event
        if(event === ''){
          this.filterTable.fechaInicio =  undefined;
        }
        break;

      case ('fechaFin'):        
        this.filterTable.fechaFin = event
        if(event === ''){
          this.filterTable.fechaFin =  undefined;
        }
        break;

      case ('logJob'):        
        this.filterTable.logJob = event
        if(event === ''){
          this.filterTable.logJob =  undefined;
        }
        break;

      case ('logIntegracion'):
        this.filterTable.logIntegracion = event
        if(event === ''){
          this.filterTable.logIntegracion =  undefined;
        }
        break;
    }

    //Clear de inputs, se carga las varibales con el valor inicial
    if (this.filterTable.fechaInicio === ''
    && this.filterTable.fechaFin === '' && this.filterTable.logJob === ''
    && this.filterTable.logIntegracion === '' || this.filterTable.estado === undefined
    && this.filterTable.fechaInicio === undefined && this.filterTable.fechaFin === undefined
    && this.filterTable.logJob === undefined && this.filterTable.logIntegracion === undefined ){

      this.getFromToLog(1, Number(this.NumRegistro.valor));
      this.filterTable = <filterTable>{};
      return;
    }

    // Rango de consulta
    if (desde === undefined ||  hasta === undefined) {
      this.from = 1;
      this.to= Number(JSON.parse(this.NumRegistro.valor));
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
    this.integr.getFilter(data).subscribe(
      resp=>{
        this.logs = resp["registros"];
        this.totalRow = resp["numeroTotalRegistros"];
        this.numPage(this.from, this.to, this.totalRow);
        if ( desde === 1 ) {
          this.dt.first = 0;
          this.pg.first = 0;
        }
      }
    );

  }

  //Abrir modal detalle Logs
  open(content, datos) {
    this.logsId = datos;
    this.modalService.open(content, {size:'lg', scrollable: true } ).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
 
  //cerrar modal detalle Logs
  private getDismissReason(reason: any): string {
    this.logsId = '';
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  ejecutar(){
    this.integr.ejecutar().subscribe(
        resp=>{
          Swal.fire(
            'Integración ejecutada con éxito.',
            'Integración de productos ejecutada con éxito! ',
            'success'
          )
          
        },
        error=>{
          Swal.fire(
            'Error.',
            error.error,
            'error'
          )
        }
      );  
  }

  //Save hora de ejecución job
  onSubmit(form: NgForm){
    if(this.ejecutionH.horaEjecucion != null){
      const data = {
        tipoProgramacion: 'Una_Vez_a_Día',
        horaEjecucionIntegracion: JSON.stringify(this.ejecutionH.horaEjecucion),
      }
      this.infoSwal(data);
    }else{

      Swal.fire(
        'Error.',
        'Por favor selecciobe una fecha valida',
        'error'
      );


    }


  }

  onSubmitRange(formH: NgForm){

    if(this.ejecutionH.frecuencia != null &&  this.ejecutionH.horaFin && this.ejecutionH.horaInicio){      
      const data = {
        tipoProgramacion: 'Frecuencia_al_Día',
        horaFin: JSON.stringify(this.ejecutionH.horaFin),
        horaInicio: JSON.stringify(this.ejecutionH.horaInicio),
        frecuencia: this.ejecutionH.frecuencia
      }
      this.infoSwal(data);
      
    }else{

      Swal.fire(
        'Error.',
        'Por favor selecciobe una fecha valida',
        'error'
      );
    }
    
  }

  infoSwal(data){
    Swal.fire({
      title: '¿Estás seguro?',
      text: "¡No podrás revertir esto!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#47a44b',
      cancelButtonColor: '#d33',      
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Confirmar'
    }).then((result) => {
      if (result.value) {
        this.integr.AddProgrammingOne(data).subscribe(
          resp=>{
            Swal.fire(
              'Programación exitosa',
              'Integración de productos ejecutada con éxito! ',
              'success'
            )
            this.getLogsEstado();
            this.getLog();
            
          },
          error=>{
            Swal.fire(
              'Error.',
              error.error,
              'error'
            )
          }
        );  
      }
    })
  }


}
