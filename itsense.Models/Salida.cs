using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Models
{
    public class Salida
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
