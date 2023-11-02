using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.MotherboardBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class Motherboard : IComputerComponent
{
    public Motherboard(
        int pciELinesCount,
        int sataPortsCount,
        int ramSlotsCount,
        bool hasWiFiModule,
        string supportedDdrVersion,
        Socket cpuSocket,
        Chipset chipset,
        MotherboardFormFactor motherboardFormFactor,
        Bios bios)
    {
        PciELinesCount = pciELinesCount;
        SataPortsCount = sataPortsCount;
        RamSlotsCount = ramSlotsCount;
        HasWiFiModule = hasWiFiModule;
        SupportedDdrVersion = supportedDdrVersion;
        CpuSocket = cpuSocket;
        Chipset = chipset;
        MotherboardFormFactor = motherboardFormFactor;
        Bios = bios;
    }

    public int PciELinesCount { get; }
    public int SataPortsCount { get; }
    public int RamSlotsCount { get; }
    public bool HasWiFiModule { get; }
    public string SupportedDdrVersion { get; }
    public Socket CpuSocket { get; }
    public Chipset Chipset { get; }
    public MotherboardFormFactor MotherboardFormFactor { get; }
    public Bios Bios { get; }

    // Debuilder for getting Motherboard builder based on finished one
    public IMotherboardBuilder Direct(IMotherboardBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        builder
            .WithPciELinesCount(PciELinesCount)
            .WithSataPortsCount(SataPortsCount)
            .WithRamSlotsCount(RamSlotsCount)
            .WithSupportedDdrVersion(SupportedDdrVersion)
            .WithCpuSocket(CpuSocket)
            .WithChipset(Chipset)
            .WithFormFactor(MotherboardFormFactor)
            .WithBios(Bios);

        return HasWiFiModule ? builder.WithWiFiModule() : builder;
    }
}