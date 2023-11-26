using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

public class DisconnectCommand : ICommand
{
    public IFileSystem? FileSystem { get; set; }

    public ExecutionResult Execute()
    {
        if (FileSystem is null) return ExecutionResult.Fail;

        try
        {
            FileSystem.Disconnect();
            return ExecutionResult.Final;
        }
        catch (IOException)
        {
            return ExecutionResult.Fail;
        }
    }
}