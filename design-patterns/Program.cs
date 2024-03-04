using DesignPatterns.Chapters;

namespace DesignPatterns;

class Program
{
    private static void Main(string[] args)
    {
        // ProgramToAnInterfaceExample.Run();
        // FavorCompositionOverInheritance.Run();
        // OpenClosedPrinciple.Run();

        // Creational Patterns
        {
            // FactoryMethod.Run();
            // AbstractFactory.Run();
            Builder.Run();
        }
        // Structural Patterns
        {
            
        }
        // Behavioral Patterns
        {
            Strategy.Run("Rome", TransportationMode.PublicTransport);
        }
    }
}
