namespace app.Models.Animals;

public abstract class Animal : IAlive, IInventory
{
    public int Number { get; set; }
    public string Name { get; }
    public int Food { get; set; }

    public Animal(int number, string name, int food)
    {
        Number = number;
        Name = name;
        Food = food;
    }

    public Animal()
    {
        Name = string.Empty;
    }
    
    public override string ToString()
    {
        return $"{Number}: name: {Name}, type: {this.GetType().Name}, food: {Food}";
    }
}