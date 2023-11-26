using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileRenameCommandBuilders;

public class FileRenameCommandBuilder : IFileRenameCommandBuilder
{
    private string? _filePath;
    private string? _newName;

    public ICommand Build() => new FileRenameCommand(
        _filePath ?? throw new FileNotFoundException("File path is null"),
        _newName ?? throw new FileNameIsNullException("File new name is null"));

    public IFileRenameCommandBuilder WithFilePath(string path)
    {
        _filePath = path;
        return this;
    }

    public IFileRenameCommandBuilder WithNewName(string name)
    {
        _newName = name;
        return this;
    }
}