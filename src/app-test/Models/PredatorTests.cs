using Xunit;
using app.Models.Animals;

namespace Zoo.Tests.Models
{
    public class PredatorTests
    {
        [Fact]
        public void ToString_IncludesStrength()
        {
            var p = new Tiger(7, "Ty", 3);
            var s = p.ToString();
            Assert.Contains("name", s);
            Assert.Contains("7", s);
        }
        
        [Fact]
        public void ToString_IncludesStrength2()
        {
            var p = new Predator(5, "Wolf", 7);
            var s = p.ToString();
            Assert.Contains("food: 7", s);
        }
    }
}
