using BlogApp.Application.Abstractions.Repositories.Articles;
using BlogApp.Application.Abstractions.Services;
using BlogApp.Domain.Entities.Identity;
using BlogApp.Persistance.Concretes.Repositories.Articles;
using BlogApp.Persistance.Concretes.Services;
using BlogApp.Persistance.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddSingleton<IArticleService, ArticleService>();
            services.AddSingleton<IArticleReadRepository, ArticleReadRepository>();
            services.AddSingleton<IArticleWriteRepository, ArticleWriteRepository>();
            services.AddDbContext<BlogAppDBContext>(options => options.UseNpgsql(
                Configuration.GetConnectionString
                ),ServiceLifetime.Singleton);
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<BlogAppDBContext>()
            .AddDefaultTokenProviders();
        }
    }
}
