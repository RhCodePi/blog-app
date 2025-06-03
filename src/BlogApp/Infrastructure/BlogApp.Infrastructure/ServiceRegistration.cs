using BlogApp.Application.Abstractions.Services;
using BlogApp.Infrastructure.Concretes.Services.Formatter;
using BlogApp.Infrastructure.Concretes.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDateTimeFormatter, DateTimeFormatter>();
        }
    }
}