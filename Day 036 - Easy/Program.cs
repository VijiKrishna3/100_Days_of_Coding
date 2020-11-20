using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_036___Easy
{
    class Program
    {
        static void Main(string[] args)
        {
            Probabilities[] transitions = new Probabilities[9];

            transitions[0] = new Probabilities('a', 'a', 0.9);
            transitions[1] = new Probabilities('a', 'b', 0.075);
            transitions[2] = new Probabilities('a', 'c', 0.025);
            transitions[3] = new Probabilities('b', 'a', 0.15);
            transitions[4] = new Probabilities('b', 'b', 0.8);
            transitions[5] = new Probabilities('b', 'c', 0.05);
            transitions[6] = new Probabilities('c', 'a', 0.25);
            transitions[7] = new Probabilities('c', 'b', 0.25);
            transitions[8] = new Probabilities('c', 'c', 0.5);

            Console.Write("Insert starting state: ");
            char startingState = Convert.ToChar(Console.ReadLine());

            Console.Write("\nInsert number of steps: ");
            int num_steps = Convert.ToInt32(Console.ReadLine());

            var r = MarkovChain(startingState, transitions, num_steps);
            Console.WriteLine("This instance of Markov chain produced: ");

            foreach (var k in r)
                Console.WriteLine($"'{k.Key}': {k.Value},");
        }

        public static Dictionary<char, int> MarkovChain(char start, Probabilities[] p, int numSteps)
        {
            var starts = (from entry in p select entry.startPoint).ToList();
            var probs = (from entry in p select entry.probability).ToList();

            var result = starts.GroupBy(f => f).ToDictionary(f => f.Key, v => 0);
            var ss = (from entry in result select entry.Key).ToList();

            Random rnd = new Random();
           
           
            for (int i = 0; i < numSteps; ++i)
            {
                double ddouble = rnd.NextDouble();
                var ds = (from entry in p where entry.startPoint == start select entry.endPoint).ToList();
                var d = (from entry in p where entry.startPoint == start select entry.probability).ToList();
                double last = 0;

                for (int t = d.Count - 1; t >= 0; --t)
                {
                    if (ddouble > last && ddouble < d[t])
                    {
                        result[ds[t]]++;
                        start = ds[t];
                        break;
                    }
                    last = d[t];
                }
            }

            return result;
        }

        public class Probabilities
        {
            public char startPoint;
            public char endPoint;
            public double probability;

            public Probabilities(char c, char c2, double prob)
            {
                startPoint = c;
                endPoint = c2;
                probability = prob;
            }
        }
    }
}

/*
 * 
		for _, t := range d {
			if p > last && p < t.p {
				result[t.s]++
				start = t.s
				break
			}
			last = t.p
		}
	}
	return result
}
 */
