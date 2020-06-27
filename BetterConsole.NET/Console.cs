namespace BetterConsole
{
    public static class Console
    {
        static private System.ConsoleColor _ForegroundColor { get { return System.Console.ForegroundColor; } set { System.Console.ForegroundColor = value; } }
        static private System.ConsoleColor _BackgroundColor { get { return System.Console.BackgroundColor; } set { System.Console.BackgroundColor = value; } }

        public static void Write(object Value, System.ConsoleColor? Color = null, System.ConsoleColor? BackgroundColor = null)
        {
            var defaultColors = (_ForegroundColor, _BackgroundColor);

            SetColor(Color, BackgroundColor);

            System.Console.Write(Value.ToString());

            SetColor(defaultColors._ForegroundColor, defaultColors._BackgroundColor);
        }

        private static void SetColor(System.ConsoleColor? ForegroundColor, System.ConsoleColor? BackgroundColor)
        {
            _BackgroundColor = BackgroundColor ?? _BackgroundColor;
            _ForegroundColor = ForegroundColor ?? _ForegroundColor;
        }
    }
}
