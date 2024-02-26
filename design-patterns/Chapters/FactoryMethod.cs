namespace DesignPatterns.Chapters;

public static class FactoryMethod
{
    public static void Run()
    {
        var app = new Application(OperatingSystem.Windows);
        app.Create();
    }
}

public class Application
{
    private readonly OperatingSystem _operatingSystem;

    public Application(OperatingSystem operatingSystem)
    {
        _operatingSystem = operatingSystem;
    }
    
    public void Create()
    {
        if (_operatingSystem == OperatingSystem.Windows)
        {
            var windowsDialog = new WindowsDialog();
        }
        if (_operatingSystem == OperatingSystem.Web)
        {
            var webDialog = new WebDialog();
        }
    }
}

public class WindowsDialog : Dialog 
{
    public WindowsDialog() => Render();
    protected override IButton CreateButton()
    {
        return new WindowsButton();
    }
}

public class WebDialog : Dialog 
{
    public WebDialog() => Render();
    protected override IButton CreateButton()
    {
        return new WebButton();
    }
}

internal class WindowsButton : IButton
{
    public WindowsButton() => Render();
    public void OnClick() => Console.WriteLine("Clicked on Windows button");
    public void Render() => Console.WriteLine("Rendering Windows Button");
}

internal class WebButton : IButton
{
    public WebButton() => Render();
    public void OnClick() => Console.WriteLine("Clicked on Browser button");
    public void Render() => Console.WriteLine("Rendering Browser Button");
}

public abstract class Dialog
{
    protected void Render()
    {
        IButton button = CreateButton();
        button.OnClick();
        button.Render();
    }

    protected abstract IButton CreateButton();
}

public interface IButton
{
    public void OnClick();
    public void Render();
}

public enum OperatingSystem
{
    Windows = 0,
    Mac = 1,
    Web = 2
}