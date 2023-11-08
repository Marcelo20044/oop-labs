using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public interface IDisplayDriver
{
    public string Text { get; set; }
    public Color Color { get; set; }
    void CleanDisplay();
    void DisplayText();
}