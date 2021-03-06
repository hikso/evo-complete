/*
 * API de Roles de Usuario
 *
 * API de administración de Roles de usuario
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.RolesApi
{
    /// <summary>
    /// Objeto que contiene el Rol a crear
    /// </summary>
    [DataContract]
    public partial class CrearRolRequest : IEquatable<CrearRolRequest>
    {
        /// <summary>
        /// Nombre del rol que será registrado
        /// </summary>
        /// <value>Nombre del rol que será registrado</value>
        [Required]
        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Indica si el rol tiene acceso a el modulo de Planta de Beneficio
        /// </summary>
        /// <value>Indica si el rol tiene acceso a el modulo de Planta de Beneficio</value>
        [DataMember(Name = "PlantaBeneficio")]
        public bool? PlantaBeneficio { get; set; }

        /// <summary>
        /// Indica si el rol tiene acceso a el modulo de Planta de Derivados Carnicos
        /// </summary>
        /// <value>Indica si el rol tiene acceso a el modulo de Planta de Derivados Carnicos</value>
        [DataMember(Name = "PlantaDerivadosCarnicos")]
        public bool? PlantaDerivadosCarnicos { get; set; }

        /// <summary>
        /// Indica si el rol tiene acceso a el modulo de Puntos de Venta
        /// </summary>
        /// <value>Indica si el rol tiene acceso a el modulo de Puntos de Venta</value>
        [DataMember(Name = "PuntosVenta")]
        public bool? PuntosVenta { get; set; }

        /// <summary>
        /// Indica si el rol tiene acceso a el modulo de Administracion
        /// </summary>
        /// <value>Indica si el rol tiene acceso a el modulo de Administracion</value>
        [DataMember(Name = "Administracion")]
        public bool? Administracion { get; set; }

        /// <summary>
        /// Ids de las Funcionalidades a las que el Rol está autorizado
        /// </summary>
        /// <value>Ids de las Funcionalidades a las que el Rol está autorizado</value>
        [DataMember(Name = "funcionalidadesIds")]
        public List<int> FuncionalidadesIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CrearRolRequest {\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
            sb.Append("  PlantaBeneficio: ").Append(PlantaBeneficio).Append("\n");
            sb.Append("  PlantaDerivadosCarnicos: ").Append(PlantaDerivadosCarnicos).Append("\n");
            sb.Append("  PuntosVenta: ").Append(PuntosVenta).Append("\n");
            sb.Append("  Administracion: ").Append(Administracion).Append("\n");
            sb.Append("  FuncionalidadesIds: ").Append(FuncionalidadesIds).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CrearRolRequest)obj);
        }

        /// <summary>
        /// Returns true if CrearRolRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of CrearRolRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CrearRolRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Nombre == other.Nombre ||
                    Nombre != null &&
                    Nombre.Equals(other.Nombre)
                ) &&
                (
                    PlantaBeneficio == other.PlantaBeneficio &&
                    PlantaBeneficio.Equals(other.PlantaBeneficio)
                ) &&
                (
                    PlantaDerivadosCarnicos == other.PlantaDerivadosCarnicos &&
                    PlantaDerivadosCarnicos.Equals(other.PlantaDerivadosCarnicos)
                ) &&
                (
                    PuntosVenta == other.PuntosVenta &&
                    PuntosVenta.Equals(other.PuntosVenta)
                ) &&
                (
                    Administracion == other.Administracion &&
                    Administracion.Equals(other.Administracion)
                ) &&
                (
                    FuncionalidadesIds == other.FuncionalidadesIds ||
                    FuncionalidadesIds != null &&
                    FuncionalidadesIds.SequenceEqual(other.FuncionalidadesIds)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();                
                    hashCode = hashCode * 59 + PlantaBeneficio.GetHashCode();              
                    hashCode = hashCode * 59 + PlantaDerivadosCarnicos.GetHashCode();              
                    hashCode = hashCode * 59 + PuntosVenta.GetHashCode();               
                    hashCode = hashCode * 59 + Administracion.GetHashCode();
                if (FuncionalidadesIds != null)
                    hashCode = hashCode * 59 + FuncionalidadesIds.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CrearRolRequest left, CrearRolRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CrearRolRequest left, CrearRolRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
