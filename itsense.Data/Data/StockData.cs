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
    public class StockData : IStock
    {
        readonly ContextDBItsense DB;
        public StockData(ContextDBItsense db)
        {
            DB = db;
        }
        public async Task<bool> Create(Stock stock)
        {
            await DB.Stocks.AddAsync(stock);
            await DB.SaveChangesAsync();
            return true;
        }

        public async Task<List<Stock>> Get()
        {
            return await DB.Stocks.ToListAsync();
        }

        public async Task<bool> Update(Stock stock)
        {
            var result = await DB.Stocks.FindAsync(stock.Id);

            if (result != null)
            {
                result.Optimos = stock.Optimos;
                result.Defectuosos = stock.Defectuosos;


                DB.Stocks.Update(result);
                await DB.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
