using app.Models.Animals;

namespace app.Models.Factory;

public class Factory<T>  : IFactory<T>  where T: IInventory
{
    public T Create(T obj, params object[] args)
    {
        return (T)Activator.CreateInstance(obj.GetType(), args);
    }
}