using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Procedimientos_Citas_DTO
    {
        [Key]
        public int citas_ID { get; set; }
        [Required]
        [Display(Name = "procedimiento_ID")]
        public int procedimiento_ID { get; set; }
        [Required]
        [Display(Name = "fecha")]
        public string fecha { get; set; }

    }
}
