using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.ConnectCommandBuilders;

public class ConnectCommandBuilder : IConnectCommandBuilder
{
    private string? _directoryPath;
    private IFileSystem? _fileSystem;

    public ICommand Build() => new ConnectCommand(
        _directoryPath ?? throw new DirectoryNotFoundException("Directory path is null"),
        _fileSystem ?? throw new FileSystemNotFoundException("File system is null"));

    public IConnectCommandBuilder WithDirectoryPath(string path)
    {
        _directoryPath = path;
        return this;
    }

    public IConnectCommandBuilder WithConnectionMode(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }
}