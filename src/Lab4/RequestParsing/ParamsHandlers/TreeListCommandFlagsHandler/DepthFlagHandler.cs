using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.TreeListCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.ParamsHandlers.TreeListCommandFlagsHandler;

public class DepthFlagHandler : BaseTreeListCommandFlagsHandler
{
    private const string Flag = "-d";

    public override void Handle(string flag, string value, ITreeListCommandBuilder builder)
    {
        if (flag != Flag) base.Handle(flag, value, builder);

        builder.WithDepth(int.Parse(value, new NumberFormatInfo()));
    }
}