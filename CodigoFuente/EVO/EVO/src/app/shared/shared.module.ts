import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { DecimalnumberPipe } from "./pipes/decimalnumber.pipe";
import { FooterComponent } from './components/footer/footer.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { SplashComponent  } from './components/splash/splash.component';
import { LoadingComponent  } from './components/loading/loading.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
  ],
  declarations: [
    DecimalnumberPipe,
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    SplashComponent,
    LoadingComponent
  ],
  exports: [
    DecimalnumberPipe,
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    SplashComponent,
    LoadingComponent
  ]
})
export class SharedModule { }