using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileCopyCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class FileCopyCommandHandler : BaseCommandHandler
{
    private const string CommandNameFirst = "file";
    private const string CommandNameSecond = "copy";

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandNameFirst
            || !request.Move()
            || request.Current != CommandNameSecond
            || !request.Move())
            return base.Handle(request);

        IFileCopyCommandBuilder commandBuilder = new FileCopyCommandBuilder()
            .WithSourcePath(request.Current);

        if (!request.Move()) return base.Handle(request);

        commandBuilder.WithDestinationPath(request.Current);

        return request.Move() ? base.Handle(request) : commandBuilder.Build();
    }
}