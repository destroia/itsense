using itsense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Data.Interface
{
    public interface IEntrada
    {
        Task<List<Entrada>> Get();
        Task<bool> Create(Entrada entrada);
        Task<bool> Update(Entrada entrada);
        Task<bool> Delete(int id);

    }
}
