using app.Models.Factory;

namespace app.Models.Animals;

public class Monkey : Herbo
{
    
    public Monkey(int number, string name, int food, int kindness) : base(number, name, food, kindness) { }
    public Monkey() {}
}