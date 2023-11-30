using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeListCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.TreeListCommandFlagsHandler;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class TreeListCommandHandler : BaseCommandHandler
{
    private const string CommandNameFirst = "tree";
    private const string CommandNameSecond = "list";
    private readonly ITreeListCommandFlagsHandler _flagsHandler;

    public TreeListCommandHandler(ITreeListCommandFlagsHandler flagsHandler)
    {
        _flagsHandler = flagsHandler;
    }

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandNameFirst
            || !request.Move()
            || request.Current != CommandNameSecond)
            return base.Handle(request);

        var commandBuilder = new TreeListCommandBuilder();

        while (request.Move())
        {
            string flag = request.Current;
            if (!request.Move()) break;

            _flagsHandler.Handle(flag, request.Current, commandBuilder);
        }

        return commandBuilder.Build();
    }
}