import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { LazyLoadEvent, Paginator } from 'primeng/primeng';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { RolesService } from 'src/app/core/services/roles.service';
import { SettingService } from 'src/app/core/services/setting.service';
import {NgbModal, ModalDismissReasons, NgbModalOptions} from '@ng-bootstrap/ng-bootstrap';
import { generalParamNames } from 'src/app/config/global';
import Swal from 'sweetalert2';
declare var $: any;


export interface filterTable {
  rolId: String,
  nombre: String,
  activo: boolean
}

@Component({
  selector: 'app-adminrol',
  templateUrl: './adminrol.component.html',
  styleUrls: ['./adminrol.component.scss']
})
export class AdminrolComponent implements OnInit {

  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  rol;
  rolesId;
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


  constructor(private setting: SettingService, private roles: RolesService, private modalService: NgbModal) { 
    this.filterTable = <filterTable>{};
  }

  ngOnInit() {

    //encabezados de tabla
    this.columns=[
      {field: 'nombre', header: 'Nombre', class: 'columnName'},
      {field: 'activo', header: 'Activo', class: 'text-center columnActivo'},
      {field: 'acciones', header: 'Acciones', class: 'text-center'}
    ]

    this.getAllRoles();
  }

  //Get todos los roles
  getAllRoles(){
    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.maxR = Number(this.NumRegistro.valor);
    this.getFromToRoles(1, Number(this.NumRegistro.valor));
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
        this.getFromToRoles(1, max);
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
        this.getFromToRoles(1, Number(this.NumRegistro.valor));

      }
    }
  }

  //Roles por rango
  getFromToRoles(from, to){
    this.roles.getAllRoles(from, to).subscribe(
      resp=>{
        this.rol = resp["registros"];
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
        this.getFromToRoles(1, Number(this.NumRegistro.valor));

      }else{
        this.getFromToRoles(1, (event.first + event.rows));
      }
      return;
    }

    if (filter === null || filter === undefined || (filter.nombre === undefined)) {
      
      this.getFromToRoles(event.first + 1, (event.first + event.rows) );
    }

    if (filter !== undefined && filter.nombre !== undefined) {
      this.getFilter(filter.nombre, 'nombre', undefined, event.first + 1, (event.first + event.rows));
    }

  }

  //Filtros por columnas
  getFilter(event, nombreCampo, filter, desde, hasta ) {
    this.nameCol = nombreCampo;
    this.contentCol = event;

    //Guardar en variable valor del input por columnas
    switch (nombreCampo) {
      case ('nombre'):        
        this.filterTable.nombre = event
        if(event === ''){
          this.filterTable.nombre =  undefined;
        }
        break;
    }

    //Clear de inputs, se carga las varibales con el valor inicial
    if (this.filterTable.nombre === ''  || this.filterTable.nombre === undefined ){

      this.getFromToRoles(1, Number(this.NumRegistro.valor));
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
    this.roles.getFilter(data).subscribe(
      resp=>{
        this.rol = resp["registros"];
        this.totalRow = resp["numeroTotalRegistros"];
        this.numPage(this.from, this.to, this.totalRow);
        if ( desde === 1 ) {
          this.dt.first = 0;
          this.pg.first = 0;
        }
      }
    );

  }

  //Desactivar rol
  active(event, rolact) {
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
        this.roles.activeRol(rolact).subscribe(
          resp=> {
            this.getFromToRoles(1, this.maxR);
            Swal.fire(
              'Actualización Exitosa!',
              'El Estado del rol fue actualizado con éxito.',
              'success'
            )
          }
        )
      }else{
        this.getFromToRoles(1, this.maxR);
      }
    })
  }

  //Abrir modal detalle Auditoria
  open(content, datos) {
    const datRol = datos;
    this.getRolId(datRol.rolId);

    setTimeout(() => {
      this.modalService.open(content, {size:'lg'} ).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    },200);
  }
 
  //cerrar modal detalle Auditoria
  private getDismissReason(reason: any): string {
    this.rolesId = '';
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  //Get información completa de rol por Id
  getRolId(id){
    this.roles.getRolId(id).subscribe(
      resp=>{
        this.rolesId = resp
      }
    )
  }

}
