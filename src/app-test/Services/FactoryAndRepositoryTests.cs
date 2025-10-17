using Xunit;
using app.Models.Factory;
using app.Models.Animals;
using app.Models.Things;
using app.Repositories;

namespace Zoo.Tests.ModelsTests
{
    public class FactoryAndRepositoryTests
    {
        [Fact]
        public void Factory_Create_ReturnsNewInstance()
        {
            var f = new Factory<Herbo>();
            var template = new Herbo();
            var newOne = f.Create(template, 10, "H", 5, 8);
            Assert.Equal(10, newOne.Number);
            Assert.Equal("H", newOne.Name);
        }

        [Fact]
        public void Repository_Push_And_GetElements()
        {
            var repo = new Repository<Table>();
            var t1 = new Table(1, "A");
            repo.Push(t1);
            var items = repo.GetElements();
            Assert.Single(items);
            Assert.Contains(t1, items);
        }
    }
}