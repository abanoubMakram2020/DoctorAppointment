using DoctorAppointment.Infrastructure.EntitiesConfigurations;
//using KSU.OutSourcing.Infrastructure.SeedData;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Infrastructure.SQLContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public static void Configure(DbContextOptionsBuilder<ApplicationDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        #region DbSets
        //public DbSet<LeadershipType> SampleEntity { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            try
            {
                #region Schema Configurations
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(CandidateCourseConfigurations).Assembly);
                #endregion

                //#region Start Seed Data
                //modelBuilder.StartSeedData();
                //#endregion
            }
            catch
            {
                throw;
            }
        }

    }
}
