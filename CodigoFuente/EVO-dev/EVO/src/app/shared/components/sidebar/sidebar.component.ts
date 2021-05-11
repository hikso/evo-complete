import { Component, OnInit } from '@angular/core';
import PerfectScrollbar from 'perfect-scrollbar';
import { UsersService } from '../../../core/services/users.service';

declare const $: any;

//Metadata
export interface RouteInfo {
    path: string;
    title: string;
    type: string;
    icontype: string;
    collapse?: string;
    children?: ChildrenItems[];
}

export interface ChildrenItems {
    path: string;
    title: string;
    ab: string;
    type?: string;
    show?: boolean;
}

export const ROUTES: RouteInfo[] = [
  { 
    path: '/configuracion/dashboard', 
    title: 'Inicio',  
    icontype: 'dashboard', 
    type: 'link',
  },
  { 
    path: '/pedidos',
    title: 'Gestión Pedidos',
    type: 'sub',
    icontype:'playlist_add_check',
    collapse: 'pedidos',
    children: [
      {path: 'aprobar', title: 'Aprobación Pedidos', ab:'AP'}, //vista de pedidos con estado abierto
      {path: 'programar', title: 'Programación Entregas', ab:'PE'}, //vista con pedidos con estado aceptado o aceptado parcial
      {path: 'consulta', title: 'Consulta Estado', ab:'CS'} //vista actual de aprobación de pedidos
    ]
  },
  { 
    path: '/pedidos',
    title: 'Gestión Compras',
    type: 'sub',
    icontype:'attach_money',
    collapse: 'pedidoscompras',
    children: [
      {path: 'compras', title: 'Consulta Solicitudes', ab:'CS'} //vista actual de aprobación de pedidos
    ]
  },
//   { 
//     path: '/produccion',
//     title: 'Producción',
//     type: 'sub',
//     icontype:'attach_money',
//     collapse: 'produccion',
//     children: [
//       {path: 'programacion', title: 'Programación Producción PB', ab:'PPB'} //vista actual de aprobación de pedidos
//     ]
//   },
//   { 
//     path: '/distribucion',
//     title: 'Distribucion',
//     type: 'sub',
//     icontype:'directions_bus',
//     collapse: 'distribucion',
//     children: [
//       {path: 'enrutamiento', title: 'Enrutamiento', ab:'E'},
//       {path: '', title: 'Alistamiento', ab:'A'}, 
//       {path: '', title: 'Cargue de Vehículo', ab:'CV'},
//       {path: '', title: 'Bascula Camionera', ab:'BC'},
//       {path: '', title: 'Entrega Cliente', ab:'EC'} 
//     ]
//   },
//   { 
//     path: '/consultas',
//     title: 'Consultas',
//     type: 'sub',
//     icontype:'format_list_numbered',
//     collapse: 'consultas',
//     children: [
//       {path: 'ctransporte', title: 'Costo Transporte', ab:'CT'}
//     ]
//   },
  { 
    path: '/configuracion',
    title: 'Configuración',
    type: 'sub',
    icontype:'build',
    collapse: 'configuracion',
    children: [
      {path: 'auditoria', title: 'Auditoria', ab:'A'},
      {path: 'adminrol', title: 'Administrador de Rol', ab:'AR'},
      {path: 'sap-articulos', title: 'Sap Articulos', ab:'SA'}
    ]
  },

];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  ps: any;
  user: any;
  userActive: boolean = false;
  constructor(private userService: UsersService) {}

  isMobileMenu() {
    if ($(window).width() > 991) {
      return false;
    }
    return true;
  };

  ngOnInit() {
    this.userService.getUser().subscribe((user)=>{
        this.user = user;
        this.userActive = true;
        ROUTES.map(routes => {
            if (routes.children) {
                routes.children.map(child => {
                    child.show = true;
                    if (child.path === 'auditoria') {
                        child.show = this.user.administrador;
                    }
                });   
            }
        });
        this.menuItems = ROUTES.filter(menuItem => menuItem);
    });

    if (window.matchMedia(`(min-width: 960px)`).matches && !this.isMac()) {
      const elemSidebar = <HTMLElement>document.querySelector('.sidebar .sidebar-wrapper');
      this.ps = new PerfectScrollbar(elemSidebar);
    }
  }

  updatePS(): void  {
    if (window.matchMedia(`(min-width: 960px)`).matches && !this.isMac()) {
      this.ps.update();
    }
  }

  isMac(): boolean {
    let bool = false;
    if (navigator.platform.toUpperCase().indexOf('MAC') >= 0 || navigator.platform.toUpperCase().indexOf('IPAD') >= 0) {
        bool = true;
    }
    return bool;
  }

}
