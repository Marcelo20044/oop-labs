using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

public class FileCopyCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public IFileSystem? FileSystem { get; set; }

    public ExecutionResult Execute()
    {
        if (FileSystem?.ConnectionPath is null) return ExecutionResult.Fail;

        if (!_sourcePath.Contains(FileSystem.ConnectionPath, StringComparison.Ordinal))
            _sourcePath = $"{FileSystem.ConnectionPath}/{_sourcePath}";
        if (!_destinationPath.Contains(FileSystem.ConnectionPath, StringComparison.Ordinal))
            _destinationPath = $"{FileSystem.ConnectionPath}/{_destinationPath}";

        try
        {
            FileSystem.FileCopy(_sourcePath, _destinationPath);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}