//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CandidatosSistema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Candidato
    {
        public int CandidatoId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public Nullable<int> LocalidadId { get; set; }
        public Nullable<int> SueldoId { get; set; }
        public Nullable<int> EscolaridadId { get; set; }
        public Nullable<int> EspecialidadId { get; set; }
        public Nullable<bool> EstadoCandidato { get; set; }
        public string Capturista { get; set; }
        public Nullable<System.DateTime> FechaCaptura { get; set; }
        public string Archivo { get; set; }
    
        public virtual Escolaridad Escolaridad { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual Sueldo Sueldo { get; set; }
        public virtual Especialidad Especialidad { get; set; }
    }
}
