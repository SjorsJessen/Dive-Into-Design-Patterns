namespace DesignPatterns.Chapters;

public static class StrategyPatternExample
{
    public static void Run(string selectedCity, TransportationMode transportationMode)
    {
        var client = new Client();
        client.Execute(selectedCity, transportationMode);
    }
}

public class Client
{
    private readonly Dictionary<TransportationMode, IStrategy?> _strategyMapper = new();

    public Client() => Bind();

    private void Bind()
    {
        _strategyMapper.Add(TransportationMode.Car, new CarStrategy());
        _strategyMapper.Add(TransportationMode.Bike, new BikeStrategy());
        _strategyMapper.Add(TransportationMode.PublicTransport, new PublicTransportStrategy());
    }

    public void Execute(string selectedCity, TransportationMode transportationMode)
    {
        var context = new Context();
        context.Strategy = _strategyMapper[transportationMode];

        var optimalRoute = context.Execute(selectedCity); // Result of the chosen/executed strategy algorithm.
        Console.WriteLine(optimalRoute);
    }
}

public class Context
{
    public IStrategy? Strategy
    {
        set => _strategy = value;
    }

    private IStrategy? _strategy;

    public string? Execute(string city)
    {
        var result = _strategy?.Execute(city);
        return result;
    }
}

public interface IStrategy
{
    string Execute(string city);
}

internal class CarStrategy : IStrategy
{
    public string Execute(string city)
    {
        var result = $"Found optimal car route for: {city}";
        return result;
    }
}

internal class PublicTransportStrategy : IStrategy
{
    public string Execute(string city)
    {
        var result = $"Found optimal public transport route for: {city}";
        return result;
    }
}

internal class BikeStrategy : IStrategy
{
    public string Execute(string city)
    {
        var result = $"Looking for optimal bike routing in {city}";
        return result;
    }
}

public enum TransportationMode
{
    Car = 0,
    Bike = 1,
    PublicTransport = 2
}