using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SharedKernal.Common.Configuration;
using System.IO;

namespace DoctorAppointment.Infrastructure.SQLContext
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static DbContextOptions<ApplicationDbContext> Get(IConfiguration configuration)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            ApplicationDbContext.Configure(builder, DatabaseConfiguration.ConnectionString);
            return builder.Options;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseNpgsql(DatabaseConfiguration.ConnectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
