import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuditService {

  UrlHost = environment.Urlserver + environment.UrlApi; //Variables globales de entornos

  constructor(private http: HttpClient) { }


  //Get todos los registros de auditoria desde el backend
  getAllAudit(from, to){
    return this.http.get(this.UrlHost + 'auditoria', { withCredentials:true, params:{ desde: from, hasta:to} } );
  }

  //Get todos los registros de auditoria desde el backend
  //con filtros por columnas
  getFilter(data){
    return this.http.post(this.UrlHost + 'auditoria/filtrar/', data, { withCredentials:true } )
  }

}
