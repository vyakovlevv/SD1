namespace app.Models.Things;

public abstract class Thing : IInventory
{
    public int Number { get; set; }
    public string Name { get; }

    protected Thing(int number, string name)
    {
        Number = number;
        Name = name;
    }

    protected Thing()
    {
        Name = string.Empty;
    }
    
    public override string ToString()
    {
        return $"{Number}: name: {Name}";
    }
}