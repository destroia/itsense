using itsense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Data.Interface
{
    public interface IProducto
    {
        Task<List<Producto>> Get();
        Task<Producto> GetById(int id);
        Task<bool> Create(Producto pro);
        Task<bool> Update(Producto pro);
    }
}
