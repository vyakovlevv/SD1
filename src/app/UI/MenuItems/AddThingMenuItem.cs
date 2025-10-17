using app.Models.Animals;
using app.Models.Factory;
using app.Models.Things;
using app.Services.Contracts;

namespace app.UI.MenuItems;

public class AddThingMenuItem: AddObjectMenuItem<Thing>
{

    public AddThingMenuItem(IFactory<Thing> factory, IZooService zooService, List<Thing> supportedThings) : base(
        factory, zooService, supportedThings) { }
    public override string Title => "Добавить предмет";

    public override void Execute()
    {
        var thingId = InputTypeId();
        Thing typeThing = SupportedTypes[thingId - 1];
        List<object> args = new();
        
        (int number, string name) = InputIdAndName();
        args.Add(number);
        args.Add(name);
        try
        {
            AddObjectToZoo(typeThing, args);
            Console.WriteLine($"Предмет {name} успешно добавлен в зоопарк");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Ошибка добавления предмета: {e.Message}");
        }
    }
}