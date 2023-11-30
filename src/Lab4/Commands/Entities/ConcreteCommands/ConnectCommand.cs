using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

public class ConnectCommand : ICommand
{
    private readonly string _directoryPath;

    public ConnectCommand(string directoryPath, IFileSystem fileSystem)
    {
        _directoryPath = directoryPath;
        FileSystem = fileSystem;
    }

    public IFileSystem? FileSystem { get; set; }

    public ExecutionResult Execute()
    {
        if (FileSystem is null) return ExecutionResult.Fail;

        try
        {
            FileSystem.Connect(_directoryPath);
            return ExecutionResult.Success;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}