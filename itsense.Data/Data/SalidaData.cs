using itsense.Data.Interface;
using itsense.Models;
using itsense.ModelsDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Data.Data
{
    public class SalidaData : ISalida
    {
        readonly ContextDBItsense DB;
        public SalidaData(ContextDBItsense db)
        {
            DB = db;
        }
        public async Task<bool> Create(Salida salida)
        {
            await DB.Salidas.AddAsync(salida);
            await DB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await DB.Salidas.FindAsync(id);

            if (result != null)
            {
                var res = DB.Salidas.Remove(result);
                await DB.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<EntradaAndSalidaDto>> Get()
        {
            return await DB.Salidas.Join(DB.Productos, E => E.ProductoId, P => P.Id, (E, P) => new { E, P })
                .Select(x => new EntradaAndSalidaDto()
                {
                    Id = x.E.Id,
                    ProductoId = x.E.ProductoId,
                    Count = x.E.Count,
                    Date = x.E.Date,
                    Name = x.P.Name
                })
                .ToListAsync();
        }

        public async Task<bool> Update(Salida salida)
        {
            var result = await DB.Salidas.FindAsync(salida.Id);

            if (result != null)
            {
                result.Count = salida.Count;



                DB.Salidas.Update(result);
                await DB.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
