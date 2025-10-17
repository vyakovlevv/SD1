using app.Models.Animals;
using app.Services.Contracts;

namespace app.Services.Implementations;

public class VeterinaryClinicService : IVeterinaryClinicService
{
    private Random _rnd = new Random();
    private int _minimumHealthThreshold = 100 - 69;

    public int GetHealthScore(Animal animal)
    {
        // давайте представим, что здесь проводится детальный анализ животного...
        int healthScore = _rnd.Next(0, 100);
        return healthScore;
    }
    
    public bool CheckAnimal(Animal animal)
    {
        int healthScore = GetHealthScore(animal);
        return healthScore >= _minimumHealthThreshold;
    }
}