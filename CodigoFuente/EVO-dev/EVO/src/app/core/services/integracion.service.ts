import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class IntegracionService {

  UrlHost = environment.Urlserver + environment.UrlApi; //Variables globales de entornos

  constructor(private http: HttpClient) { }

  //Get todos los registros de auditoria desde el backend
  getAllLog(from, to){
    return this.http.get(this.UrlHost + 'sap/log/articulos' , { withCredentials:true, params:{ desde: from, hasta:to} } );
  }

  //Get todos los registros de logs desde el backend
  //con filtros por columnas
  getFilter(data){
    return this.http.post(this.UrlHost + 'sap/log/articulos/filtrar', data, { withCredentials:true } );
  }

  //Get Horas de ejecución del sistema 
  getLogsEstado(){
    return this.http.get(this.UrlHost + 'sap/articulos/estado' , { withCredentials:true });
  }

  // Get Programming 
  AddProgrammingOne(data){
    return this.http.post(this.UrlHost + 'sap/articulos/programar',data, { withCredentials:true });
  }

  // Get Programming 
  ejecutar(){
    return this.http.post(this.UrlHost + 'sap/articulos/ejecutar',{}, { withCredentials:true });
  }

  
}
