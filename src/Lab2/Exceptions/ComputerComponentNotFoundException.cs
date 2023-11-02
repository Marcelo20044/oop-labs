using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ComputerComponentNotFoundException : Exception
{
    public ComputerComponentNotFoundException()
    {
    }

    public ComputerComponentNotFoundException(string message)
        : base(message)
    {
    }

    public ComputerComponentNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}