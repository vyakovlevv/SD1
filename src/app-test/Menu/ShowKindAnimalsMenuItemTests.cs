using Xunit;
using System;
using System.IO;
using System.Collections.Generic;
using app.Models.Animals;
using app.Services.Contracts;
using app.UI.MenuItems;

namespace Zoo.Tests.Menu
{
    class FakeService5 : IZooService
    {
        public List<Animal> Animals = new();
        public List<app.Models.Things.Thing> Things = new();
        public void AddAnimal(Animal a) => Animals.Add(a);
        public void AddThing(app.Models.Things.Thing t) => Things.Add(t);
        public List<Animal> GetAnimals() => Animals;
        public List<app.Models.Things.Thing> GetThings() => Things;
    }

    public class ShowKindAnimalsMenuItemTests
    {
        [Fact]
        public void Execute_PrintsOnlyKindHerbos()
        {
            var svc = new FakeService5();
            svc.Animals.Add(new Herbo(1, "Good", 1, 9));
            svc.Animals.Add(new Herbo(2, "Bad", 1, 2));
            svc.Animals.Add(new Rabbit(3, "R", 1, 0));
            var menu = new ShowKindAnimalsMenuItem(svc);
            using var sw = new StringWriter();
            Console.SetOut(sw);
            menu.Execute();
            var outStr = sw.ToString();
            Assert.Contains("Good", outStr);
            Assert.DoesNotContain("Bad", outStr);
            Assert.DoesNotContain("R", outStr);
        }
    }
}
