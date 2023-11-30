using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeListCommandBuilders;

public class TreeListCommandBuilder : ITreeListCommandBuilder
{
    private int _depth;

    public ICommand Build() => new TreeListCommand(_depth);

    public ITreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }
}