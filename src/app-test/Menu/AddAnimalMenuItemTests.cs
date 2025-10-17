using Xunit;
using System;
using System.IO;
using app.UI.MenuItems;
using app.Services.Contracts;
using app.Models.Animals;
using System.Collections.Generic;
using app.Models.Factory;

namespace Zoo.Tests.Menu
{
    class FakeService : IZooService
    {
        public List<Animal> Animals = new();
        public List<app.Models.Things.Thing> Things = new();
        public void AddAnimal(Animal a) => Animals.Add(a);
        public void AddThing(app.Models.Things.Thing t) => Things.Add(t);
        public List<Animal> GetAnimals() => Animals;
        public List<app.Models.Things.Thing> GetThings() => Things;
    }

    public class AddAnimalMenuItemTests
    {
        [Fact]
        public void Execute_AddsHerbo_WhenInputProvided()
        {
            var input = new StringReader("1\n7\nHerbName\n3\n8\n");
            Console.SetIn(input);
            var svc = new FakeService();
            var factory = new Factory<Animal>();
            List<Animal> supportedAnimals = [
                new Monkey(),
                new Rabbit(),
                new Tiger(),
                new Wolf()
            ];
            var menu = new AddAnimalMenuItem(factory, svc, supportedAnimals);
            using var sw = new StringWriter();
            Console.SetOut(sw);
            menu.Execute();
            Assert.NotEmpty(svc.GetAnimals());
        }
    }
}
