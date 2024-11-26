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
    
    public partial class Citas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Citas()
        {
            this.Procedimientos_Citas = new HashSet<Procedimientos_Citas>();
        }
    
        public int ID_cita { get; set; }
        public int doctor_ID { get; set; }
        public int paciente_ID { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora { get; set; }
        public string motivo { get; set; }
    
        public virtual Doctores Doctores { get; set; }
        public virtual Pacientes Pacientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Procedimientos_Citas> Procedimientos_Citas { get; set; }
    }
}
