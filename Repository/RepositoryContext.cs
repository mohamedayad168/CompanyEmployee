using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;




namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfigration());
            modelBuilder.ApplyConfiguration(new EmployeeConfigration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
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
