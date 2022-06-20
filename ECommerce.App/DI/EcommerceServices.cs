using ECommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.App.DI
{
    public static class EcommerceServices
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, string connection)
        {
            services.AddDbContext<SalesDbContext>(options => options.UseSqlServer(connection));
            return services;
        }
    }
}
