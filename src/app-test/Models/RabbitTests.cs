using Xunit;
using app.Models.Animals;

namespace Zoo.Tests.Models
{
    public class RabbitTests
    {
        [Fact]
        public void Rabbit_CanBeCreatedAndToString()
        {
            var r = new Rabbit(9, "Bugs", 5, 8);
            var s = r.ToString();
            Assert.Contains("Bugs", s);
            Assert.Contains("Rabbit", s);
        }
    }
}
