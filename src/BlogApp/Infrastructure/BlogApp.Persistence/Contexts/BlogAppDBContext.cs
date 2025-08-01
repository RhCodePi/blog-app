using BlogApp.Domain.Entities;
using BlogApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Persistence.Contexts
{
    public class BlogAppDBContext : IdentityDbContext<AppUser, IdentityRole,string>
    {
        public BlogAppDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>()
                .Property(a => a.Content)
                .HasColumnType("jsonb");
        }

    }
}
