using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.RamBuilders;

public class RamBuilder : IRamBuilder
{
    private int _availableMemory;
    private int _powerConsumption;
    private string? _ddrVersion;
    private string? _formFactor;
    private List<XmpProfile> _availableXmpProfiles = new();
    private List<FrequencyAndVoltage> _supportedFrequencyAndVoltagePairs = new();

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

    public IRamBuilder WithFormFactor(string formFactor)
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

    public IRamBuilder Reset()
    {
        _availableMemory = _powerConsumption = 0;
        _ddrVersion = _formFactor = null;
        _availableXmpProfiles = new List<XmpProfile>();
        _supportedFrequencyAndVoltagePairs = new List<FrequencyAndVoltage>();

        return this;
    }

    public Ram Build()
    {
        int availableMemory = _availableMemory;
        int powerConsumption = _powerConsumption;
        string? ddrVersion = _ddrVersion;
        string? formFactor = _formFactor;
        List<XmpProfile> availableXmpProfiles = _availableXmpProfiles;
        List<FrequencyAndVoltage> supportedFrequencyAndVoltagePairs = _supportedFrequencyAndVoltagePairs;

        Reset();

        return new Ram(
            availableMemory,
            powerConsumption,
            ddrVersion ?? throw new AttributeNullException(nameof(_ddrVersion)),
            formFactor ?? throw new AttributeNullException(nameof(_formFactor)),
            supportedFrequencyAndVoltagePairs,
            availableXmpProfiles);
    }
}