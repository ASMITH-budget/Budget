using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Budget.Mssql
{
     public partial class AppDbContext : DbContext
    {
           public DbSet<UnitOfElementDTO> Units { get; set; }
    }
}