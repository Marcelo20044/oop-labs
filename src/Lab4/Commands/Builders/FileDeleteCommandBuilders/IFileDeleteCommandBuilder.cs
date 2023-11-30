namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileDeleteCommandBuilders;

public interface IFileDeleteCommandBuilder : ICommandBuilder
{
    IFileDeleteCommandBuilder WithFilePath(string path);
}