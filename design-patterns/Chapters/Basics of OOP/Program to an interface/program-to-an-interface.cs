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
    protected override Employee[] GetEmployees()
    {
        Employee[] employees = { new Tester(), new Programmer() };
        return employees;
    }
}

public class DesignCompany : Company
{
    protected override Employee[] GetEmployees()
    {
        Employee[] employees = { new Designer(), new Artist() };
        return employees;
    }
}

public abstract class Company 
{
    public Company() 
    {
        this.CreateSoftware();
    }

    private void CreateSoftware()
    {
        Employee[] employees = GetEmployees();
        foreach(Employee employee in employees)
        {
            employee.DoWork();
        }
    }

    protected abstract Employee[] GetEmployees();
}

public class Designer : Employee
{
    public void DoWork() => Console.WriteLine("Designing an Architecture");
}

public class Programmer : Employee
{
    public void DoWork() => Console.WriteLine("Writing Code");
}

public class Tester : Employee
{
    public void DoWork() => Console.WriteLine("Testing Software");
}

public class Artist : Employee
{
    public void DoWork() => Console.WriteLine("Creating Art");
}

public interface Employee
{
    void DoWork();
}