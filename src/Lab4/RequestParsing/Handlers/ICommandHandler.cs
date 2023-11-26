using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers;

public interface ICommandHandler
{
    public ICommandHandler? NextHandler { get; set; }
    public ICommand? Handle(RequestIterator request);
}