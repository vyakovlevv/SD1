using app.Models.Animals;
using app.Models.Things;
using app.Repositories;
using app.Services.Contracts;

namespace app.Services.Implementations;

public class ZooService(IVeterinaryClinicService vetClinic, IRepository<Animal> animalRepo, IRepository<Thing> thingRepo) : IZooService
{
    public void AddAnimal(Animal animal)
    {
        if (vetClinic.CheckAnimal(animal))
        {
            animalRepo.Push(animal);
            return;
        }

        throw new ArgumentException("animal not healthy enough");
    }

    public void AddThing(Thing thing)
    {
        thingRepo.Push(thing);
    }

    public List<Animal> GetAnimals()
    {
        return animalRepo.GetElements();
    }

    public List<Thing> GetThings()
    {
        return thingRepo.GetElements();
    }
}