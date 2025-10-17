using app.Models.Factory;

namespace app.UI.MenuItems;

public class AddAnimalMenuItem(IFactory factory) : IMenuItem
{
    public string Title => "Добавить животное";
    public void Execute()
    {
        
    }
}