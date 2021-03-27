using BetterConsole.ANSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterConsole.Utils
{
    public static class Format
    {
        public static string Color(object Value, Color c)
        {
            var v = Value.ToString();
            int indexOfReset = v.LastIndexOf(ANSIAPI.Reset);
            
            if (indexOfReset >= 0)
            {
                v = v.Insert(indexOfReset + ANSIAPI.Reset.Length - 1, ANSIAPI.Color24bit(c.Red, c.Green, c.Blue));
            }

            return ANSIAPI.Color24bit(c.Red, c.Green, c.Blue) + v + ANSI.ANSIAPI.Reset;
        }

        public static string Highlight(object Value, Color c)
        {
            var v = Value.ToString();
            int indexOfReset = v.LastIndexOf(ANSIAPI.Reset);

            if (indexOfReset >= 0)
            {
                v = v.Insert(indexOfReset + ANSIAPI.Reset.Length - 1, ANSIAPI.Color24bit(c.Red, c.Green, c.Blue, true));
            }

            return ANSIAPI.Color24bit(c.Red, c.Green, c.Blue, true) + v + ANSIAPI.Reset;
        }

        public static string Style(object Value, Style s)
        {
            var v = Value.ToString();
            int indexOfReset = v.LastIndexOf(ANSIAPI.Reset);

            var d = (Decoration)(int)s;

            if (indexOfReset >= 0)
            {
                v = v.Insert(indexOfReset + ANSIAPI.Reset.Length - 1, ANSIAPI.Decoration(d));
            }

            return ANSIAPI.Decoration(d) + v + ANSIAPI.Reset;
        }

        public static string Gradient(object Value, Color from, Color to)
        {
            if (Value.ToString().Contains(ANSIAPI.ESC)) throw new Exception("Gradient does not handle formatting. To use decoration on the gradient, use it after applying the gradient.");

            double r = to.Red - from.Red;
            double g = to.Green - from.Green;
            double b = to.Blue - from.Blue;

            r /= Value.ToString().Length;
            g /= Value.ToString().Length;
            b /= Value.ToString().Length;

            StringBuilder s = new StringBuilder();

            for (int i = 0; i < Value.ToString().Length; i++)
            {
                s.Append(Color(Value.ToString()[i], from));
                from = new Color((byte)(from.Red + r), (byte)(from.Green + g), (byte)(from.Blue + b));
            }

            return s.ToString();
        }
    }

    public class Color
    {
        public byte Red;
        public byte Green;
        public byte Blue;

        public Color(byte r, byte g, byte b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }

        public static Color New(byte r, byte g, byte b) => new Color(r, g, b);
    }

    public enum Style
    {
        Bold = 1,
        Underline = 4,
        Inverted = 7
    }
}
