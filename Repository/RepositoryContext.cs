using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;


namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfigration());
            modelBuilder.ApplyConfiguration(new EmployeeConfigration());
            modelBuilder.Entity<Company>().
                HasMany(c => c.Employees).
                WithOne(e => e.Company).
                HasForeignKey(e => e.CompanyId).
                OnDelete(DeleteBehavior.Cascade);



        }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }
    }
}
