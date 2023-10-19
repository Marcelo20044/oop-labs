using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
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

    public XmpProfile Build()
    {
        return new XmpProfile(
            _timings ?? throw new AttributeNullException(nameof(_timings)),
            _frequencyAndVoltage ?? throw new AttributeNullException(nameof(_frequencyAndVoltage)));
    }
}