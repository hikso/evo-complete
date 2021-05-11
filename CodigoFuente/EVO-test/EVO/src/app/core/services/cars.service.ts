import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CarsService {

  UrlHost = environment.Urlserver + environment.UrlApi; // Variables globales de entornos

  constructor(private http: HttpClient) { }

  // Get obtener todos los tipos de vehiculos
  getTypeCars() {
    return this.http.get(this.UrlHost + 'vehiculos/tipovehiculo' , { withCredentials: true } );
  }

  getTypeCarsByWeight(weight) {
    return this.http.get(`${this.UrlHost}vehiculos/tiposvehiculo/filtrados?cantidadEntrega=${weight}` , { withCredentials: true } );
  }

  // Get obtener los vehiculos por tipo de vehiculo
  // Params id: corresponde al id del tipo de vehiculo
  getCars(id) {
    return this.http.get(this.UrlHost + 'vehiculos' , { withCredentials: true, params: { id } });
  }

  // Get obtener todos los conductores 
  getAllDriver() {
    return this.http.get(this.UrlHost + 'vehiculos/conductoresyauxiliares' , { withCredentials: true });
  }

  // Get obtener todos los conductores 
  getAllMuelles(){
    return this.http.get(this.UrlHost + 'vehiculos/muelles' , { withCredentials:true});
  }
  
}
