using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;

public class Messenger : IMessenger
{
    public Messenger(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void WriteText(string text)
    {
        Console.WriteLine($"{Name}:\n{text}");
    }
}