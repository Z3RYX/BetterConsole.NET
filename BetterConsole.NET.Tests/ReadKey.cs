using System;
using System.Collections.Generic;
using System.Text;

namespace BetterConsole.NET.Tests
{
    public static class ReadKey
    {
        public static bool Test()
        {
            bool success = true;

            try
            {
                Console.ReadKey();      // Test no parameter
                Console.ReadKey(true);  // Test intercept
                Console.ReadKey(false); // Test without intercept

                Console.WriteLine();
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }
    }
}
