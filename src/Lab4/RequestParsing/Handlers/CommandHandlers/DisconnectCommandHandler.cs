using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.ConcreteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class DisconnectCommandHandler : BaseCommandHandler
{
    private const string CommandName = "disconnect";

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandName) return base.Handle(request);

        return request.Move() ? base.Handle(request) : new DisconnectCommand();
    }
}