//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldParkingVol1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vehiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vehiculos()
        {
            this.facturacion = new HashSet<facturacion>();
        }
    
        public int idVehiculos { get; set; }
        public string Placa { get; set; }
        public int Color { get; set; }
        public int Modelo { get; set; }
        public int Marca { get; set; }
        public int TipoVehiculo { get; set; }
    
        public virtual colorvehiculo colorvehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<facturacion> facturacion { get; set; }
        public virtual marcasvehiculo marcasvehiculo { get; set; }
        public virtual tipovehiculo tipovehiculo1 { get; set; }
    }
}