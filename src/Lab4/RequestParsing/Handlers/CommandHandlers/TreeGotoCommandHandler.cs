using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeGotoCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class TreeGotoCommandHandler : BaseCommandHandler
{
    private const string CommandNameFirst = "tree";
    private const string CommandNameSecond = "goto";

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandNameFirst
            || !request.Move()
            || request.Current != CommandNameSecond
            || !request.Move())
            return base.Handle(request);

        ITreeGotoCommandBuilder commandBuilder = new TreeGotoCommandBuilder()
            .WithDirectoryPath(request.Current);

        return request.Move() ? base.Handle(request) : commandBuilder.Build();
    }
}