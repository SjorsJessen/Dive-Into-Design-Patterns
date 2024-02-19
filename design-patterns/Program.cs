using DesignPatterns.Chapters;

namespace DesignPatterns;

class Program
{
    private static void Main(string[] args)
    {
        // ProgramToAnInterfaceExample.Run();
        // FavorCompositionOverInheritance.Run();
        // OpenClosedPrinciple.Run();
        StrategyPatternExample.Run("Rome", TransportationMode.PublicTransport);
    }
}
