using System;
using System.Collections.Generic;
using System.Text;
using IntegracionBasculasPorcicarnes.Adapter;

namespace IntegracionBasculasPorcicarnes
{
    //Esta clase solo sirve para referenciar los TODO en un solo lugar, no debe conservarse en la solución. Se elimina, cuándo se solucionen los TODOs.
    class TODOs
    {
        //TODO: Implementar mensajes en archivos de recursos
        //TODO: Eliminar las métodos que no se estén llamando desde ninguna parte
        //TODO: Eliminar las clases que no se estén llamando desde ninguna parte
        public void test()
        {
            /*
             * AGiraldo: Aquí encontrará un ejemplo de cómo implementar una instancia de una báscula dibal en la estructura DibalScale.
             * 
             * masterAddress = masterAddress es un número del 0 al 99 que sirve para definir la dirección maestra de la báscula.
             *                 La báscula que tenga el valor masterAddress en 0, es la báscula maestra en un punto de venta.
             *                 //TODO: EParales: ¿Qué numeración deben tener las demás básculas que no son las maestras?
             *                                   Definir un escenario de un Punto de Venta con 9 básculas esclavas y una maestra.
             *                                   ¿Se pueden repetir valores de masterAddress?
             * IpAddress = La dirección IP de la báscula
             * txPort = 
             * rxPort = 
             * model = 
             * display = 
             * section = _section;
             * group = _group;
             * this.logsPath = _logsPath;
             */
            DibalScale x = new DibalScale(1, "", 1, 1, "", "", "", 1, "");
        }
    }
}
