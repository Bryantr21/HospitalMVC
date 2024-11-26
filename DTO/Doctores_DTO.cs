using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Doctores_DTO
    {
        [Key]
        public int ID_doctor { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Required]
        [Display(Name = "especialidad_ID")]
        public string especialidad_ID { get; set; }

    }
}
