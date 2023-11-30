using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileNameIsNullException : IOException
{
    public FileNameIsNullException(string message)
        : base(message)
    {
    }

    public FileNameIsNullException()
    {
    }

    public FileNameIsNullException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}