using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeListCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.TreeListCommandFlagsHandler;

public class BaseTreeListCommandFlagsHandler : ITreeListCommandFlagsHandler
{
    public ITreeListCommandFlagsHandler? NextHandler { get; set; }
    public virtual void Handle(string flag, string value, ITreeListCommandBuilder builder)
    {
        NextHandler?.Handle(flag, value, builder);
    }
}