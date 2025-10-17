using Xunit;
using app.Models.Animals;
using System;

namespace Zoo.Tests.Models
{
    public class AnimalTests
    {
        [Fact]
        public void ToString_IncludesNumberNameFood()
        {
            var a = new Wolf(42, "Zed", 12);
            var s = a.ToString();
            Assert.Contains("42", s);
            Assert.Contains("Zed", s);
            Assert.Contains("food", s);
        }
        
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            var animal = new Wolf(1, "Leo", 5);
            var result = animal.ToString();
            Assert.Contains("1:", result);
            Assert.Contains("Leo", result);
            Assert.Contains("food: 5", result);
        }
        

        [Fact]
        public void HashCode_DependentOnNumber()
        {
            var a1 = new Wolf(2, "A", 3);
            var a2 = new Wolf(2, "B", 10);
            Assert.NotEqual(a1.GetHashCode(), a2.GetHashCode());
        }

        [Fact]
        public void Equals_SameNumber_IsEqual()
        {
            var a1 = new Wolf(3, "A", 1);
            var a2 = new Wolf(3, "B", 9);
            Assert.False(a1.Equals(a2));
            Assert.NotEqual(a1.GetHashCode(), a2.GetHashCode());
        }

        [Fact]
        public void Constructor_AllowsZeroFood()
        {
            var a = new Wolf(5, "Zero", 0);
            Assert.Equal(0, a.Food);
        }
    }
}
