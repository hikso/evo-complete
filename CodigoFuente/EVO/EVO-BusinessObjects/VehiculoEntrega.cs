using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 19-Dic/2019
    /// Descripción     : Clase que representa un objeto de negocio de un VehiculoEntrega
    /// </summary>
    public class VehiculoEntrega
    {       
        public int VehiculoEntregaId { get; set; }
     
        public int UsuarioId { get; set; }
     
        public int VehiculoId { get; set; }
      
        public int ConductorId { get; set; }
      
        public int AuxiliarId { get; set; }  
        
        public decimal PesoEntregas { get; set; }
        
        public DateTime FechaRegistro { get; set; }

        public ICollection<VehiculoEntregaDetalle> Detalles { get; set; }
    }
}
