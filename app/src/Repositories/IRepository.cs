using app.Models;

namespace app.Repositories;

public interface IRepository<T> where T: IInventory
{
    void Push(T inventory);
    List<T> GetElements();
}