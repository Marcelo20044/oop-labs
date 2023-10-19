using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

public class Ram
{
    public Ram(
        int availableMemory,
        int powerConsumption,
        string ddrVersion,
        RamFormFactor formFactor,
        IReadOnlyCollection<FrequencyAndVoltage> supportedFrequencyAndVoltagesPairs,
        IReadOnlyCollection<XmpProfile> availableXmpProfiles)
    {
        AvailableMemory = availableMemory;
        PowerConsumption = powerConsumption;
        DdrVersion = ddrVersion;
        FormFactor = formFactor;
        SupportedFrequencyAndVoltagesPairs = supportedFrequencyAndVoltagesPairs;
        AvailableXmpProfiles = availableXmpProfiles;
    }

    public int AvailableMemory { get; }
    public int PowerConsumption { get; }
    public string DdrVersion { get; }
    public RamFormFactor FormFactor { get; }
    public IReadOnlyCollection<FrequencyAndVoltage> SupportedFrequencyAndVoltagesPairs { get; }
    public IReadOnlyCollection<XmpProfile> AvailableXmpProfiles { get; }
}