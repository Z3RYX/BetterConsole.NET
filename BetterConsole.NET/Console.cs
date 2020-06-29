namespace BetterConsole
{
    public static class Console
    {
        static private System.ConsoleColor _ForegroundColor { get { return System.Console.ForegroundColor; } set { System.Console.ForegroundColor = value; } }
        static private System.ConsoleColor _BackgroundColor { get { return System.Console.BackgroundColor; } set { System.Console.BackgroundColor = value; } }

        public static void Write(object Value, System.ConsoleColor? Color = null)
        {
            if (Value.GetType() == typeof(ColoredText))
            {
                var coloredText = Value as ColoredText;
                var snippets = coloredText.Snippets;

                if (snippets.Count < 1) return;

                foreach (var snippet in snippets)
                {
                    if (System.Console.CursorLeft != 0 && coloredText.Spaced) Write(' ');
                    Write(snippet.Value, snippet.Color);
                }

                return;
            }

            var defaultColors = (_ForegroundColor, _BackgroundColor);

            SetColor(Color);

            System.Console.Write(Value.ToString());

            SetColor(defaultColors._ForegroundColor, defaultColors._BackgroundColor);
        }

        public static void WriteLine() => Write('\n');

        public static void WriteLine(object Value, System.ConsoleColor? Color = null)
        {
            Write(Value, Color);
            Write('\n');
        }

        public static string ReadLine() => System.Console.ReadLine();

        public static T ReadLine<T>()
        {
            string input = System.Console.ReadLine();

            return (T)System.Convert.ChangeType(input, typeof(T));
        }

        public static void SetColor(System.ConsoleColor? ForegroundColor = null, System.ConsoleColor? BackgroundColor = null)
        {
            _BackgroundColor = BackgroundColor ?? _BackgroundColor;
            _ForegroundColor = ForegroundColor ?? _ForegroundColor;
        }
    }
}
