using app.Models.Animals;
using app.Models.Things;
using app.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace app.Configs;

public class DepInjConfig
{
    public static IServiceProvider ConfigureServices()
    {
        ServiceCollection  services = new();
        services.AddSingleton<IRepository<Animal>, Repository<Animal>>();
        services.AddSingleton<IRepository<Thing>, Repository<Thing>>();
        
        
        return services.BuildServiceProvider();
    }
}