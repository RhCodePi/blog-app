using BlogApp.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;

namespace BlogApp.Infrastructure.Concretes.Services.Formatter
{
    public class DateTimeFormatter : IDateTimeFormatter
    {
        private readonly IConfiguration _config;

        public DateTimeFormatter(IConfiguration config)
        {
            _config = config;
        }

        public string ConvertToString(DateTime date)
        {
            var format = _config["DateTimeFormat:DefaultFormat"];

            return date.ToString(format);
        }
    }
}
