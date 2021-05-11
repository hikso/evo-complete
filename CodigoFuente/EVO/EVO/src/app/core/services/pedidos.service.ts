import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PedidosService {

  UrlHost = environment.Urlserver + environment.UrlApi; //Variables globales de entornos

  constructor(private http: HttpClient) { }

  // Get todos los pedidos con estado abierto de planta desde el backend
  // from: paramétro número de registro final
  // to: parámetro número de registro inicial
  getAllApproved(from, to){
    return this.http.get(this.UrlHost + 'pedidos/aprobar', { withCredentials:true, params:{ desde: from, hasta:to} } );
  }

  // Get todos los pedidos con estado abierto de planta desde el backend
  // from: paramétro número de registro final
  // to: parámetro número de registro inicial
  getAllPurchaseOrders(data){
    return this.http.post(this.UrlHost + 'pedidos/compra/abierto/filtrar', data, { withCredentials:true } );
  }

    // Get todos los pedidos con estado abierto de planta desde el backend
  // from: paramétro número de registro final
  // to: parámetro número de registro inicial
  getPurchaseOrder(id){
    return this.http.get(this.UrlHost + 'pedidos/compra/gestion', { withCredentials:true, params:{ pedidoId:id } });
  }

  // Get motivos para la edición de las entregas
  // cuando la entrega tiene el estado Distribución
  getAcciones(){
    return this.http.get(this.UrlHost +'articulos/accion', { withCredentials: true} );
  }

  AddGestion(data){
    return this.http.post(this.UrlHost + 'articulos/compra/gestionar', data, { withCredentials: true} );
  }

  actualizarGestion(data){
    return this.http.post(this.UrlHost + 'articulos/compra/gestionar/actualizar', data, { withCredentials: true} );
  }

  finalizarDocumentoGestionCompra(data){
    return this.http.post(this.UrlHost + 'articulos/compra/gestionar/finalizar', data, { withCredentials: true} );
  }
  
  updateVehicle(data){
    return this.http.put(this.UrlHost + 'vehiculos/actualizar/vehiculo/enrutamiento', data, { withCredentials:true });
  }

  // Filtar tabla vista Pedidos Aprobados item pedido
  // data: parametros a filtrar
  getFilterApproved(data){
    return this.http.post(this.UrlHost +'pedidos/aprobar/filtrar', data, { withCredentials:true });
  }

  // Get todos los pedidos con estado aceptado y aceptado parcial de planta desde el backend
  // from: paramétro número de registro final
  // to: parámetro número de registro inicial
  getAllProgramming(from, to){
    return this.http.get(this.UrlHost + 'pedidos/aceptados', { withCredentials:true, params:{ desde: from, hasta:to} } );
  }

  // Filtar tabla vista programacion entregas item pedido
  // data: parametros a filtrar
  getFilterProgramming(data){
    return this.http.post(this.UrlHost +'pedidos/aceptados/filtrar', data, { withCredentials:true });
  }

  // Get todos los pedidos de planta beneficio desde el backend
  // from: parámetro número de registro final
  // to: parámetro número de registro inicial
  getAllPedidos(from, to){
    return this.http.get(this.UrlHost + 'pedidos/plantabeneficio', { withCredentials:true, params:{ desde: from, hasta:to} } );
  }

  // Filtar tabla vista Consulta pedidos item pedido
  // data: parametros a filtrar
  getFilterAll(data){
    return this.http.post(this.UrlHost +'pedidos/plantabeneficio', data, { withCredentials:true });
  }

  // Get Detalle del pedido por Id
  // id: parámetro key del pedido en base de datos
  getPedidoId(id){
    return this.http.get(this.UrlHost + 'pedidos/plantabeneficio/solicitud' , { withCredentials:true, params:{ id:id} });
  }

  getEntregasPendientes(id){
    return this.http.get(this.UrlHost + 'entregas/articulos/pendientes' , { withCredentials:true, params:{ entregaId:id } })
  }

  deleteArticleAtDelivery(data){
    return this.http.put(this.UrlHost + 'entregas/articulos/eliminar' , data, { withCredentials:true });
  }

  // Update Pedido: borrador o definitivo
  // data: datos del formulario para actualizar pedido
  updatePedido(data){
    return this.http.post(this.UrlHost +'pedidos/plantabeneficio/actualizar', data, { withCredentials:true });
  }

  // Get Entregas del pedido por Id
  // id: key del pedido en base de datos
  getEntregas(id){
    return this.http.get(this.UrlHost + 'pedidos/entregas/obtener', { withCredentials:true, params:{ id:id} });
  }

  // Post Agregar entragas a un pedido
  // data: parámetros del formulario para agregar entregas
  AddEntregas(data){
    return this.http.post(this.UrlHost + 'pedidos/entregas/agregar', data, { withCredentials:true });
  }

  // Post Eliminar Entrega por id
  // data: parámetros del formulario para eliminar entregas
  DeletedEntregas(data){
    return this.http.post(this.UrlHost + 'pedidos/entregas/eliminar', data, { withCredentials:true })
  }

  // Get de Entregas para editar
  // id: parametro de key de entregas en base de datos
  getEntregasId(id){
    return this.http.get(this.UrlHost + 'pedidos/entregas/id', { withCredentials:true, params:{ id:id} });
  }

  // Get motivos para la edición de las entregas
  // cuando la entrega tiene el estado Distribución
  getMotivos(){
    return this.http.get(this.UrlHost +'pedidos/entregas/motivos/obtener', { withCredentials: true} );
  }

  // Post Actualizar Entrega, fechas, y articulos
  // data: parámetros del formulario para actualizar entregas
  updateDelivery(data){
    return this.http.post(this.UrlHost + 'pedidos/distribucion/actualizar', data, { withCredentials:true });
  }

  // post enviar pedido a distribucion
  // data: parámetros del formulario para guardar pedido en distribuión
  SendDistribucion(data){
    return this.http.post(this.UrlHost + 'pedidos/entregas/estado/programado', data, { withCredentials:true });
  }

  // Get todos los pedidos en distribucion
  // from: parámetro número de registro final
  // to: parámetro número de registro inicial
  getAllDistribucion(from, to){
    return this.http.get(this.UrlHost + 'entregas/enrutamiento', { withCredentials:true, params:{ desde: from, hasta:to} } );
  }

  // Filtar tabla vista Distribucion item pedido
  // data: parametros a filtrar
  getFilter(data){
    return this.http.post(this.UrlHost +'pedidos/distribucion/filtrar', data, { withCredentials:true });
  }

  // Asociar Entregas a Vehiculos
  associateCars(data){
    return this.http.post(this.UrlHost+ 'pedidos/distribucion/asignarvehiculo', data, {withCredentials: true} );
  }

  // Vehiculos con entregas sin finalizar
  DeliveriesCars(){
    return this.http.get(this.UrlHost + 'pedidos/distribucion/vehiculos', {withCredentials: true});
  }

  // Get teh detail of the car 
  getDetalleCars(id){
    return this.http.get(`${this.UrlHost}pedidos/viajes/entregas`, { withCredentials:true, params:{ vehiculoEntregaId:id} });
  }

  getArticulosPendientes(id){
    return this.http.get(`${this.UrlHost}entregas/articulos/pendientes?entregaId=${id}`, { withCredentials:true })
  }

  // Delete an item from the delivery
  DeleteArticulo(id) {
    return this.http.delete(`${this.UrlHost}pedidos/entregas/articulo/eliminar?id=${id}`, { withCredentials: true });
  }

  // Save it the delivery with the date and items updated
  saveEditEntrega(data) {
    return this.http.post(`${this.UrlHost}pedidos/entrega/actualizar`, data, { withCredentials: true });
  }

}
