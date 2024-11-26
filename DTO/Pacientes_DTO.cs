using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Pacientes_DTO
    {
        [Key]
        public int ID_paciente { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "fecha_nacimiento")]
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        [Required]
        [Display(Name = "telefono")]
        public string telefono { get; set; }
        [Required]
        [Display(Name = "direccion")]
        public string direccion { get; set; }

    }
}
