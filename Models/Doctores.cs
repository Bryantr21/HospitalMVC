//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctores()
        {
            this.Citas = new HashSet<Citas>();
        }
    
        public int ID_doctor { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public int especialidad_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }
        public virtual Especialidades Especialidades { get; set; }
    }
}
