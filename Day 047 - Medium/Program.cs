using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day47
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> probabilitySet = new Dictionary<int, double>();
            
            probabilitySet.Add(1, 0.1);
            probabilitySet.Add(2, 0.5);
            probabilitySet.Add(3, 0.2);
            probabilitySet.Add(4, 0.2);

            probabilityFunc(probabilitySet, 10);
        }

        private static void probabilityFunc(Dictionary<int, double> probabilitySet, int attempts)
        {
            Random rnd = new Random();
            var probs = (from entry in probabilitySet orderby entry.Value select entry.Value).ToList();

            for (int i = 0; i < attempts; ++i)
            {
                double ddouble = rnd.NextDouble();
                probs.Add(ddouble);
                probs.Sort();

                var idx = probs.FindIndex(p => p == ddouble);
                var res = -1;
                if (idx != 0 && idx != probs.Count - 1)
                {
                    if ((probs[idx] - probs[idx - 1]) > (probs[idx] - probs[idx + 1])) res = idx + 1;
                    else res = idx - 1;
                }
                else if (idx == 0) res = idx + 1;
                else res = idx - 1;

                foreach (var x in probabilitySet)
                    if (x.Value == probs[res])
                        Console.WriteLine($"{x.Key}");

                probs.Remove(ddouble);
            }
        }
    }
}
