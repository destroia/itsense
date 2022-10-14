using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PeoductoId { get; set; }
        [Required]
        public int Optimos { get; set; }
        [Required]
        public int Defectuosos { get; set; }
    }
}
