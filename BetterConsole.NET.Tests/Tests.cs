using System;
using System.Collections.Generic;
using Console = BetterConsole.Console;

namespace BetterConsole.NET.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tests = new Tester();

            tests.CollectTests(
                WriteLine.Test
                );

            tests.RunTests();
        }
    }

    public class Tester
    {
        public List<Func<bool>> TestMethods;

        public Tester()
        {
            TestMethods = new List<Func<bool>>();
        }

        public void CollectTests(params Func<bool>[] Tests)
        {
            TestMethods.AddRange(Tests);
        }

        public void RunTests()
        {
            if (TestMethods.Count < 1) return;

            foreach (var m in TestMethods)
            {
                System.Console.WriteLine(
                      "-----------------------------------\n" +
                     $"[{m.Method.DeclaringType.Name}] Success? " + m() + "\n"
                    + "-----------------------------------");
            }
        }
    }
}
