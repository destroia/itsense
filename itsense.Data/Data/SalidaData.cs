using itsense.Data.Interface;
using itsense.Models;
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

        public async Task<List<Salida>> Get()
        {
            return await DB.Salidas.ToListAsync();
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
