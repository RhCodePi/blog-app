using BlogApp.Application.Abstractions.Repositories;
using BlogApp.Application.Abstractions.Services;
using BlogApp.Persistance.Concretes.Repositories;
using BlogApp.Persistance.Concretes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddSingleton<IArticleService, ArticleService>();
            services.AddSingleton<IArticleRepository, ArticleRepository>();
        }
    }
}
