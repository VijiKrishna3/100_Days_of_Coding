using System;

namespace _100daysCoding
{
    class Program_Day35
    {
        public sealed class Singleton
        {
            private static Singleton InstanceEven = new Singleton();
            private static Singleton InstanceOdd = new Singleton();

            private static int counter = 0;

            private Singleton() { }

            public static Singleton getInstance()
            {
                ++counter;
                if (counter % 2 == 1)
                    return InstanceOdd;
                else
                    return InstanceEven;
            }
        }
    }
}
