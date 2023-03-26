using BeFit_API.Model;
using Microsoft.EntityFrameworkCore;

namespace BeFit_API.Data
{
    public class WebsiteDbContext : DbContext
    {
        public WebsiteDbContext(DbContextOptions<WebsiteDbContext> options) : base(options) { }

        public DbSet<UserMacros> UserMacros { get; set; }
    }
}
