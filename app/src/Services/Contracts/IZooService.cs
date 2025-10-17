using app.Models.Animals;
using app.Models.Things;

namespace app.Services.Contracts;

public interface IZooService
{
    void AddAnimal(Animal animal);
    void AddThing(Thing thing);
    List<Animal> GetAnimals();
    List<Thing> GetThings();
}