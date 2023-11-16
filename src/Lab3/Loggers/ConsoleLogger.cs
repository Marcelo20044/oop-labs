using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(string text)
    {
        Console.WriteLine(text);
    }
}