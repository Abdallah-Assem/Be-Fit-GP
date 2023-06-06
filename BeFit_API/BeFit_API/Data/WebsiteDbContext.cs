using BeFit_API.Model;
using Microsoft.EntityFrameworkCore;

namespace BeFit_API.Data
{
    public class WebsiteDbContext : DbContext
    {
        public WebsiteDbContext(DbContextOptions<WebsiteDbContext> options) : base(options) { }

        public DbSet<UserMacros> UserMacros { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SelectedFood> SelectedFood { get; set; }
        public DbSet<SpecialFood> SpecialFood { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Exercise> Exercise { get; set;}
    }
}
