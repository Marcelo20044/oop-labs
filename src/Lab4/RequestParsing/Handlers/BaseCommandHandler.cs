using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers;

public class BaseCommandHandler : ICommandHandler
{
    public ICommandHandler? NextHandler { get; set; }

    public virtual ICommand? Handle(RequestIterator request)
    {
        request.Reset();
        return NextHandler?.Handle(request);
    }
}