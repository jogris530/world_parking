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
    
    public partial class historicoactpersonas
    {
        public int idHistoricoActPersonas { get; set; }
        public int idPersonas { get; set; }
        public System.DateTime FechaEdicion { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int TipoDocumento { get; set; }
        public int Rol { get; set; }
        public bool Activo { get; set; }
        public int Sexo { get; set; }
    }
}