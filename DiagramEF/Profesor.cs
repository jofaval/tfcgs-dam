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
    
    public partial class Profesor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesor()
        {
            this.Impartimiento = new HashSet<Impartimiento>();
        }
    
        public string Trabajador { get; set; }
        public System.DateTime FechaIncorporacion { get; set; }
        public string Departamento { get; set; }
    
        public virtual Departamento Departamento1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Impartimiento> Impartimiento { get; set; }
        public virtual Trabajador Trabajador1 { get; set; }
        public virtual ProfesorSustituto ProfesorSustituto { get; set; }
    }
}
