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
    
    public partial class historicofacturacion
    {
        public int idHistoricoFacturacion { get; set; }
        public int NumeroFactura { get; set; }
        public int IdVehiculo { get; set; }
        public int IdPersona { get; set; }
        public System.DateTime FechaEntrada { get; set; }
        public System.DateTime FechaSalida { get; set; }
        public int Bahia { get; set; }
        public int FacturaPermanente { get; set; }
        public double ValorPagado { get; set; }
        public System.DateTime FechaEdicion { get; set; }
        public string DetalleObservaciones { get; set; }
    }
}
