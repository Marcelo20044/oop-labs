using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeListCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.TreeListCommandFlagsHandler;

public interface ITreeListCommandFlagsHandler
{
    public ITreeListCommandFlagsHandler? NextHandler { get; set; }
    public void Handle(string flag, string value, ITreeListCommandBuilder builder);
}