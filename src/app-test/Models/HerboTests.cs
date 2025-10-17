using Xunit;
using app.Models.Animals;
using System;

namespace Zoo.Tests.Models
{
    public class HerboTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void Construct_ValidKindness_SetsProperty(int kindness)
        {
            var h = new Herbo(1, "Herb", 2, kindness);
            Assert.Equal(kindness, h.Kindness);
        }
        
        [Fact]
        public void IsKind_ReturnsExpected()
        {
            var hGood = new Herbo(1, "G", 1, 9);
            var hBad = new Herbo(2, "B", 1, 2);
            Assert.True(hGood.IsKind());
            Assert.False(hBad.IsKind());
        }
        
        [Theory]
        [InlineData(-2)]
        [InlineData(11)]
        public void InvalidKindness_Throws(int value)
        {
            Assert.Throws<ArgumentException>(() => new Herbo(1, "Bad", 3, value));
        }

        [Fact]
        public void IsKind_ReturnsTrueIfKindnessAbove5()
        {
            var h = new Herbo(1, "Good", 2, 6);
            Assert.True(h.IsKind());
        }

        [Fact]
        public void ToString_IncludesKindness()
        {
            var h = new Herbo(3, "Nice", 4, 9);
            var result = h.ToString();
            Assert.Contains("kindness: 9", result);
        }
    }
}
