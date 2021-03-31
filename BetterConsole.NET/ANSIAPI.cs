using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterConsole.ANSI
{
    /// <summary>
    /// ANSI API that allows console manipulation
    /// </summary>
    public static class ANSIAPI
    {
        // Private Fields

        internal static string ESC { get { return (char)27 + "["; } }

        // Private Methods

        private static int GetFGColor(Colors color) => (int)color;
        private static int GetBGColor(Colors color) => (int)color + 10;
        private static int GetStyle(Decoration style) => (int)style;

        // Public Fields

        public static string Reset { get { return ESC + "0m"; } }

        // Public Methods

        public static string Color4bit(Colors color, bool bright = false, bool background = false)
            => ESC + (background ? GetBGColor(color) : GetFGColor(color)) + (bright ? ";1" : "") + "m";
        public static string Color8bit(byte color, bool background = false)
            => ESC + (background ? GetBGColor(Colors.CUSTOM) : GetFGColor(Colors.CUSTOM)) + ";5;" + color + "m";
        public static string Color24bit(byte red, byte green, byte blue, bool background = false)
            => ESC + (background ? GetBGColor(Colors.CUSTOM) : GetFGColor(Colors.CUSTOM)) + ";2;" + $"{red};{green};{blue}" + "m";
        public static string Decoration(Decoration style)
            => ESC + GetStyle(style) + "m";
        public static string MoveCursor(Directions direction, int steps)
            => ESC + steps + (char)direction;
        public static string ClearScreen(ClearType type)
            => ESC + (int)type + "J";
        public static string ClearLine(ClearType type)
            => ESC + (int)type + "K";

    }

    public enum Colors
    {
        BLACK   = 30,
        RED     = 31,
        GREEN   = 32,
        YELLOW  = 33,
        BLUE    = 34,
        MAGENTA = 35,
        CYAN    = 36,
        WHITE   = 37,
        CUSTOM  = 38
    }

    public enum Decoration
    {
        BOLD        = 1,
        UNDERLINE   = 4,
        INVERTED    = 7
    }

    public enum Directions
    {
        UP      = 65,
        DOWN    = 66,
        RIGHT   = 67,
        LEFT    = 68
    }

    public enum ClearType
    {
        FROM_CUR_TO_END = 0,
        FROM_BEG_TO_CUR = 1,
        FROM_BEG_TO_END = 2
    }
}
