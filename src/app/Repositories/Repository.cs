using app.Models;

namespace app.Repositories;

public class Repository<T> : IRepository<T> where T : IInventory
{
    private readonly List<T> _repo = new();

    public void Push(T inventory)
    {
        _repo.Add(inventory);
    }

    public List<T> GetElements()
    {
        return _repo;
    }
}