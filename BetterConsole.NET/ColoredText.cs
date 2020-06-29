using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BetterConsole
{
    public class ColoredText
    {
        public bool Spaced { get; set; }
        public List<(object Value, ConsoleColor? Color, ConsoleColor? BackgroundColor)> Snippets { get; internal set; }

        public ColoredText(bool Spaced = true)
        {
            this.Spaced = Spaced;
            this.Snippets = new List<(object Value, ConsoleColor? Color, ConsoleColor? BackgroundColor)>();
        }

        public ColoredText New(object Value, ConsoleColor? Color = null, ConsoleColor? BackgroundColor = null)
        {
            Snippets.Add((Value, Color, BackgroundColor));
            return this;
        }
    }
}
