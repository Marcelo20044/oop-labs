using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.RamBuilders;

public class RamBuilder : IRamBuilder
{
    private readonly List<FrequencyAndVoltage> _supportedFrequencyAndVoltagePairs = new();
    private readonly List<XmpProfile> _availableXmpProfiles = new();
    private int _availableMemory;
    private int _powerConsumption;
    private string? _ddrVersion;
    private FormFactor? _formFactor;

    public IRamBuilder WithAvailableMemory(int availableMemory)
    {
        _availableMemory = availableMemory;
        return this;
    }

    public IRamBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public IRamBuilder WithDdrVersion(string version)
    {
        _ddrVersion = version;
        return this;
    }

    public IRamBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamBuilder AddSupportedRamPairs(FrequencyAndVoltage frequencyAndVoltagePair)
    {
        _supportedFrequencyAndVoltagePairs.Add(frequencyAndVoltagePair);
        return this;
    }

    public IRamBuilder AddAvailableXmpProfiles(XmpProfile profile)
    {
        _availableXmpProfiles.Add(profile);
        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _availableMemory,
            _powerConsumption,
            _ddrVersion ?? throw new AttributeNullException(nameof(_ddrVersion)),
            _formFactor ?? throw new AttributeNullException(nameof(_formFactor)),
            _supportedFrequencyAndVoltagePairs,
            _availableXmpProfiles);
    }
}