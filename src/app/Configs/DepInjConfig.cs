using app.Models.Animals;
using app.Models.Factory;
using app.Models.Things;
using app.Repositories;
using app.Services.Contracts;
using app.Services.Implementations;
using app.UI.MenuItems;
using Microsoft.Extensions.DependencyInjection;

namespace app.Configs;

public class DepInjConfig
{
    public static IServiceProvider ConfigureServices()
    {
        ServiceCollection  services = new();
        services.AddSingleton<IRepository<Animal>, Repository<Animal>>();
        services.AddSingleton<IRepository<Thing>, Repository<Thing>>();

        services.AddSingleton<IVeterinaryClinicService, VeterinaryClinicService>();
        services.AddSingleton<IZooService, ZooService>();

        services.AddSingleton<IFactory<Animal>, Factory<Animal>>();
        services.AddSingleton<IFactory<Thing>, Factory<Thing>>();

        
        services.AddTransient<AddAnimalMenuItem>(servProv =>
        {
            var factory = servProv.GetService<IFactory<Animal>>();
            var zooService = servProv.GetService<IZooService>();
            List<Animal> supportedAnimals = [
                new Monkey(),
                new Rabbit(),
                new Tiger(),
                new Wolf()
            ];
            return new AddAnimalMenuItem(factory, zooService, supportedAnimals);
        });
        services.AddTransient<AddThingMenuItem>(servProv =>
        {
            var factory = servProv.GetService<IFactory<Thing>>();
            var zooService = servProv.GetService<IZooService>();
            List<Thing> supportedThings = [
                new Computer(),
                new Table(),
            ];
            return new AddThingMenuItem(factory, zooService, supportedThings);
        });        
        services.AddTransient<ShowAllInventoryObjMenuItem>();
        services.AddTransient<ShowKindAnimalsMenuItem>();
        services.AddTransient<ShowAllStatisticsForAnimalsMenuItem>();

        
        
        return services.BuildServiceProvider();
    }
}