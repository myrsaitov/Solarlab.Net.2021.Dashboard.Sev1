using DemoApi.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Migrations
{
    public class MigrationDbContext : BaseDbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) : base(options)
        {
        }
    }
}