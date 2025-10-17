namespace app.Models.Animals;

public class Wolf : Predator
{
    public Wolf(int number, string name, int food) : base(number, name, food) {}
    
    public Wolf() {}
}