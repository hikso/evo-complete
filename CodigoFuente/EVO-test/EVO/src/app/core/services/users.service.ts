import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

    UrlHost = environment.Urlserver + environment.UrlApi; //Variables globales de entornos

    constructor(private http: HttpClient) { }

    getUser() {
        return this.http.get(this.UrlHost + 'usuarios/obtenerusuario', { withCredentials:true } );
    }
}

