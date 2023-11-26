using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeGotoCommandBuilders;

public class TreeGotoCommandBuilder : ITreeGotoCommandBuilder
{
    private string? _directoryPath;

    public ICommand Build() => new TreeGotoCommand(
        _directoryPath ?? throw new DirectoryNotFoundException("Directory path is null"));

    public ITreeGotoCommandBuilder WithDirectoryPath(string directoryPath)
    {
        _directoryPath = directoryPath;
        return this;
    }
}