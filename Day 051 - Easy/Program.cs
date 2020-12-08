using System;

namespace _100daysCoding
{
    class Program_Day51
    {
        static void Main(string[] args)
        {
            Debounce(someFunctionV, 420);
        }

        static void someFunctionV()
        {
            Console.WriteLine("Hello World.");
        }

        // Debounced returns a debounced function that will not call its
        // provided function until after N miliseconds despite calling it.
        static void Debounce(Action f, int N)
        {
            DateTime c = DateTime.UtcNow;
            while ((DateTime.UtcNow - c).TotalMilliseconds < N) { }
            f();
        }
    }
}