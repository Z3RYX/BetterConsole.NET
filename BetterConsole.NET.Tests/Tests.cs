using System;
using Console = BetterConsole.Console;

namespace BetterConsole.NET.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Hello ", ConsoleColor.Red);
            Console.Write("World", ConsoleColor.Blue);
            Console.Write("!\n");
            Console.WriteLine();

            Console.WriteLine("string");
            Console.WriteLine('c');
            Console.WriteLine(123);
            Console.WriteLine(0.5);
            Console.WriteLine(0xFF);
            Console.WriteLine();

            var test1 = Console.ReadLine().GetType();
            var test2 = Console.ReadLine<int>().GetType();
            var test3 = Console.ReadLine<bool>().GetType();

            ColoredText text = new ColoredText()
                .New(test1, ConsoleColor.Red)
                .New(test2, ConsoleColor.Green)
                .New(test3, ConsoleColor.Blue);

            Console.WriteLine(text.Snippets.Count);
            Console.WriteLine(text);
        }
    }
}
