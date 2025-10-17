using Xunit;
using app.Models.Animals;
using app.Services.Contracts;
using app.UI.MenuItems;
using System;
using System.Collections.Generic;
using System.IO;

namespace Zoo.Tests.MenuTests
{
    class FakeZooService : IZooService
    {
        public List<Animal> Animals = new();
        public List<app.Models.Things.Thing> Things = new();
        public void AddAnimal(Animal a) => Animals.Add(a);
        public void AddThing(app.Models.Things.Thing t) => Things.Add(t);
        public List<Animal> GetAnimals() => Animals;
        public List<app.Models.Things.Thing> GetThings() => Things;
    }

    public class ShowAllAnimalsMenuItemTests
    {
        [Fact]
        public void Execute_PrintsAllAnimals()
        {
            var service = new FakeZooService();
            service.Animals.Add(new Wolf(1, "A", 2));
            service.Animals.Add(new Wolf(2, "B", 3));
            var menu = new ShowAllInventoryObjMenuItem(service);

            using var sw = new StringWriter();
            Console.SetOut(sw);

            menu.Execute();
            var output = sw.ToString();
            Assert.Contains("A", output);
            Assert.Contains("B", output);
        }
    }
}