using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.ConnectCommandBuilders;

public interface IConnectCommandBuilder : ICommandBuilder
{
    IConnectCommandBuilder WithDirectoryPath(string path);
    IConnectCommandBuilder WithConnectionMode(IFileSystem fileSystem);
}