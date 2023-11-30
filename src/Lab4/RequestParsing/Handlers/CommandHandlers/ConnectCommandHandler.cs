using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.ConnectCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.ConnectCommandFlagsHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class ConnectCommandHandler : BaseCommandHandler
{
    private const string CommandName = "connect";
    private readonly IConnectCommandFlagsHandler _flagsHandler;

    public ConnectCommandHandler(IConnectCommandFlagsHandler flagsHandler)
    {
        _flagsHandler = flagsHandler;
    }

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandName || !request.Move()) return base.Handle(request);

        IConnectCommandBuilder commandBuilder = new ConnectCommandBuilder()
            .WithDirectoryPath(request.Current);

        commandBuilder.WithDirectoryPath(request.Current);

        while (request.Move())
        {
            string flag = request.Current;
            if (!request.Move()) break;

            _flagsHandler.Handle(flag, request.Current, commandBuilder);
        }

        return commandBuilder.Build();
    }
}