using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Especialidades_DTO
    {
        [Key]
        public int ID_especialidad { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

    }
}
