namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileMoveCommandBuilders;

public interface IFileMoveCommandBuilder : ICommandBuilder
{
    IFileMoveCommandBuilder WithSourcePath(string path);
    IFileMoveCommandBuilder WithDestinationPath(string path);
}