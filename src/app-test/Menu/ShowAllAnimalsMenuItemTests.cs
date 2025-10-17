using Xunit;
using System;
using System.IO;
using app.UI.MenuItems;
using app.Services.Contracts;
using app.Models.Animals;
using System.Collections.Generic;

namespace Zoo.Tests.Menu
{
    class FakeService3 : IZooService
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
            var svc = new FakeService3();
            svc.Animals.Add(new Tiger(1, "A", 1));
            svc.Animals.Add(new Wolf(2, "B", 2));
            var menu = new ShowAllInventoryObjMenuItem(svc);
            using var sw = new StringWriter();
            Console.SetOut(sw);
            menu.Execute();
            var outStr = sw.ToString();
            Assert.Contains("A", outStr);
            Assert.Contains("B", outStr);
        }
    }
}
