namespace DesignPatterns;

public static class OpenClosedPrinciple
{
    public static void Run()
    {
        var shapeGenerator = new ShapeCalculator();
        shapeGenerator.CalculateAllAreas();
    }
}

public class ShapeCalculator
{
    public void CalculateAllAreas()
    {
        var rectangle = new Rectangle(12, 20);
        var circle = new Circle(15);
        Calculate(rectangle);
        Calculate(circle);
    }
    
    private void Calculate(IShape shape)
    {
        string type = shape.GetType().Name;
        float area = shape.Area();
        Console.WriteLine($"Area of {type} is: {area}");
    }
}

public class Rectangle : IShape
{
    private readonly float _height;
    private readonly float _width;

    public Rectangle(float height, float width)
    {
        _height = height;
        _width = width;
    }
    
    public float Area()
    {
        return _height * _width;
    }
}

public class Circle : IShape
{
    private readonly float _radius;
    
    public Circle(float radius)
    {
        _radius = radius;
    }
    
    public float Area()
    {
        return (float)(_radius * Math.PI);
    }
}

public interface IShape
{
    public float Area();
}
