using itsense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Data.Interface
{
    public interface IStock
    {
        Task<List<Stock>> Get();
        Task<bool> Create(Stock stock);
        Task<bool> Update(Stock stock);
    }
}
