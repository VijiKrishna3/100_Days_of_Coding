using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day60
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a string to test: ");
            string testString = Console.ReadLine();
            Console.WriteLine($"String is balanced = {balanced(testString)}");
        }

        static bool balanced(string str)
        {
            Dictionary<char, char> brackets = new Dictionary<char, char>{ { ')', '(' }, { '}', '{' }, { ']', '[' } };
            Stack<char> bracketStack = new Stack<char>();
            foreach (char a in str)
            {
                if (a == '(' || a == '[' || a == '{')
                    bracketStack.Push(a);
                else if (a == ']' || a == ')' || a == '}')
                {
                    if (bracketStack.Count == 0) return false;
                    if (bracketStack.Peek() == brackets[a]) bracketStack.Pop();
                    else return false;
                }
            }
            return bracketStack.Count == 0;
        }
    }
}
