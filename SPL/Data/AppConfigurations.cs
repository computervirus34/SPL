using Microsoft.Extensions.Configuration;

public class AppConfigurations
{
    public static IConfiguration AppSetting { get; }
    static AppConfigurations()
    {
        AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
    }
}

