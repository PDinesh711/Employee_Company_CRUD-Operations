using Microsoft.EntityFrameworkCore;
using Webb.Models;

namespace Webb.Database
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext(DbContextOptions options):base(options)
        {
        }

        //DbSet
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companys { get; set; }
    }
}
