using Xunit;
using app.Models.Factory;
using app.Models.Animals;
using app.Repositories;
using app.Models.Things;
using System;

namespace Zoo.Tests.Models
{
    public class FactoryAndRepositoryTests
    {
        [Fact]
        public void Factory_Create_HerboWithArgs()
        {
            var factory = new Factory<Herbo>();
            var template = new Herbo();
            var created = factory.Create(template, 13, "Flo", 4, 6);
            Assert.IsType<Herbo>(created);
            Assert.Equal(13, created.Number);
            Assert.Equal("Flo", created.Name);
            Assert.Equal(6, created.Kindness);
        }

        [Fact]
        public void Repository_Push_GetElements_Works()
        {
            var repo = new Repository<Table>();
            var t1 = new Table(1, "A");
            var t2 = new Table(2, "B");
            repo.Push(t1);
            repo.Push(t2);
            var list = repo.GetElements();
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Repository_AllowsDuplicateNumbers()
        {
            var repo = new Repository<Table>();
            var t1 = new Table(1, "A");
            var t2 = new Table(1, "A2");
            repo.Push(t1);
            repo.Push(t2);
            var list = repo.GetElements();
            Assert.True(list.Count >= 2);
        }
    }
}
