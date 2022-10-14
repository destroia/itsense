using itsense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Data.Interface
{
    public interface ISalida
    {
        Task<List<Salida>> Get();
        Task<bool> Create(Salida salida);
        Task<bool> Update(Salida salida);
        Task<bool> Delete(int id);
    }
}
