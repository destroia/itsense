using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength =4,ErrorMessage ="El nombre es requerido el minimo son 4 caracteres y el maximo son 200 caracteres")]
        public string Name { get; set; }
        [Required]
        public int CantOptimo { get; set; }
        [Required]
        public int CantDefectuoso { get; set; }

    }
}
