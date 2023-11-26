using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileDeleteCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class FileDeleteCommandHandler : BaseCommandHandler
{
    private const string CommandNameFirst = "file";
    private const string CommandNameSecond = "delete";

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandNameFirst
            || !request.Move()
            || request.Current != CommandNameSecond
            || !request.Move())
            return base.Handle(request);

        IFileDeleteCommandBuilder commandBuilder = new FileDeleteCommandBuilder()
            .WithFilePath(request.Current);

        return request.Move() ? base.Handle(request) : commandBuilder.Build();
    }
}