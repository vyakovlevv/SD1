namespace app.Models.Factory;

public interface IFactory
{
    IInventory Create(IInventory obj, params object[] args);
}