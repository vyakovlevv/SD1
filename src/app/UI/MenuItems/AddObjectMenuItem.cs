using app.Models;
using app.Models.Animals;
using app.Models.Factory;
using app.Models.Things;
using app.Services.Contracts;

namespace app.UI.MenuItems;

public class AddObjectMenuItem<T> : IMenuItem where T: IInventory
{
    private readonly IFactory<T> _factory;
    private readonly IZooService _zooService;
    protected readonly List<T> SupportedTypes;
    
    public AddObjectMenuItem(IFactory<T> factory, IZooService zooService, List<T> supportedTypes)
    {
        _factory = factory;
        _zooService = zooService;
        SupportedTypes = supportedTypes;
    }
    
    public virtual string Title => "Add Object";
    
    public virtual void Execute()
    {
        
    }
    
    protected void AddObjectToZoo(T type, List<object> args)
    {
        T obj = _factory.Create(type, args.ToArray());
        if (obj is Animal animal)
        {
            _zooService.AddAnimal(animal);
        } else if (obj is Thing thing)
        {
            _zooService.AddThing(thing);
        }
    }
    
    
    protected (int number, string name) InputIdAndName()
    {
        int number;
        string name;
        do
        {
            Console.Write("Введите инвентаризационный номер: ");
        } while (!(int.TryParse(Console.ReadLine(), out number) && number > 0));
        
        Console.Write("Введите название: ");
        name = Console.ReadLine() ?? string.Empty;
        return (number, name);
    }
    
    protected int InputTypeId()
    {
        for (int i = 0; i < SupportedTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {SupportedTypes[i].GetType().Name}");
        }

        int typeId;
        do
        {
            Console.Write("Введите номер типа: ");
        } while (!(int.TryParse(Console.ReadLine(), out typeId) && typeId > 0 &&
                   typeId <= SupportedTypes.Count));

        return typeId;
    }
}