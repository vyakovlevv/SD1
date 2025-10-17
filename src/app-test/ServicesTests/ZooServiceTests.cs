using Xunit;
using app.Services;
using app.Models.Animals;
using app.Models.Things;
using System;
using System.Linq;
using app.Repositories;
using app.Services.Implementations;

namespace Zoo.Tests.ServicesTests
{
    public class ZooServiceTests
    {
        [Fact]
        public void AddAnimal_AddsCorrectly()
        {
            VeterinaryClinicService vetClinic = new();
            Repository<Animal> animalRepository = new();
            Repository<Thing> thingRepository = new();
            var zoo = new ZooService(vetClinic, animalRepository, thingRepository);
            var a = new Herbo(1, "Herby", 3, 7);
            zoo.AddAnimal(a);
            var animals = zoo.GetAnimals();
            Assert.Single(animals);
            Assert.Contains(a, animals);
        }

        [Fact]
        public void AddThing_AddsCorrectly()
        {
            VeterinaryClinicService vetClinic = new();
            Repository<Animal> animalRepository = new();
            Repository<Thing> thingRepository = new();
            var zoo = new ZooService(vetClinic, animalRepository, thingRepository);
            var t = new Table(1, "Feeding Table");
            zoo.AddThing(t);
            var things = zoo.GetThings();
            Assert.Single(things);
            Assert.Contains(t, things);
        }

        [Fact]
        public void GetAnimals_InitiallyEmpty()
        {
            VeterinaryClinicService vetClinic = new();
            Repository<Animal> animalRepository = new();
            Repository<Thing> thingRepository = new();
            var zoo = new ZooService(vetClinic, animalRepository, thingRepository);
            Assert.Empty(zoo.GetAnimals());
        }

        [Fact]
        public void GetThings_InitiallyEmpty()
        {
            VeterinaryClinicService vetClinic = new();
            Repository<Animal> animalRepository = new();
            Repository<Thing> thingRepository = new();
            var zoo = new ZooService(vetClinic, animalRepository, thingRepository);
            Assert.Empty(zoo.GetThings());
        }
    }
}
