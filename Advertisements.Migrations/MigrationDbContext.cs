using Sev1.Advertisements.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Sev1.Advertisements.Migrations
{
    public class MigrationDbContext : BaseDbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) : base(options)
        {
        }
    }
}