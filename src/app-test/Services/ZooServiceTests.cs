using Xunit;
using app.Services;
using app.Models.Animals;
using app.Models.Things;
using System.Linq;
using app.Models.Factory;
using app.Repositories;
using app.Services.Implementations;

namespace Zoo.Tests.Services
{
    public class ZooServiceTests
    {
        [Fact]
        public void AddAnimal_AddsOnce_ForUniqueNumber()
        {
            VeterinaryClinicService vetClinic = new();
            Repository<Animal> animalRepository = new();
            Repository<Thing> thingRepository = new();
            var zs = new ZooService(vetClinic, animalRepository, thingRepository);
            var a = new Wolf(5, "One", 3);
            zs.AddAnimal(a);
            Assert.Single(zs.GetAnimals());
        }

        [Fact]
        public void AddThing_AddsThing()
        {
            VeterinaryClinicService vetClinic = new();
            Repository<Animal> animalRepository = new();
            Repository<Thing> thingRepository = new();
            var zs = new ZooService(vetClinic, animalRepository, thingRepository);
            zs.AddThing(new Table(2, "T2"));
            Assert.Single(zs.GetThings());
        }
    }
}
