import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { RolesService } from 'src/app/core/services/roles.service';
import { Table } from 'primeng/table';
import { LazyLoadEvent, Paginator } from 'primeng/primeng';
import { SettingService } from 'src/app/core/services/setting.service';
import {NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { generalParamNames } from 'src/app/config/global';

import Swal from 'sweetalert2';
declare var $: any;


export interface FilterTable {
  rolId: String,
  nombre: String,
  usuario: String,
  activo: boolean
}

export interface register {
  rolId: String,
  usuarios: any
}

@Component({
  selector: 'app-usersrol',
  templateUrl: './usersrol.component.html',
  styleUrls: ['./usersrol.component.scss']
})
export class UsersrolComponent implements OnInit {

  id: String;
  @ViewChild('dt' ,  {static: true} )   dt: Table;
  @ViewChild('pg' ,  {static: true} )   pg: Paginator;
  columns: any[];
  rolUsers;
  AllUsers;
  addUsers: any[] = [];
  removeUsers: any[] = [];
  maxregister;
  NumRegistro;
  filterTable: FilterTable;
  from: number;
  to: number;
  totalRow: number = 0;
  totalRowM: number = 0;
  maxR = 0;
  maxRM = 0;
  numFilas = 0;
  nameCol;
  contentCol;
  closeResult: string;
  data;


  constructor(private actRoute: ActivatedRoute, private rolesUser: RolesService, private setting: SettingService,
    private modalService: NgbModal) { 
      this.data = <register>{};
      this.filterTable = <FilterTable>{};
    }

  ngOnInit() {
    //encabezados de tabla
    this.columns=[
      {field: 'usuario', header: 'Usuario', class: ''},
      {field: 'nombre', header: 'Nombre', class: ''}
    ]
    this.getRolId();
  }

  // Obtener el id de la url 
  getRolId(){
    this.id = this.actRoute.snapshot.paramMap.get('id');
    this.NumRegistro = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.maxR = Number(this.NumRegistro.valor);
    this.getFromToRolUser(1, Number(this.NumRegistro.valor));
    this.getAllUsers(this.id);
  }

  // Usuarios asociados al rol
  getFromToRolUser(from, to){
    this.rolesUser.getRolIdUsers(from, to, this.id).subscribe(
      resp=>{
        this.rolUsers = resp["registros"];
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
    );
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

  // Usuarios del dominio disponible para asociar
  getAllUsers(id){
    this.rolesUser.getAllUsers(id).subscribe(
      resp=>{
        this.AllUsers = resp["registros"];
      }
    )
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
        this.getFromToRolUser(1, max);
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
        this.getFromToRolUser(1, Number(this.NumRegistro.valor));

      }
    }
  }

  //función que controla comportamiento de la paginación
  loadCarsLazy(event: LazyLoadEvent){
  
    const filter = this.filterTable; //variable tipo interface
    if (event.first  === 0 ) {
      if(event.rows === undefined){
        this.getFromToRolUser(1, Number(this.NumRegistro.valor));

      }else{
        this.getFromToRolUser(1, (event.first + event.rows));
      }
      return;
    }

    if (filter === null || filter === undefined || (filter.nombre === undefined)) {
      
      this.getFromToRolUser(event.first + 1, (event.first + event.rows) );
    }

    if (filter !== undefined && filter.nombre !== undefined) {
      this.getFilter(filter.nombre, 'nombre', undefined, event.first + 1, (event.first + event.rows));
    }

    if (filter !== undefined && filter.usuario !== undefined) {
      this.getFilter(filter.usuario, 'usuario', undefined, event.first + 1, (event.first + event.rows));
    }
  }

  //Filtros por columnas
  getFilter(event, nombreCampo, filter, desde, hasta ) {
    this.nameCol = nombreCampo;
    this.contentCol = event;
    //Guardar en variable valor del input por columnas
    this.filterTable[nombreCampo] = event
    //If every element is empty get all orders again 
    const isAnyFilterEmpty = Object.values(this.filterTable).every(x => (x === ''));
    if (isAnyFilterEmpty){
      this.getFromToRolUser(1, Number(this.NumRegistro.valor));
      this.filterTable = <FilterTable>{};
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
    this.rolesUser.getFilter(data).subscribe(
      resp=>{
        this.totalRow = resp["numeroTotalRegistros"];
        this.numPage(this.from, this.to, this.totalRow);
        if ( desde === 1 ) {
          this.dt.first = 0;
          this.pg.first = 0;
        }
      }
    );

  }

  //Abrir modal detalle Auditoria
  open(content) {
    this.getAllUsers(this.id);
    this.modalService.open(content, {size:'lg', scrollable: true } ).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
 
  //cerrar modal detalle Auditoria
  private getDismissReason(reason: any): string {
    this.addUsers = [];
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  //Asociar Usuarios al rol
  AddUsersRol(){
    const register = [];
    for (let i = 0; i < this.addUsers.length; i++) {
      register[i] ={
        'usuarioId':0,
        'nombreUsuario': this.addUsers[i]['usuario'],
        'nombre': this.addUsers[i]['nombre']
      } 
      
    }   
    this.data.rolId = Number(this.id);
    this.data.usuarios = register;

    //verificación envio de post
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
        //Peticion post para asociacion de usuarios a rol
        this.rolesUser.addUsersRol(this.data).subscribe(()=>{         
            Swal.fire(
              'Usuarios asociados con Éxito!',
              'Los usuarios fueron asociados exitosamente.',
              'success'
            )
            this.addUsers = [];
            this.getFromToRolUser(1, Number(this.NumRegistro.valor));    
            this.getAllUsers(this.id);
    
          }
        )
      }
    })
  }

  //Desasociar Usuarios al rol
  DeletedUsers(){
    const delUsers = [];
    for (let i = 0; i < this.removeUsers.length; i++) {
      delUsers.push(this.removeUsers[i]['usuarioId']);      
    } 

    this.data.rolId= Number(this.id);
    this.data.usuariosIds = delUsers;

    //verificación envio de post
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
        this.rolesUser.removeUsersRol(this.data).subscribe(()=>{
            this.removeUsers = [];
            this.getFromToRolUser(1, Number(this.NumRegistro.valor));    
            this.getAllUsers(this.id);
            Swal.fire(
              'Eliminación Exitosa!',
              'Los usuarios seleccionados fueron desasociados exitosamente',
              'success'
            )
          }
        )
      }
    })


   
  }
  

}
