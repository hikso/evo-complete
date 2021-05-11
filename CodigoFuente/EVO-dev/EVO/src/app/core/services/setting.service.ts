import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SettingService {

  UrlHost = environment.Urlserver + environment.UrlApi; //Variables globales de entornos
  registertable = {
    valor: String,
    date: Date(),
  }
  

  constructor(private http: HttpClient) { }

  //Ultima versión de la aplicación.
  getVersion(){
    return this.http.get<any>(this.UrlHost + 'config/obtenerversionactual', {withCredentials:true});
  }

  // Valor maximo de registro por tablas
  // name: nombre  de la variable en base de datos
  getGeneralParam(name){
    return this.http.get<any>(this.UrlHost + 'parametrosgenerales/obtenerxnombre/' + name, {withCredentials:true});
  }

  getMotivos(id){
    return this.http.get<any>(this.UrlHost + 'motivos', {withCredentials:true, params:{ procesoId: id }});
  }
  // Validar Cache
  // Se actualiza despues de 24 horas
  // Funcion Global para cualquier dato en localStorage
  // generalParamLocalName: nombre para el registro en localstorage
  //  generalParamDBName: nombre  de la variable en base de datos
  getRegisterLocalStorage(generalParamName){
    this.registertable = JSON.parse(localStorage.getItem(generalParamName));

    if(this.registertable){
        //LocalStorage existente
        let currentDate = new Date();
        let diff = Math.abs(currentDate.getTime() - new Date(this.registertable.date).getTime()) / 3600000;

        if(diff >= 0.001){ 
            return this.saveParamAtLocalStorage(generalParamName);
        }else{
            return this.registertable;
        }
    }else{
      //LocalStorage vacio
      return this.saveParamAtLocalStorage(generalParamName); 
    }
   
  }

  // Guardar LocalStorage
  // generalParamLocalName: nombre para el registro en localstorage
  //  generalParamDBName: nombre  de la variable en base de datos
  saveParamAtLocalStorage(generalParamName){
    this.getGeneralParam(generalParamName).subscribe(
      res => {
        const dataTosave = {
            valor: res.valor,
            date: Date(),
        }
        localStorage.setItem(generalParamName, JSON.stringify(dataTosave) );
      }
    );

    return JSON.parse(localStorage.getItem(generalParamName));
  }


}
