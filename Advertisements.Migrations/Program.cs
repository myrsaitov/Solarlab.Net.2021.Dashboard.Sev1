using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoApi.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
 
            var optionsBuilder = new DbContextOptionsBuilder<MigrationDbContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
 
            using (MigrationDbContext db = new MigrationDbContext(options))
            {
                db.Database.Migrate();
            }
        }
    }
}