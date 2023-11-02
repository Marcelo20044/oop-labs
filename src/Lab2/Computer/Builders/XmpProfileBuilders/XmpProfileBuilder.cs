using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.XmpProfileBuilders;

public class XmpProfileBuilder : IXmpProfileBuilder
{
    private Timings? _timings;
    private FrequencyAndVoltage? _frequencyAndVoltage;

    public IXmpProfileBuilder WithTimings(Timings timings)
    {
        _timings = timings;
        return this;
    }

    public IXmpProfileBuilder WithFrequencyAndVoltage(FrequencyAndVoltage frequencyAndVoltage)
    {
        _frequencyAndVoltage = frequencyAndVoltage;
        return this;
    }

    public IXmpProfileBuilder Reset()
    {
        _timings = null;
        _frequencyAndVoltage = null;
        return this;
    }

    public XmpProfile Build()
    {
        Timings? timings = _timings;
        FrequencyAndVoltage? frequencyAndVoltage = _frequencyAndVoltage;

        Reset();

        return new XmpProfile(
            timings ?? throw new AttributeNullException(nameof(_timings)),
            frequencyAndVoltage ?? throw new AttributeNullException(nameof(_frequencyAndVoltage)));
    }
}