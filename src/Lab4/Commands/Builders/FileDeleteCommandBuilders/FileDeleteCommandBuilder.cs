using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileDeleteCommandBuilders;

public class FileDeleteCommandBuilder : IFileDeleteCommandBuilder
{
    private string? _filePath;

    public ICommand Build() => new FileDeleteCommand(
        _filePath ?? throw new FileNotFoundException("File path is null"));

    public IFileDeleteCommandBuilder WithFilePath(string path)
    {
        _filePath = path;
        return this;
    }
}