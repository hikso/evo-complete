import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder, NgForm, FormArray } from '@angular/forms';
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
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  form: FormGroup
  rolcreate: Roles;
  modFunc: modFunc;
  Ids: Array<number> = [];
  CreateRol: any[];  
  validar: boolean;
  isChecked: boolean;


  constructor(private roles: RolesService, private setting: SettingService, private fb: FormBuilder ) { }

  ngOnInit() {
    this.rolcreate = <Roles>{};
    this.validar = false;
    this.isChecked = false;
    this.getModulos();
    this.getFoms();
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

  //Agregar funcionalidad al array
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


  //Enviar post con datos a Api
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
        this.rolcreate = form.value;    
        this.rolcreate.FuncionalidadesIds = this.Ids;
        this.roles.createRol(this.rolcreate).subscribe(
          resp=>{
            form.reset();
            this.rolcreate = <Roles>{};
            this.Ids = [];
            this.validar = false;
            this.getModulos();
            Swal.fire(
              'Creación Exitosa!',
              'El rol fue creado con éxito.',
              'success'
            )
          },
          error=>{
            Swal.fire(
              'Error creando rol.',
              error.error,
              'error'
            )
          }
        );

      }
    })

  }

}
