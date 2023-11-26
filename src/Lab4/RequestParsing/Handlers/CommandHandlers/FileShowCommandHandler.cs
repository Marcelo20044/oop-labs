using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.FileShowCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Handlers.CommandHandlers;

public class FileShowCommandHandler : BaseCommandHandler
{
    private const string CommandNameFirst = "file";
    private const string CommandNameSecond = "show";
    private const string OutputModeFlag = "-m";

    public override ICommand? Handle(RequestIterator request)
    {
        if (request.Current != CommandNameFirst
            || !request.Move()
            || request.Current != CommandNameSecond
            || !request.Move())
            return base.Handle(request);

        IFileShowCommandBuilder commandBuilder = new FileShowCommandBuilder()
            .WithFilePath(request.Current);

        if (!request.Move() || request.Current != OutputModeFlag || !request.Move())
            return base.Handle(request);

        return request.Move() ? base.Handle(request) : commandBuilder.Build();
    }
}