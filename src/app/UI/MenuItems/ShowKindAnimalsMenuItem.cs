using app.Models.Animals;
using app.Services.Contracts;

namespace app.UI.MenuItems;

public class ShowKindAnimalsMenuItem(IZooService zooService) : IMenuItem
{
    public string Title => "Показать добри зверушки";

    public void Execute()
    {
        List<Herbo> animals = zooService.GetAnimals().Where(a => a is Herbo).Cast<Herbo>().Where(a => a.IsKind())
            .ToList();
        foreach (Herbo animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}