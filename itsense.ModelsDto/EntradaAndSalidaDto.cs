using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.ModelsDto
{
    public class EntradaAndSalidaDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}
