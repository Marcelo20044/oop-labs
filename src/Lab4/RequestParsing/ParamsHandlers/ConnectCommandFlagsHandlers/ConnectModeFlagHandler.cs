using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.ConnectCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.ConnectCommandFlagsHandlers;

public class ConnectModeFlagHandler : BaseConnectCommandFlagsHandler
{
    private const string Flag = "-m";

    public override void Handle(string flag, string value, IConnectCommandBuilder builder)
    {
        if (flag != Flag) base.Handle(flag, value, builder);

        IFileSystem fileSystem = value switch
        {
            "local" => new LocalFileSystem(),
            _ => throw new ArgumentException(value),
        };

        builder.WithConnectionMode(fileSystem);
    }
}