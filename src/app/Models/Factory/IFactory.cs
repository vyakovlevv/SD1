namespace app.Models.Factory;

public interface IFactory<T> where T : IInventory
{
    T Create(T obj, params object[] args);
}