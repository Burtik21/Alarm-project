using Microsoft.Extensions.Configuration;
using System.IO;

namespace MauiApp1.Config
{
    public static class Config
    {
        private static IConfigurationRoot configuration;

        static Config()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }
        
        public static string ApiEndPointCas => configuration["ApiEndPointCas"];
        public static string ApiEndPointIsOn => configuration["ApiEndPointIsOn"];
        public static string ApiEndPointPressed => configuration["ApiEndPointPressed"];
        public static string ApiEndPointAlarmDuration => configuration["ApiEndPointAlarmDuration"];

    }
}