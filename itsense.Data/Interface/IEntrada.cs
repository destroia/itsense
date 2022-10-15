using itsense.Models;
using itsense.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Data.Interface
{
    public interface IEntrada
    {
        Task<List<EntradaAndSalidaDto>> Get();
        Task<bool> Create(Entrada entrada);
        Task<bool> Update(Entrada entrada);
        Task<bool> Delete(int id);

    }
}
