using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileCopyCommandBuilders;

public class FileCopyCommandBuilder : IFileCopyCommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public ICommand Build() => new FileCopyCommand(
        _sourcePath ?? throw new DirectoryNotFoundException("Source path is null"),
        _destinationPath ?? throw new DirectoryNotFoundException("Destination path is null"));

    public IFileCopyCommandBuilder WithSourcePath(string path)
    {
        _sourcePath = path;
        return this;
    }

    public IFileCopyCommandBuilder WithDestinationPath(string path)
    {
        _destinationPath = path;
        return this;
    }
}