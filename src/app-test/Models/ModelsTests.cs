using app.Models.Animals;

using System;
using app.Models.Factory;
using app.Models.Things;
using app.Repositories;
using Xunit;


namespace app_test
{
    public class ModelsTests
    {
        [Fact]
        public void Animal_ToString_IncludesTypeNameAndFields()
        {
            var rabbit = new Rabbit(7, "Thumper", 10, 6);
            var s = rabbit.ToString();
            Assert.Contains("7:", s);
            Assert.Contains("Thumper", s);
            Assert.Contains("Rabbit", s);
            Assert.Contains("food: 10", s);
        }


        [Fact]
        public void Herbo_IsKind_BasedOnKindness()
        {
            var kindHerbo = new Herbo(1, "Bunny", 5, 8);
            var notKind = new Herbo(2, "Gloom", 4, 3);
            Assert.True(kindHerbo.IsKind());
            Assert.False(notKind.IsKind());
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void Herbo_Constructor_Throws_ForInvalidKindness(int invalid)
        {
            Assert.Throws<ArgumentException>(() => new Herbo(1, "Bad", 1, invalid));
        }


        [Fact]
        public void Herbo_ToString_IncludesKindness()
        {
            var h = new Herbo(3, "Leafy", 2, 6);
            var s = h.ToString();
            Assert.Contains("kindness: 6", s);
        }


        [Fact]
        public void Factory_Creates_Instance_With_Args()
        {
            var factory = new Factory<Herbo>();
            var template = new Herbo();
            var created = factory.Create(template, 9, "Flo", 3, 7);
            Assert.IsType<Herbo>(created);
            Assert.Equal(9, created.Number);
            Assert.Equal("Flo", created.Name);
            Assert.Equal(3, created.Food);
            Assert.Equal(7, created.Kindness);
        }


        [Fact]
        public void Repository_PushAndGetElements_Works()
        {
            var repo = new Repository<Table>();
            var t1 = new Table(1, "T1");
            var t2 = new Table(2, "T2");
            repo.Push(t1);
            repo.Push(t2);
            var list = repo.GetElements();
            Assert.Equal(2, list.Count);
            Assert.Contains(t1, list);
            Assert.Contains(t2, list);
        }
    }
}