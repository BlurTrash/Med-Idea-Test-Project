using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.EntityModels
{
    class ClinicDbContext: DbContext
    {
        public DbSet<PatientCard> PatientCardDbSet { get; set; }
        public DbSet<Request> RequestDbSet { get; set; }

        public ClinicDbContext() : base() 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = "server=(localdb)\\MSSQLLocalDB;database=ClinicDb;Trusted_Connection=true;";
            var connection = ConfigurationManager.ConnectionStrings["Test"].ToString();
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
