using System;
using System.Collections.Generic;
using System.Text;

namespace BetterConsole.NET.Tests
{
    public static class WriteLine
    {
        /// <summary>
        /// Testing the WriteLine method
        /// Not testing Write, because WriteLine is just two Writes stacked on each other, the first on writing the value, the second one writing a new line character
        /// </summary>
        /// <returns>Whether or not everything executed properly</returns>
        public static bool Test()
        {
            bool success = true;

            try
            {
                // Default colored tests

                Console.WriteLine();                    // Testing empty
                Console.WriteLine("String test");       // Testing strings
                Console.WriteLine('-');                 // Testing characters
                Console.WriteLine(123);                 // Testing integers
                Console.WriteLine(1.23);                // Testing doubles
                Console.WriteLine(5.0f);                // Testing floats
                Console.WriteLine(false);               // Testing booleans
                Console.WriteLine(null);                // Testing null

                // Colored tests

                Console.WriteLine("String test", ConsoleColor.Green);       // Testing strings
                Console.WriteLine('-', ConsoleColor.Red);                   // Testing characters
                Console.WriteLine(123, ConsoleColor.Yellow);                // Testing integers
                Console.WriteLine(1.23, ConsoleColor.Magenta);              // Testing doubles
                Console.WriteLine(5.0f, ConsoleColor.Green);                // Testing floats
                Console.WriteLine(false, ConsoleColor.Cyan);                // Testing booleans
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }
    }
}
