using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public string Text { get; set; } = string.Empty;
    public Color Color { get; set; } = Color.Empty;

    public void CleanDisplay()
    {
        Console.Clear();
    }

    public void DisplayText()
    {
        Console.WriteLine(ColorModifier.Modify(Text, Color));
    }
}