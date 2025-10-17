using Xunit;
using System;
using System.IO;
using app.UI.MenuItems;
using app.Services.Contracts;
using app.Models.Animals;
using System.Collections.Generic;
using app.Models.Factory;

namespace Zoo.Tests.MenuTests
{
    class FakeZooService2 : IZooService
    {
        public List<Animal> Animals = new();
        public List<app.Models.Things.Thing> Things = new();
        public void AddAnimal(Animal animal) => Animals.Add(animal);
        public void AddThing(app.Models.Things.Thing thing) => Things.Add(thing);
        public List<Animal> GetAnimals() => Animals;
        public List<app.Models.Things.Thing> GetThings() => Things;
    }

    public class AddAnimalMenuItemTests
    {
        [Fact]
        public void Execute_AddsHerbo_WhenUserSelectsHerbo()
        {
            var input = new StringReader("1\nHerbo\n1\nBunny\n5\n7\n");
            Console.SetIn(input);
            var service = new FakeZooService2();
            var factory = new Factory<Animal>();
            List<Animal> supportedAnimals = [
                new Monkey(),
                new Rabbit(),
                new Tiger(),
                new Wolf()
            ];
            var menu = new AddAnimalMenuItem(factory, service, supportedAnimals);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            menu.Execute();

            Assert.Single(service.GetAnimals());
            Assert.Contains("Bunny", sw.ToString());
        }

        [Fact]
        public void Execute_AddsPredator_WhenUserSelectsPredator()
        {
            var input = new StringReader("2\nPredator\n1\nWolf\n10\n5\n");
            Console.SetIn(input);
            var service = new FakeZooService2();
            var factory = new Factory<Animal>();
            List<Animal> supportedAnimals = [
                new Monkey(),
                new Rabbit(),
                new Tiger(),
                new Wolf()
            ];
            var menu = new AddAnimalMenuItem(factory, service, supportedAnimals);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            menu.Execute();

            Assert.Single(service.GetAnimals());
            Assert.Contains("Wolf", sw.ToString());
        }

        [Fact]
        public void Execute_AddsRabbit_WhenUserSelectsRabbit()
        {
            var input = new StringReader("3\nRabbit\n1\nFluffy\n5\n");
            Console.SetIn(input);
            var service = new FakeZooService2();
            var factory = new Factory<Animal>();
            List<Animal> supportedAnimals = [
                new Monkey(),
                new Rabbit(),
                new Tiger(),
                new Wolf()
            ];
            var menu = new AddAnimalMenuItem(factory, service, supportedAnimals);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            menu.Execute();

            Assert.Single(service.GetAnimals());
            Assert.Contains("Fluffy", sw.ToString());
        }
    }
}
