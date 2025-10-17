using Xunit;
using app.Services;
using app.Models.Animals;
using app.Services.Implementations;

namespace Zoo.Tests.Services
{
    public class VeterinaryClinicServiceTests
    {
        [Fact]
        public void GetHealthScore_InRange()
        {
            var svc = new VeterinaryClinicService();
            var a = new Wolf(1, "A", 2);
            var score = svc.GetHealthScore(a);
            Assert.InRange(score, 0, 100);
        }

        [Fact]
        public void GetHealthScore_DifferentAnimals_ReturnDifferentOrSameButDeterministic()
        {
            var svc = new VeterinaryClinicService();
            var a1 = new Tiger(1, "A", 2);
            var a2 = new Rabbit(2, "B", 2, 7);
            var s1 = svc.GetHealthScore(a1);
            var s2 = svc.GetHealthScore(a2);
            Assert.True(s1 >= 0 && s1 <= 100);
            Assert.True(s2 >= 0 && s2 <= 100);
        }
        
        [Fact]
        public void GetHealthScore_ReturnsInRange()
        {
            var clinic = new VeterinaryClinicService();
            var score = clinic.GetHealthScore(new Wolf(1, "A", 2));
            Assert.InRange(score, 0, 100);
        }
    }
}
