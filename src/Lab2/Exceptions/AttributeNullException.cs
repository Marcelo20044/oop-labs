using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class AttributeNullException : ArgumentNullException
{
    public AttributeNullException(string paramName)
        : base(paramName)
    {
    }

    public AttributeNullException(string paramName, string message)
        : base(paramName, message)
    {
    }

    public AttributeNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AttributeNullException()
    {
    }
}