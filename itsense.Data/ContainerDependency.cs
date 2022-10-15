using itsense.Data.Data;
using itsense.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itsense.Data
{
    public static class ContainerDependency
    {
        public static IServiceCollection AddInjData(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<ContextDBItsense>(
                options => options.UseSqlServer(configuration.GetConnectionString("ConnectionMain")));

            services.AddScoped<IEntrada, EntredaData>();
            services.AddScoped<IProducto, ProductoData>();
            services.AddScoped<ISalida, SalidaData>();
           

            return services;
        }
    }
}
