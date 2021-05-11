import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  UrlHost = environment.Urlserver + environment.UrlApi; //Variables globales de entornos

  constructor(private http: HttpClient) { }

  //Get todos los registros de auditoria desde el backend
  getAllRoles(from, to){
    return this.http.get(this.UrlHost + 'roles' , { withCredentials:true, params:{ desde: from, hasta:to} } );
  }

  //Get todos los registros de roles desde el backend
  //con filtros por columnas
  getFilter(data){
    return this.http.post(this.UrlHost + 'roles/filtrar', data, { withCredentials:true } );
  }

  //Get todos los modulos para la creacion de roles
  getModulos(from, to){
    return this.http.get(this.UrlHost + 'modulos',  { withCredentials:true, params:{ desde: from, hasta:to} } );
  }

  //Post Crear Roles 
  createRol(data){
    return this.http.post(this.UrlHost + 'roles', data, { withCredentials:true } );
  }

  //get Usuarios asociados al rol
  getRolIdUsers(from, to, id){
    return this.http.get(this.UrlHost + 'roles/usuarios',  { withCredentials:true, params:{ desde: from, hasta:to, rolId:id} });
  }

  // get Usuarios del dominio disponibles para asociar al rol
  getAllUsers(id){
    return this.http.get(this.UrlHost + 'usuarios/grupodominiomenosrol/'+ id,  { withCredentials:true });
  }

  //Asociar usuarios a rol 
  addUsersRol(data){
    return this.http.post(this.UrlHost + 'roles/usuarios/asociar', data, { withCredentials:true });
  }

  //Get rol por id
  getRolId(id){
    return this.http.get(this.UrlHost +'roles/'+ id, { withCredentials:true } );
  }

  //Post Desasociar usuarios a rol
  removeUsersRol(data){
    return this.http.post(this.UrlHost + 'roles/usuarios/desasociar', data,  { withCredentials:true });
  }

  //Activar o desactivar rol
  activeRol(data){
    return this.http.post(this.UrlHost + 'roles/activar', data, { withCredentials:true });
  }

  //Post Actualiza Rol 
  updateRol(data){
    return this.http.post(this.UrlHost + 'rolesEdit', data, { withCredentials:true });
  } 

  
}
