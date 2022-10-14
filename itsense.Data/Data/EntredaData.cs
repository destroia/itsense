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
    public class EntredaData : IEntrada
    {
        readonly ContextDBItsense DB;
        public EntredaData(ContextDBItsense db)
        {
            DB = db;
        }
        public async Task<bool> Create(Entrada entrada)
        {
            await DB.Entradas.AddAsync(entrada);
            await DB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await DB.Entradas.FindAsync(id);

            if (result != null)
            {
                var res = DB.Entradas.Remove(result);
                await DB.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async  Task<List<Entrada>> Get()
        {
            return await DB.Entradas.ToListAsync();
        }

        public async Task<bool> Update(Entrada entrada)
        {
            var result = await DB.Entradas.FindAsync(entrada.Id);

            if (result != null)
            {
                result.Count = entrada.Count;
                result.Date = entrada.Date;

                DB.Entradas.Update(result);
                await DB.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
