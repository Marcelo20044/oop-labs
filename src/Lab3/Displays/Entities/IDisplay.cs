using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public interface IDisplay
{
    void DisplayText(string text, Color color);
    void Clean();
}