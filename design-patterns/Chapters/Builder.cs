namespace DesignPatterns.Chapters;

public static class Builder
{
    public static void Run()
    {
        var app = new BuilderApplication();
        app.Build();
    }
}

public class BuilderApplication
{
    public void Build()
    {
        var director = new Director();
        
        // Build Car Product
        var carBuilder = new CarBuilder();
        director.BuildSportsCar(carBuilder);
        director.BuildSportsSUV(carBuilder); //Overrides previous values
        var car = carBuilder.GetProduct();
        Console.WriteLine($"Build car: {car}");
        
        // Build Manual Product
        var carManualBuilder = new ManualBuilder();
        director.BuildSportsSUV(carManualBuilder);
        var manual = carManualBuilder.GetProduct();
        Console.WriteLine($"Car manual: {manual}");
    }
}

public class Director
{
    public void BuildSportsCar(IBuilder builder)
    {
        builder.Reset();
        builder.SetEngine("V8");
        builder.SetSeats(2);
        builder.SetTripComputer("Some Sports car computer");
        builder.SetGPS(true);
    }
    
    public void BuildSportsSUV(IBuilder builder)
    {
        builder.Reset();
        builder.SetEngine("V12");
        builder.SetSeats(4);
        builder.SetTripComputer("Some SUV car computer");
        builder.SetGPS(false);
    }
}

public class CarBuilder : IBuilder
{
    private Car _car;

    public CarBuilder()
    {
        Reset();
    }
    
    public void Reset()
    {
        _car = new Car();
    }

    public void SetSeats(int amountOfSeats)
    {
        _car.SeatsAmount = amountOfSeats;
    }

    public void SetEngine(string engineType)
    {
        _car.EngineType = engineType;
    }

    public void SetTripComputer(string computerType)
    {
        _car.ComputerType = computerType;
    }
    
    public void SetGPS(bool usesSatellite)
    {
        _car.GpsType = usesSatellite ? "Satellite GPS" : "Old Skool GPS";
    }
    
    public IProduct GetProduct()
    {
        return _car;
    }
}

public class ManualBuilder : IBuilder
{
    private Manual _manual;

    public ManualBuilder()
    {
        Reset();
    }
    
    public void Reset()
    {
        _manual = new Manual();
    }

    public void SetSeats(int amountOfSeats)
    {
        _manual.SeatsDescription = $"The car has {amountOfSeats} of seats";
    }

    public void SetEngine(string engineType)
    {
        _manual.EngineDescription = $"The car is packed with a {engineType}";
    }

    public void SetTripComputer(string computerType)
    {
        _manual.ComputerDescription = $"The car has a build-in top notch {computerType}";
    }

    public void SetGPS(bool usesSatellite)
    {
        _manual.GpsDescription = usesSatellite ? "The car has a state of the art Google GPS" : "The car has the tried and tested TomTom GPS";
    }
    
    public IProduct GetProduct()
    {
        return _manual;
    }
}

public interface IBuilder
{
    public void Reset();
    public void SetSeats(int amountOfSeats);
    public void SetEngine(string engineType);
    public void SetTripComputer(string computerType);
    public void SetGPS(bool usesSatellite);
    public IProduct GetProduct();
}

public class Car : IProduct
{
    public int WindowsAmount;
    public int SeatsAmount;
    public string EngineType;
    public string GpsType;
    public string ComputerType;
}

public class Manual : IProduct
{
    public string WindowsDescription;
    public string SeatsDescription;
    public string EngineDescription;
    public string GpsDescription;
    public string ComputerDescription;
}

public interface IProduct
{
    
}