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
        string supportedDdrVersion,
        Socket cpuSocket,
        Chipset chipset,
        FormFactor formFactor,
        Bios bios)
    {
        PciELinesCount = pciELinesCount;
        SataPortsCount = sataPortsCount;
        RamSlotsCount = ramSlotsCount;
        SupportedDdrVersion = supportedDdrVersion;
        CpuSocket = cpuSocket;
        Chipset = chipset;
        FormFactor = formFactor;
        Bios = bios;
    }

    public int PciELinesCount { get; }
    public int SataPortsCount { get; }
    public int RamSlotsCount { get; }
    public string SupportedDdrVersion { get; }
    public Socket CpuSocket { get; }
    public Chipset Chipset { get; }
    public FormFactor FormFactor { get; }
    public Bios Bios { get; }

    public IMotherboardBuilder Direct(IMotherboardBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        return builder
            .WithPciELinesCount(PciELinesCount)
            .WithSataPortsCount(SataPortsCount)
            .WithRamSlotsCount(RamSlotsCount)
            .WithSupportedDdrVersion(SupportedDdrVersion)
            .WithCpuSocket(CpuSocket)
            .WithChipset(Chipset)
            .WithFormFactor(FormFactor)
            .WithBios(Bios);
    }
}