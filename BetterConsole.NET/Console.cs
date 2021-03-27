using BetterConsole.Utils;

namespace BetterConsole
{
    public static class Console
    {
        static public System.ConsoleColor BackgroundColor { get { return System.Console.BackgroundColor; } set { System.Console.BackgroundColor = value; } }

        public static void Write(object Value, Color c = null)
        {
            if (Value == null) return;

            System.Console.Write(c == null ? Value.ToString() : Format.Color(Value.ToString(), c));
        }

        public static void WriteLine() => Write('\n');

        public static void WriteLine(object Value, Color c = null)
        {
            Write(Value, c);
            Write('\n');
        }

        public static string ReadLine() => System.Console.ReadLine();

        public static T ReadLine<T>()
        {
            string input = System.Console.ReadLine();

            try
            {
                return (T)System.Convert.ChangeType(input, typeof(T));
            }
            catch (System.FormatException ex)
            {
                throw new System.Exception($"The supplied type [{typeof(T).Name}] has no explicit conversion method from string", ex);
            }
        }

        public static System.ConsoleKeyInfo ReadKey(bool Intercept = true) => System.Console.ReadKey(Intercept);

        public static System.ConsoleKeyInfo WaitForKey(System.ConsoleKey? Key = null)
        {
            if (Key == null) return ReadKey();

            var inKey = ReadKey();

            while (inKey.Key != Key) { inKey = ReadKey(); }

            return inKey;
        }
    }
}
