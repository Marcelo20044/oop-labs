using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileSystemNotFoundException : IOException
{
    public FileSystemNotFoundException(string message)
        : base(message)
    {
    }

    public FileSystemNotFoundException()
    {
    }

    public FileSystemNotFoundException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}