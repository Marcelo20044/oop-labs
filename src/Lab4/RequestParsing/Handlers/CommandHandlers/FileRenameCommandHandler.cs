using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileRenameCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class FileRenameCommandHandler : BaseCommandHandler
{
    private const string CommandNameFirst = "file";
    private const string CommandNameSecond = "rename";

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandNameFirst
            || !request.Move()
            || request.Current != CommandNameSecond
            || !request.Move())
            return base.Handle(request);

        IFileRenameCommandBuilder commandBuilder = new FileRenameCommandBuilder()
            .WithFilePath(request.Current);

        if (!request.Move()) return base.Handle(request);

        commandBuilder.WithNewName(request.Current);

        return request.Move() ? base.Handle(request) : commandBuilder.Build();
    }
}