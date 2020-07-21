using System.Collections.Generic;
using System.Linq;

namespace DiceProbability
{
    public class ProbabilityHandler
    {
        public double GetProbability(int numberOfDice, int numberOfSuccesses)
        {
            List<List<int>> combinationList = new List<List<int>>();

            PopulateCombinationList(numberOfDice, 1, combinationList);

            return CalculateProbaility(combinationList, numberOfSuccesses);
        }

        private double CalculateProbaility(List<List<int>> combinationList, int numberOfSuccesses)
        {
            int success = combinationList.Count(c => c.Count(d => d == 6) >= numberOfSuccesses);

            return (double) success / combinationList.Count;
        }

        private void PopulateCombinationList(int numberOfDice, int dice, List<List<int>> combinationList)
        {
            while (true)
            {
                if (dice == 1)
                {
                    for (int i = 1; i <= 6; i++) combinationList.Add(new List<int> {i});
                }
                else
                {
                    List<List<int>> tmpCombinationList = new List<List<int>>();

                    foreach (var combination in combinationList)
                    {
                        for (int i = 2; i <= 6; i++)
                        {
                            var list = new List<int>(combination);
                            list.Add(i);
                            tmpCombinationList.Add(list);
                        }

                        combination.Add(1);
                    }

                    combinationList.AddRange(tmpCombinationList.Select(x => x).ToList());
                }

                if (dice < numberOfDice)
                {
                    dice++;
                    continue;
                }

                break;
            }
        }
    }
}
