using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Budget.Mssql
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            //we use db migration 
            //Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var confString = new ConfigurationBuilder();
            // set path to the current directory
            confString.SetBasePath(Directory.GetCurrentDirectory());
            // geting config from appsettings.json
            confString.AddJsonFile("appsettings.json");
            // create configuration
            var config = confString.Build();
            // get connection string
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UnitOfElementConfig());
        }
        
    }
}