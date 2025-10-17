using app.Models.Animals;
using app.Services.Contracts;

namespace app.UI.MenuItems;

public class ShowAllStatisticsForAnimalsMenuItem(IZooService zooService) : IMenuItem
{
    public string Title => "Показать статистику по зверушкам";
    public void Execute()
    {
        Dictionary<string, int> mapAnimals = new();
        List<Animal> animals = zooService.GetAnimals();
        int totalAmountFood = 0;
        foreach (Animal animal in animals)
        {
            string typeName = animal.GetType().Name;
            mapAnimals[typeName] = mapAnimals.GetValueOrDefault(typeName, 0) + 1;
            totalAmountFood += animal.Food;
        }
        
        Console.WriteLine("Животные зоопарка:");
        foreach (KeyValuePair<string,int> pair in mapAnimals)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
        Console.WriteLine($"Общее количество потребляемой еды: {totalAmountFood}");
    }
}