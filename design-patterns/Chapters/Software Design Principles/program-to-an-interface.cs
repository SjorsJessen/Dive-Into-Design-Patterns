// Code implementation of the examples on pages 39-43.

namespace DesignPatterns;

public static class ProgramToAnInterfaceExample
{
    public static void Run() 
    {
        DesignCompany designCompany = new();
        GameDevCompany gameDevCompany = new();
    }
}

public class GameDevCompany : Company
{
    protected override IEnumerable<IEmployee> GetEmployees()
    {
        IEmployee[] employees = { new Tester(), new Programmer() };
        return employees;
    }
}

public class DesignCompany : Company
{
    protected override IEnumerable<IEmployee> GetEmployees()
    {
        IEmployee[] employees = { new Designer(), new Artist() };
        return employees;
    }
}

public abstract class Company 
{
    protected Company() 
    {
        CreateSoftware();
    }

    private void CreateSoftware()
    {
        IEnumerable<IEmployee> employees = GetEmployees();
        foreach(IEmployee employee in employees)
        {
            employee.DoWork();
        }
    }

    protected abstract IEnumerable<IEmployee> GetEmployees();
}

public class Designer : IEmployee
{
    public void DoWork() => Console.WriteLine("Designing an Architecture");
}

public class Programmer : IEmployee
{
    public void DoWork() => Console.WriteLine("Writing Code");
}

public class Tester : IEmployee
{
    public void DoWork() => Console.WriteLine("Testing Software");
}

public class Artist : IEmployee
{
    public void DoWork() => Console.WriteLine("Creating Art");
}

public interface IEmployee
{
    void DoWork();
}