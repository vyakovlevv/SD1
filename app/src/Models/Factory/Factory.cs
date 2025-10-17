namespace app.Models.Factory;

public class Factory
{
    IInventory Create(IInventory obj, params object[] args)
    {
        return (IInventory)Activator.CreateInstance(obj.GetType(), args);
    }
}