using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BetterConsole.Utils;

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

                Console.WriteLine("String test", Color.New(255, 255, 0));       // Testing strings
                Console.WriteLine('-', Color.New(255, 0, 0));                   // Testing characters
                Console.WriteLine(123, Color.New(0, 255, 0));                   // Testing integers
                Console.WriteLine(1.23, Color.New(0, 255, 255));                // Testing doubles
                Console.WriteLine(5.0f, Color.New(0, 0, 255));                  // Testing floats
                Console.WriteLine(false, Color.New(255, 0, 255));               // Testing booleans

                // ANSI test

                Console.WriteLine(Format.Color($"This is a {Format.Style("test", Style.Underline)} with another thing in the middle", new Color(255, 128, 255)));   // Testing other formats within coloring or styling
                Console.WriteLine("It also works " + Format.Gradient("with some gradients", new Color(255, 255, 255), new Color(255, 0, 0)) + Format.Color(" within your text", new Color(255, 0, 0)), Color.New(255, 255, 255));   // Testing gradients in the middle of a text
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }
    }
}
