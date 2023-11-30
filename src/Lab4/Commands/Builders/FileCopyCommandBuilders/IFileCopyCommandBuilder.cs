namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileCopyCommandBuilders;

public interface IFileCopyCommandBuilder : ICommandBuilder
{
    IFileCopyCommandBuilder WithSourcePath(string path);
    IFileCopyCommandBuilder WithDestinationPath(string path);
}