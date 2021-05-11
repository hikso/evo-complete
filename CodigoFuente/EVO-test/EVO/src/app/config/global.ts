// Archivo varibales globales.

export const UrlServer = {    
   UrlApi:'EVO_WebApi/api/'
}

// Estados del pedido
export const stateOrderList = {
   abierto: 'Abierto',
   aceptado: 'Aceptado',
   parcial: 'Aceptado Parcial',
   distribucion: 'Distribución',
   enrutamiento: 'Enrutamiento',
   alistamiento: 'Alistamiento'
}

export const calendarFormat = {
   firstDayOfWeek: 1,
   dayNames: [ "domingo","lunes","martes","miércoles","jueves","viernes","sábado" ],
   dayNamesShort: [ "dom","lun","mar","mié","jue","vie","sáb" ],
   dayNamesMin: [ "D","L","M","X","J","V","S" ],
   monthNames: [ "Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" ],
   monthNamesShort: [ "ene","feb","mar","abr","may","jun","jul","ago","sep","oct","nov","dic" ],
   today: 'Hoy',
   clear: 'Borrar'
}

export const generalParamNames = {
   MODIFICACION_DE_ENTREGA: 'MODIFICACION_DE_ENTREGA',
   ELIMINACION_DE_ARTICULO_EN_ENTREGA: 'ELIMINACION_DE_ARTICULO_EN_ENTREGA',
  //Guardar en localstorage variable parametrizable para max registro en tablas
   TAMANHO_PAGINACION_WEBAPI: 'TAMANHO_PAGINACION_WEBAPI',
  //Guardar en localstorage variable parametrizable para decimales 
   MAXIMO_DECIMALES:'MAXIMO_DECIMALES',
  //Guardar en localstorage variable parametrizable para decimales 
   MINIMO_DECIMALES: 'MINIMO_DECIMALES',
  //Guardar en localstorage variable parametrizable para Expresión regular parametrizable  
   EXPRESION_REGULAR_ENTERO_DECIMAL: 'EXPRESION_REGULAR_ENTERO_DECIMAL',
   //Me indica si debo validar las ordenes de compra
   GUARDAR_GESTION_COMPRA_CON_ORDENES: 'GUARDAR_GESTION_COMPRA_CON_ORDENES'
}