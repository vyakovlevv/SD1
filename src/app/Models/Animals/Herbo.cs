namespace app.Models.Animals;

public class Herbo : Animal
{
    public int Kindness { get; }

    public Herbo(int number, string name, int food, int kindness) : base(number, name, food)
    {
        if (kindness is < 0 or > 10)
        {
            throw new ArgumentException("Kindness must be 0-10");
        }
        Kindness = kindness;
    }
    
    public Herbo() {}
    
    public bool IsKind()
    {
        return Kindness > 5;
    }

    public override string ToString()
    {
        return base.ToString() + $", kindness: {Kindness}";
    }
}