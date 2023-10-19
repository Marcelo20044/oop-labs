using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.XmpProfileBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class XmpProfile : IComputerComponent
{
    public XmpProfile(Timings timings, FrequencyAndVoltage frequencyAndVoltage)
    {
        Timings = timings;
        FrequencyAndVoltage = frequencyAndVoltage;
    }

    public Timings Timings { get; }
    public FrequencyAndVoltage FrequencyAndVoltage { get; }

    public IXmpProfileBuilder Direct(IXmpProfileBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        return builder
            .WithTimings(Timings)
            .WithFrequencyAndVoltage(FrequencyAndVoltage);
    }
}