using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileShowCommandBuilders;

public class FileShowCommandBuilder : IFileShowCommandBuilder
{
    private string? _filePath;

    public ICommand Build() => new FileShowCommand(
        _filePath ?? throw new FileNotFoundException("File path is null"));

    public IFileShowCommandBuilder WithFilePath(string path)
    {
        _filePath = path;
        return this;
    }
}