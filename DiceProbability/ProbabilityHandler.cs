using System;

namespace DiceProbability
{
    public class ProbabilityHandler
    {
        public double GetProbability(int numberOfDice, int numberOfSuccesses)
        {
            return CalculateProbability2(numberOfDice, numberOfSuccesses);
        }

        private double CalculateProbability2(int numberOfDice, int numberOfSuccesses)
        {
            double chanceOfFailure = 0;

            for (int i = numberOfSuccesses - 1; i >= 0; i--)
            {
                var derp = CalculateChance(numberOfDice, i);
                chanceOfFailure += derp;
            }

            return 1 - chanceOfFailure;
        }

        private double CalculateChance(int numberOfDice, int numberOfSuccesses)
        {
            return Math.Pow((double) 1 / 6, numberOfSuccesses) *
                   Math.Pow((double) 5 / 6, numberOfDice - numberOfSuccesses) *
                   GetBinomialCoEfficient(numberOfDice, numberOfSuccesses);
        }

        private double GetBinomialCoEfficient(int n, int k)
        {
            double result = 1;
            for (int i = 1; i <= k; i++)
            {
                result *= n - (k - i);
                result /= i;
            }

            return result;
        }
    }
}
