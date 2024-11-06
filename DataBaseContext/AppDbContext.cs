using Microsoft.EntityFrameworkCore;
using ChariTov.Models;

namespace ChariTov.DataBaseContext
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Contribution> Contributions { get; set; }

        public DbSet<ContributionType> ContributionTypes { get; set; }


    }
}
