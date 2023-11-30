using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileMoveCommandBuilders;

public class FileMoveCommandBuilder : IFileMoveCommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public ICommand Build() => new FileMoveCommand(
        _sourcePath ?? throw new DirectoryNotFoundException("Source path is null"),
        _destinationPath ?? throw new DirectoryNotFoundException("Destination path is null"));

    public IFileMoveCommandBuilder WithSourcePath(string path)
    {
        _sourcePath = path;
        return this;
    }

    public IFileMoveCommandBuilder WithDestinationPath(string path)
    {
        _destinationPath = path;
        return this;
    }
}