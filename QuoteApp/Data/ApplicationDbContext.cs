using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuoteApp.Models;

namespace QuoteApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Quote> Quote { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
