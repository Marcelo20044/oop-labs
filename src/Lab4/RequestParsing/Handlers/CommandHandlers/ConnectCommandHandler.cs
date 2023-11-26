using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.ConnectCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class ConnectCommandHandler : BaseCommandHandler
{
    private const string CommandName = "connect";
    private const string ModeFlag = "-m";

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandName || !request.Move()) return base.Handle(request);

        IConnectCommandBuilder commandBuilder = new ConnectCommandBuilder()
            .WithDirectoryPath(request.Current);

        if (!request.Move() || request.Current != ModeFlag || !request.Move())
            return base.Handle(request);

        switch (request.Current)
        {
            case "local":
                commandBuilder.WithConnectionMode(new LocalFileSystem());
                break;
            default:
                return base.Handle(request);
        }

        return request.Move() ? base.Handle(request) : commandBuilder.Build();
    }
}