import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { SettingService } from 'src/app/core/services/setting.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  test : Date = new Date();
  version: any ;
  
  constructor(private router: Router, private setting: SettingService) { }

  ngOnInit() {
    this.GetVersion();
  }


  // Obtener version actual de la aplicación.
  GetVersion(){
    this.setting.getVersion().subscribe( 
      res => {
        this.version = res.version;
      }
    );
  }
}
