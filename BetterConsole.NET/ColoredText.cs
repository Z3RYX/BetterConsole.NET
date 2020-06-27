using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BetterConsole
{
    public class ColoredText : List<(object Value, ConsoleColor? Color, ConsoleColor? BackgroundColor)>
    {
        public bool Spaced { get; set; }

        public ColoredText(bool Spaced = true)
        {
            this.Spaced = Spaced;
        }

        public ColoredText Add(object Value, ConsoleColor? Color = null, ConsoleColor? BackgroundColor = null) => Add((Value, Color, BackgroundColor));
    }
}
