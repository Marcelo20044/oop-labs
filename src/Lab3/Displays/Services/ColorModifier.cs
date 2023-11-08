using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Services;

public static class ColorModifier
{
    public static string Modify(string text, Color color)
    {
        return Crayon.Output.Rgb(color.R, color.G, color.B).Text(text);
    }
}