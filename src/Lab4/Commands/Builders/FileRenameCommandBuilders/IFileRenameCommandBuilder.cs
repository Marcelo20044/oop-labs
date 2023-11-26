namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileRenameCommandBuilders;

public interface IFileRenameCommandBuilder : ICommandBuilder
{
    IFileRenameCommandBuilder WithFilePath(string path);
    IFileRenameCommandBuilder WithNewName(string name);
}