using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Persistance.Contexts
{
    public class BlogAppDBContext : DbContext
    {
        public BlogAppDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }

    }
}
