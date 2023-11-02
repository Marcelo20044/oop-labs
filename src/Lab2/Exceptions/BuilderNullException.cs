using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class BuilderNullException : ArgumentNullException
{
    public BuilderNullException(string paramName)
        : base(paramName)
    {
    }

    public BuilderNullException(string paramName, string message)
        : base(paramName, message)
    {
    }

    public BuilderNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public BuilderNullException()
    {
    }
}