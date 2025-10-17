using Xunit;
using app.Models.Things;

namespace Zoo.Tests.Models
{
    public class ThingAndTableTests
    {
        [Fact]
        public void Table_ToString_ShowsNameAndNumber()
        {
            var t = new Table(2, "Bench");
            var s = t.ToString();
            Assert.Contains("Bench", s);
            Assert.Contains("2", s);
        }
    }
}
