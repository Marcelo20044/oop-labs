using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public interface ICommandBuilder
{
    ICommand Build();
}