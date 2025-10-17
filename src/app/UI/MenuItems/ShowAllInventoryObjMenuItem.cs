using app.Models;
using app.Services.Contracts;

namespace app.UI.MenuItems;

public class ShowAllInventoryObjMenuItem(IZooService zooService) : IMenuItem
{
    public string Title => "Показать все инвентаризированные вещи/существа в зоопарке";
    public void Execute()
    {
        List<IInventory> inventoriesAnimals = zooService.GetAnimals().Cast<IInventory>().ToList();
        List<IInventory> inventoriesThings = zooService.GetThings().Cast<IInventory>().ToList();
        List<IInventory> inventories = inventoriesAnimals;
        inventories.AddRange(inventoriesThings);
        foreach (IInventory inventory in inventories)
        {
            Console.WriteLine(inventory);
        }
    }
}