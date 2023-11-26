using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileSystemNotConnectedException : IOException
{
    public FileSystemNotConnectedException(string message)
        : base(message)
    {
    }

    public FileSystemNotConnectedException()
    {
    }

    public FileSystemNotConnectedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}