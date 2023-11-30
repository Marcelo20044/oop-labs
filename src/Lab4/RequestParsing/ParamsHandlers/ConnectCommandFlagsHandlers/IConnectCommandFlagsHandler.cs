using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.ConnectCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.ConnectCommandFlagsHandlers;

public interface IConnectCommandFlagsHandler
{
    public IConnectCommandFlagsHandler? NextHandler { get; set; }
    public void Handle(string flag, string value, IConnectCommandBuilder builder);
}