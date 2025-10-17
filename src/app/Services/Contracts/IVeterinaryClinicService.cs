using app.Models.Animals;

namespace app.Services.Contracts;

public interface IVeterinaryClinicService
{
    public int GetHealthScore(Animal animal);
    public bool CheckAnimal(Animal animal);
}