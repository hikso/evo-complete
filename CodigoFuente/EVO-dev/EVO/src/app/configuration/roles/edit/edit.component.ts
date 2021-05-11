import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder, NgForm, FormArray } from '@angular/forms';
import { ActivatedRoute } from "@angular/router";
import { RolesService } from 'src/app/core/services/roles.service';
import { Roles } from '../../../interface/roles'
import { SettingService } from 'src/app/core/services/setting.service';
import { generalParamNames } from 'src/app/config/global';
import Swal from 'sweetalert2';
declare var $: any;

export interface modFunc{
  Nombre: String,
  ModuloId: number,
  FuncionalidadesIds: any[],
  Activo: boolean
}

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  name;
  Id;
  form: FormGroup
  rolEdit;
  modFunc: modFunc;
  Ids: Array<number> = [];
  CreateRol: any[];
  validar: boolean;

  constructor(private actRoute: ActivatedRoute, private roles: RolesService, private setting: SettingService, private fb: FormBuilder ) { }

  ngOnInit() {
    this.name = this.actRoute.snapshot.paramMap.get('name'); //obtener nombre del rol desde la URL
    this.Id = this.actRoute.snapshot.paramMap.get('id');  //obtener Id del rol desde URL
    this.rolEdit = <Roles>{};
    this.validar = false;
    this.getModulos();
    this.getFoms();
    this.getRolId();
  }

  //Get modulos creacion de roles
  getModulos(){
    const to = this.setting.getRegisterLocalStorage(generalParamNames.TAMANHO_PAGINACION_WEBAPI);
    this.roles.getModulos(1, Number(to.valor)).subscribe(
      resp=>{
        this.modFunc = resp["registros"];
      }
    )
  }

  //Validar Inputs de formularios
  //Formularios reactivos
  getFoms(){
    this.form = this.fb.group({
      Nombre: new FormControl('', Validators.required),
      PlantaBeneficio: new FormControl(false),
      PlantaDerivados: new FormControl(false),
      PuntoVenta: new FormControl(false),
      Administracion: new FormControl(false),
      FuncionalidadesIds: this.fb.array([]),

    });
  }

  //Obtener informacion completa del rol
  getRolId(){
    this.roles.getRolId(this.Id).subscribe(
      resp=>{
        this.rolEdit = resp;
        this.validar = true;
        this.funcionalidadesInit(resp["FuncionalidadesIds"]); 
      }
    )
  }

  //Cargar Ids de funcionalidad inicialmente
  funcionalidadesInit(data){
    for (let i = 0; i< data.length; i++) {
      this.Ids.push(data[i]['funcionalidadId']);
    }
  }

  //Agregar Id de funcionalidad a array
  addFunc(event, items: any){
    if(event){      
      this.Ids.push(items['FuncionalidadId']);
    }else{
      var i = this.Ids.indexOf( items['FuncionalidadId'] );
 
      if ( i !== -1 ) {
        this.Ids.splice( i, 1 );
      }
    }
  }

  //Bussines Rules: se habilita el boton de guardar cuando
  //exite almenos un permiso seleccionado
  validation(form: NgForm){
    const f = form.value;
    if(f.PlantaBeneficio || f.PlantaDerivadosCarnicos || f.PuntosVenta || f.Administrador ){
        this.validar = true;
      }else{
        this.validar = false;
      }
  }

  onSubmit(form: NgForm){

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
        const data = form.value;
        data.rolId= Number(this.Id);
        data.FuncionalidadesIds = this.Ids;
        this.roles.updateRol(data).subscribe(
          resp=>{
            Swal.fire(
              'Actualización Exitosa!',
              'El rol fue actualizado con éxito.',
              'success'
            )
          }
        )
      }
    })   
  }

    //Desactivar rol
    active() {
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
            let rol = {
                rolId: this.Id,
                nombre: this.name,
                activo: false
            }
            this.roles.activeRol(rol).subscribe(
              resp=> {
                Swal.fire(
                  'Se ha cancelado el rol!',
                  'El rol fue cancelado con éxito.',
                  'success'
                )
              }
            )
          }
        })
      }
}
