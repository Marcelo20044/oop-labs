using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageHasAlreadyBeenReadException : InvalidOperationException
{
    public MessageHasAlreadyBeenReadException(string message)
        : base(message)
    {
    }

    public MessageHasAlreadyBeenReadException()
    {
    }

    public MessageHasAlreadyBeenReadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}