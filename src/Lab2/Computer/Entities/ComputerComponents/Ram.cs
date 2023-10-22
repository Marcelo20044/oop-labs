using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.RamBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class Ram : IComputerComponent
{
    public Ram(
        int availableMemory,
        int powerConsumption,
        string ddrVersion,
        FormFactor formFactor,
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
    public FormFactor FormFactor { get; }
    public IReadOnlyCollection<FrequencyAndVoltage> SupportedFrequencyAndVoltagesPairs { get; }
    public IReadOnlyCollection<XmpProfile> AvailableXmpProfiles { get; }

    public bool ValidationWithCpu(Cpu cpu)
    {
        return SupportedFrequencyAndVoltagesPairs
            .Any(frequencyAndVoltage => cpu.SupportedMemoryFrequencies
                .Any(cpuFrequency => cpuFrequency == frequencyAndVoltage.Frequency));
    }

    // Debuilder for getting RAM builder based on finished one
    public IRamBuilder Direct(IRamBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        AvailableXmpProfiles.ForEach(p => builder.AddAvailableXmpProfiles(p));
        SupportedFrequencyAndVoltagesPairs.ForEach(p => builder.AddSupportedRamPairs(p));

        return builder
            .WithAvailableMemory(AvailableMemory)
            .WithPowerConsumption(PowerConsumption)
            .WithDdrVersion(DdrVersion)
            .WithFormFactor(FormFactor);
    }
}