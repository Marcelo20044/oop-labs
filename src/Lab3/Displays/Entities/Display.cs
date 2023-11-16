using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void DisplayText(string text, Color color)
    {
        _displayDriver.CleanDisplay();
        _displayDriver.Text = text;
        _displayDriver.Color = color;
        _displayDriver.DisplayText();
    }

    public void Clean()
    {
        Console.Clear();
    }
}