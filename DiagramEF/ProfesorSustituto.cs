//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiagramEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProfesorSustituto
    {
        public string Sustituido { get; set; }
        public Nullable<System.DateTime> FechaFinalizacion { get; set; }
    
        public virtual Profesor Profesor { get; set; }
    }
}
