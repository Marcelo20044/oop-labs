using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

public class FileRenameCommand : ICommand
{
    private readonly string _newName;
    private string _filePath;

    public FileRenameCommand(string filePath, string newName)
    {
        _filePath = filePath;
        _newName = newName;
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
            FileSystem.FileRename(_filePath, _newName);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}