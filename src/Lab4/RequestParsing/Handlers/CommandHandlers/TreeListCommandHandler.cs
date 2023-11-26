using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeListCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class TreeListCommandHandler : BaseCommandHandler
{
    private const string CommandNameFirst = "tree";
    private const string CommandNameSecond = "list";
    private const string DepthFlag = "-d";

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandNameFirst
            || !request.Move()
            || request.Current != CommandNameSecond
            || !request.Move()
            || request.Current != DepthFlag
            || !request.Move())
            return base.Handle(request);

        ITreeListCommandBuilder commandBuilder = new TreeListCommandBuilder()
            .WithDepth(int.Parse(request.Current, new NumberFormatInfo()));

        return request.Move() ? base.Handle(request) : commandBuilder.Build();
    }
}