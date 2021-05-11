import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { generalParamNames } from 'src/app/config/global';
import { debug } from 'util';

import { SettingService } from 'src/app/core/services/setting.service';

@Component({
  selector: 'app-splash',
  templateUrl: './splash.component.html',
  styleUrls: ['./splash.component.scss']
})
export class SplashComponent implements OnInit {

  version: any;
  f;

  constructor(private router: Router, private setting: SettingService) { }

  ngOnInit() {
    localStorage.clear();
    this.GetVersion();
    Object.keys(generalParamNames).forEach(name => this.setGeneralParamsToStorage(name));

    setTimeout(() => {
      this.home();
    },4000);
  }

  setGeneralParamsToStorage(generalParamName){
    this.setting.getGeneralParam(generalParamName).subscribe(
      res => {
        const data = {
            'valor': res.valor,
            'date': Date(),
        }
        localStorage.setItem(generalParamName, JSON.stringify(data) );
      }
    )
  }
  // Obtener version actual de la aplicación.
  GetVersion(){
    this.setting.getVersion().subscribe( 
      res => {
        this.version = res.version;
      }
    );
  }

  // Redirect para página principal home
  home(){
    this.router.navigate(['/home']);
  }

}
