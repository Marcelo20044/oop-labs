using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

public class TreeGotoCommand : ICommand
{
    private string _directoryPath;

    public TreeGotoCommand(string directoryPath)
    {
        _directoryPath = directoryPath;
    }

    public IFileSystem? FileSystem { get; set; }

    public ExecutionResult Execute()
    {
        if (FileSystem?.ConnectionPath is null) return ExecutionResult.Fail;
        if (!_directoryPath.Contains(FileSystem.ConnectionPath, StringComparison.Ordinal))
        {
            _directoryPath = $"{FileSystem.ConnectionPath}/{_directoryPath}";
        }

        try
        {
            FileSystem.TreeGoto(_directoryPath);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}