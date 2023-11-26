using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

public class FileShowCommand : ICommand
{
    private string _filePath;

    public FileShowCommand(string filePath)
    {
        _filePath = filePath;
    }

    public IFileSystem? FileSystem { get; set; }

    public ExecutionResult Execute()
    {
        if (FileSystem?.ConnectionPath is null) return ExecutionResult.Fail;
        if (!_filePath.Contains(FileSystem.ConnectionPath, StringComparison.Ordinal))
        {
            _filePath = $"{FileSystem.ConnectionPath}/{_filePath}";
        }

        try
        {
            FileSystem.FileShow(_filePath);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}