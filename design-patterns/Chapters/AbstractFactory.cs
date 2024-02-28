namespace DesignPatterns.Chapters;

public static class AbstractFactory
{
    public static void Run()
    {
        var appConfiguration = new ApplicationConfiguration(OperatingSystem.Mac);
        appConfiguration.CreateApplication();
    }
}

internal class ApplicationConfiguration
{
    private OperatingSystem operatingSystem;
    public ApplicationConfiguration(OperatingSystem operatingSystem)
    {
        this.operatingSystem = operatingSystem;
    }

    public void CreateApplication()
    {
        IAbstractFactory? factory = default;
        
        if (operatingSystem == OperatingSystem.Windows)
        {
            factory = new WindowsFactory();
        }
        if (operatingSystem == OperatingSystem.Mac)
        {
            factory = new MacFactory();
        }
        else
        {
            Console.WriteLine("Unknown operating system, factory couldn't be created.");
        }

        var abstractFactoryApplication = new AbstractFactoryApplication(factory);
    }
}

internal class AbstractFactoryApplication
{
    private IAbstractFactory? factory;
    private IButton button;
    private ICheckbox checkbox;
    private OperatingSystem operatingSystem;
    
    public AbstractFactoryApplication(IAbstractFactory? factory)
    {
        this.factory = factory;
        CreateUI();
        Render();
    }

    private void CreateUI()
    {
        button = factory.CreateButton();
        checkbox = factory.CreateCheckbox();
    }

    private void Render()
    {
        button.Render();
        checkbox.Render();
    }
}

public class WindowsFactory : IAbstractFactory 
{
    public IButton CreateButton()
    {
       return new WindowsButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

public class MacFactory : IAbstractFactory 
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}

public class MacCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Render Mac Checkbox");
    }
}

public class WindowsCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Render Windows Checkbox");
    }
}

public class MacButton : IButton
{
    public void OnClick()
    {
        Console.WriteLine("Clicked Mac button");
    }

    public void Render()
    {
        Console.WriteLine("Render Mac Button");
    }
}

public interface IAbstractFactory
{
    public IButton CreateButton();
    public ICheckbox CreateCheckbox();
}

public interface ICheckbox
{
    public void Render();
}