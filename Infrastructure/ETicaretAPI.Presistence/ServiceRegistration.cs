using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Presistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Presistence
{
    public static class ServiceRegistration
    {
        public static void AddPresistenceService(this IServiceCollection services) {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        }
    }
}
