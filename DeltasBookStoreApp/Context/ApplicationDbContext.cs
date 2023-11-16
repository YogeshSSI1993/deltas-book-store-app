using DeltasBookStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeltasBookStoreApp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

    }
}
