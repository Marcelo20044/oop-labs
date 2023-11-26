namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeListCommandBuilders;

public interface ITreeListCommandBuilder : ICommandBuilder
{
    ITreeListCommandBuilder WithDepth(int depth);
}