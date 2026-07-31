using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.EFCore.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;


namespace Repositories.EFCore
{
    //Actual Database Structure
    public class RepositoryContext : IdentityDbContext<User>
    {
        public DbSet<Book> Books { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.ApplyConfiguration(new BookConfig());
            // modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // EF Core 9'un otomatik GUID/Seed engeline takılmasını önler:
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }


    }
}