using Xunit;
using System;
using System.IO;
using app.UI.MenuItems;
using app.Services.Contracts;
using app.Models.Things;
using System.Collections.Generic;

namespace Zoo.Tests.Menu
{
    class FakeService4 : IZooService
    {
        public List<app.Models.Animals.Animal> Animals = new();
        public List<Thing> Things = new();
        public void AddAnimal(app.Models.Animals.Animal a) => Animals.Add(a);
        public void AddThing(Thing t) => Things.Add(t);
        public List<app.Models.Animals.Animal> GetAnimals() => Animals;
        public List<Thing> GetThings() => Things;
    }

    public class ShowAllThingsMenuItemTests
    {
        [Fact]
        public void Execute_PrintsAllThings()
        {
            var svc = new FakeService4();
            svc.Things.Add(new Table(1, "T1"));
            svc.Things.Add(new Table(2, "T2"));
            var menu = new ShowAllInventoryObjMenuItem(svc);
            using var sw = new StringWriter();
            Console.SetOut(sw);
            menu.Execute();
            var outStr = sw.ToString();
            Assert.Contains("T1", outStr);
            Assert.Contains("T2", outStr);
        }
    }
}
