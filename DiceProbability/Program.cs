using System;

namespace DiceProbability
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(args[0], out var numberOfDice);
            int.TryParse(args[1], out var numberOfSuccesses);

            var handler = new ProbabilityHandler();
            var probability = handler.GetProbability(numberOfDice, numberOfSuccesses);

            Console.WriteLine($"{probability*100:G4}%");
        }
    }
}
