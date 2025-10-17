using app.Configs;
using app.Models.Animals;
using app.UI;
using app.UI.MenuItems;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    public static void Main()
    {
        // object[] args = [100, "vlad", 5, 6];
        // var animal = Activator.CreateInstance((new Monkey()).GetType(), args);
        // Console.WriteLine(animal);
        IServiceProvider serviceProvider = DepInjConfig.ConfigureServices();
        List<IMenuItem> menuItems =
        [
            serviceProvider.GetRequiredService<AddAnimalMenuItem>(),
            serviceProvider.GetRequiredService<AddThingMenuItem>(),
            serviceProvider.GetRequiredService<ShowAllInventoryObjMenuItem>(),
            serviceProvider.GetRequiredService<ShowAllStatisticsForAnimalsMenuItem>(),
            serviceProvider.GetRequiredService<ShowKindAnimalsMenuItem>(),
        ];
        Menu menu = new(menuItems);
        menu.Show();
    }
}