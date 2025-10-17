namespace app.UI;

public interface IMenuItem
{
    public string Title { get; }
    public void Execute();
}