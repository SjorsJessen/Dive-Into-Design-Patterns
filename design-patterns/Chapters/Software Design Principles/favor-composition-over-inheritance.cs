// Code implementation of the explanation on pages 45-48.

public static class FavorCompositionOverInheritance
{
    public static void Run()
    {
        Transport car = new();
        
        Cargo cargo = new Cargo(10, "A fragile package", true);
        Destination destination = new Destination(Country.Canada, "A Street 19", "1234 AB");
        car.Deliver(cargo, destination);
    }
}

public class Transport
{
    private Driver? driver;
    private Engine engine = new CombustionEngine();

    public Transport()
    {
        ChangeEngine();
    }

    private void ChangeEngine()
    {
        engine = new ElectricEngine();
        Console.WriteLine("Changed engine to an electric engine");
    }

    public void Deliver(Cargo cargo, Destination destination)
    {
        Console.WriteLine($"Destination info: {destination.Address}, {destination.Country}, {destination.PostalCode}");
        Console.WriteLine($"Cargo info: id: {cargo.Id}, weight: {cargo.Weight}kg, description: {cargo.Description}, breakable?: {cargo.IsBreakable}");
    }
}

public class CombustionEngine : Engine
{
    public void Move()
    {
        Console.WriteLine("Driving with a combustion engine.");
    }
}

public class ElectricEngine : Engine
{
    public void Move()
    {
        Console.WriteLine("Electric driving.");
    }
}

public class Robot : Driver
{
    public void Navigate()
    {
        Console.WriteLine("Robot driver.");
    }
}

public class Human : Driver
{
    public void Navigate()
    {
        Console.WriteLine("Human driver");
    }
}

public class Cargo 
{
    public Guid Id => id;
    public float Weight => weight; 
    public string Description => description; 
    public bool IsBreakable => isBreakable; 

    private Guid id;
    private float weight;
    private string description = "";
    private bool isBreakable = false;

    public Cargo(float weight, string description, bool isBreakable = false)
    {
        this.id = new Guid();
        this.weight = weight;
        this.description = description;
        this.isBreakable = isBreakable;
    }
}

public class Destination 
{
    public Country Country => country; 
    public string Address => address;
    public string PostalCode => postalCode;

    private Country country;
    private string address = "";
    private string postalCode = "";

    public Destination(Country country, string address, string postalCode)
    {
        this.country = country;
        this.address = address;
        this.postalCode = postalCode;
    }
}

public interface Driver 
{
    void Navigate();
}

public interface Engine 
{
    void Move();
}

public enum Country
{
    UnitedStates = 0,
    Canada = 1,
    England = 2,
    France = 3,
    Germany = 4
}