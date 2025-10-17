using app.Models.Animals;
using app.Models.Factory;
using app.Services.Contracts;

namespace app.UI.MenuItems;

public class AddAnimalMenuItem : AddObjectMenuItem<Animal>
{
    public AddAnimalMenuItem(IFactory<Animal> factory, IZooService zooService, List<Animal> supportedAnimals) : base(factory, zooService, supportedAnimals) { }
    public override string Title => "Добавить животное(не человека)";

    public override void Execute()
    {
        var animalId = InputTypeId();

        Animal typeAnimal = SupportedTypes[animalId - 1];
        List<object> args = new();
        
        (int number, string name) = InputIdAndName();
        args.Add(number);
        args.Add(name);
        int food;
        do
        {
            Console.Write("Введите количество кг еды в сутки: ");
        } while (!(int.TryParse(Console.ReadLine(), out food) && food > 0));

        args.Add(food);
        if (typeAnimal is Herbo)
        {
            int kindness;
            do
            {
                Console.Write("Введите уровень доброты (0-10): ");
            } while (!(int.TryParse(Console.ReadLine(), out kindness) && kindness >= 0 && kindness <= 10));

            args.Add(kindness);
        }

        try
        {
            AddObjectToZoo(typeAnimal, args);
            Console.WriteLine($"Зверушка {name} успешно добавлена в зоопарк");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Ошибка добавления животного: {e.Message}");
        }
    }

    
}