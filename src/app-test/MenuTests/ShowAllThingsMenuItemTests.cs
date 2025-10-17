using Xunit;
using System;
using System.IO;
using System.Collections.Generic;
using app.Models.Animals;
using app.Models.Things;
using app.Services.Contracts;
using app.UI.MenuItems;

namespace Zoo.Tests.MenuTests
{
    class FakeZooService4 : IZooService
    {
        public List<Animal> Animals = new();
        public List<Thing> Things = new();
        public void AddAnimal(Animal a) => Animals.Add(a);
        public void AddThing(Thing t) => Things.Add(t);
        public List<Animal> GetAnimals() => Animals;
        public List<Thing> GetThings() => Things;
    }

    public class ShowAllThingsMenuItemTests
    {
        [Fact]
        public void Execute_PrintsAllThings()
        {
            var service = new FakeZooService4();
            service.Things.Add(new Table(1, "TableA"));
            service.Things.Add(new Table(2, "TableB"));
            var menu = new ShowAllInventoryObjMenuItem(service);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            menu.Execute();
            var output = sw.ToString();
            Assert.Contains("TableA", output);
            Assert.Contains("TableB", output);
        }
    }
}