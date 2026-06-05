using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.EFCore.Config;


namespace Repositories.EFCore
{
    //Actual Database Structure
    public class RepositoryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }


    }
}