using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Citas_DTO
    {
        [Key]
        public int ID_citas { get; set; }
        [Required]
        [Display(Name = "doctor_ID")]
        public int doctor_ID { get; set; }
        [Required]
        [Display(Name = "paciente_ID")]
        public int paciente_ID { get; set; }
        [Required]
        [Display(Name = "fecha")]
        public Nullable<System.DateTime> fecha { get; set; }

        [Required]
        [Display(Name = "hora")]
        public string hora { get; set; }
        [Required]
        [Display(Name = "motivo")]
        public string motivo { get; set; }

    }
}
