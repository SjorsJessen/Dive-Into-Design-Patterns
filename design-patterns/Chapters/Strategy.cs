namespace DesignPatterns.Chapters;

public static class Strategy
{
    public static void Run(string selectedCity, TransportationMode transportationMode)
    {
        var client = new Client();
        client.Execute(selectedCity, transportationMode);
    }
}

public class Client
{
    private readonly Dictionary<TransportationMode, IStrategy> _strategyMapper = new();

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
        var strategy = _strategyMapper[transportationMode];
        context.SetStrategy(strategy);

        // Result of the chosen/executed strategy algorithm.
        var optimalRoute = context.Execute(selectedCity);
        Console.WriteLine(optimalRoute);
    }
}

public class Context
{
    private IStrategy? _strategy;

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public string? Execute(string city)
    {
        var result = _strategy?.Execute(city);
        return result;
    }
}

internal class CarStrategy : IStrategy
{
    public string Execute(string city)
    {
        var result = $"Found optimal car route for: {city}";
        // Implement actual algorithm here which finds the optimal route for a car and return the route.
        return result;
    }
}

internal class PublicTransportStrategy : IStrategy
{
    public string Execute(string city)
    {
        var result = $"Found optimal public transport route for: {city}";
        // Implement actual algorithm here which finds the optimal route for a public transport and return the route.
        return result;
    }
}

internal class BikeStrategy : IStrategy
{
    public string Execute(string city)
    {
        var result = $"Looking for optimal bike routing in {city}";
        // Implement actual algorithm here which finds the optimal route for a bike and return the route.
        return result;
    }
}

public interface IStrategy
{
    string Execute(string city);
}

public enum TransportationMode
{
    Car = 0,
    Bike = 1,
    PublicTransport = 2
}