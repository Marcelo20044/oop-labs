namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileShowCommandBuilders;

public interface IFileShowCommandBuilder : ICommandBuilder
{
    IFileShowCommandBuilder WithFilePath(string path);
}