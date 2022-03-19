using ETicaretAPI.Presistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Presistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
    {
        /// <summary>
        /// Sadece console ile işlem yapmamız gerektiği durumlarda bu ayarları kullanarak migration işlemleri gerçekleşir.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public ETicaretAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);

            return new ETicaretAPIDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
