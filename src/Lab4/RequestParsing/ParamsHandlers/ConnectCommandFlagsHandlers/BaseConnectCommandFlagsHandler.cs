using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.ConnectCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.ConnectCommandFlagsHandlers;

public class BaseConnectCommandFlagsHandler : IConnectCommandFlagsHandler
{
    public IConnectCommandFlagsHandler? NextHandler { get; set; }
    public virtual void Handle(string flag, string value, IConnectCommandBuilder builder)
    {
        NextHandler?.Handle(flag, value, builder);
    }
}