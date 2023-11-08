using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class DisplayDriverMock : IDisplayDriver
{
    public string Text { get; set; } = string.Empty;
    public Color Color { get; set; } = Color.Empty;
    public string DisplayedText { get; private set; } = string.Empty;
    public void CleanDisplay()
    {
        DisplayedText = string.Empty;
    }

    public void DisplayText()
    {
        DisplayedText = Text;
    }
}