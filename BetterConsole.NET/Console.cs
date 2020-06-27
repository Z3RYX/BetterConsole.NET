﻿namespace BetterConsole
{
    public static class Console
    {
        static private System.ConsoleColor _ForegroundColor { get { return System.Console.ForegroundColor; } set { System.Console.ForegroundColor = value; } }
        static private System.ConsoleColor _BackgroundColor { get { return System.Console.BackgroundColor; } set { System.Console.BackgroundColor = value; } }

        public static void Write(object Value, System.ConsoleColor? Color = null, System.ConsoleColor? BackgroundColor = null)
        {
            if (Value.GetType() == typeof(ColoredText))
            {
                ColoredText snippets = Value as ColoredText;

                if (snippets.Count < 1) return;

                foreach (var snippet in snippets)
                {
                    if (System.Console.CursorLeft != 0 && snippets.Spaced) Write(' ');
                    Write(snippet.Value, snippet.Color, snippet.BackgroundColor);
                    return;
                }
            }

            var defaultColors = (_ForegroundColor, _BackgroundColor);

            SetColor(Color, BackgroundColor);

            System.Console.Write(Value.ToString());

            SetColor(defaultColors._ForegroundColor, defaultColors._BackgroundColor);
        }

        public static void WriteLine(object Value, System.ConsoleColor? Color, System.ConsoleColor? BackgroundColor)
        {
            Write(Value, Color, BackgroundColor);
            Write('\n');
        }

        private static void SetColor(System.ConsoleColor? ForegroundColor, System.ConsoleColor? BackgroundColor)
        {
            _BackgroundColor = BackgroundColor ?? _BackgroundColor;
            _ForegroundColor = ForegroundColor ?? _ForegroundColor;
        }
    }
}
