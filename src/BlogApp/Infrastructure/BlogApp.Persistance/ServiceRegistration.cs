using BlogApp.Application.Abstractions.Repositories;
using BlogApp.Application.Abstractions.Services;
using BlogApp.Persistance.Concretes.Repositories;
using BlogApp.Persistance.Concretes.Services;
using BlogApp.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddSingleton<IArticleService, ArticleService>();
            services.AddSingleton<IArticleRepository, ArticleRepository>();
            services.AddDbContext<BlogAppDBContext>(options => options.UseNpgsql(
                Configuration.GetConnectionString
                ));
        }
    }
}
