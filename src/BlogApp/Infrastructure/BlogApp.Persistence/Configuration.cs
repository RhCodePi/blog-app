using Microsoft.Extensions.Configuration;

namespace BlogApp.Persistence
{
    public static class Configuration
    {
        public static string GetConnectionString { 
            get 
            {
                string curruntDirectory = Directory.GetCurrentDirectory();
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(curruntDirectory).AddJsonFile("appsettings.json").Build();
                string connectionString = configuration.GetConnectionString("PostgresSQL")!;

                return connectionString;
            } 
        }
    }
}
