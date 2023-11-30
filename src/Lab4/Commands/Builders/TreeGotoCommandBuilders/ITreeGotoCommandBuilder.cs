namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeGotoCommandBuilders;

public interface ITreeGotoCommandBuilder : ICommandBuilder
{
    ITreeGotoCommandBuilder WithDirectoryPath(string directoryPath);
}