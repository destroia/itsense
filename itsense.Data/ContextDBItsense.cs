using itsense.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Data
{
    public class ContextDBItsense : DbContext
    {
        //public ContextDBItsense(DbContextOptions<ContextDBItsense> opt): base(opt)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(

             "Data Source=.;Initial Catalog=ItsenseDB;Integrated Security=true"
             );
            base.OnConfiguring(optionsBuilder);
            //Primer Migracion   Add-Migration InitialCreate
            //Despues de la primera migracion se utiliza  Update-Database
        }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Salida> Salidas { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
