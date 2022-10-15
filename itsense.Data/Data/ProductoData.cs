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
    public class ProductoData : IProducto
    {
        readonly ContextDBItsense DB;
        public ProductoData(ContextDBItsense db)
        {
            DB = db;
        }
        public async Task<bool> Create(Producto pro)
        {
            pro.Name = pro.Name.Trim();

            await DB.Productos.AddAsync(pro);
            await DB.SaveChangesAsync();
            return true;
        }

        public async Task<List<Producto>> Get()
        {
            return await DB.Productos
                .ToListAsync();     
        }

        public async Task<Producto> GetById(int id)
        {
            return await DB.Productos.FindAsync(id);
        }

        public async Task<bool> Update(Producto pro)
        {
            var result = await DB.Productos.FindAsync(pro.Id);

            if (result != null)
            {
                pro.Name = pro.Name.Trim();

                result.Name = pro.Name;
                result.CantOptimo = pro.CantOptimo;
                result.CantDefectuoso = pro.CantDefectuoso;

                DB.Productos.Update(result);
                await DB.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
