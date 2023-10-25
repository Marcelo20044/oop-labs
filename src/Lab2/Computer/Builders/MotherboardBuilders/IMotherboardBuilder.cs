using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.MotherboardBuilders;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithPciELinesCount(int pciELinesCount);
    IMotherboardBuilder WithSataPortsCount(int sataPortsCount);
    IMotherboardBuilder WithRamSlotsCount(int ramSlotsCount);
    IMotherboardBuilder WithWiFiModule();
    IMotherboardBuilder WithSupportedDdrVersion(string version);
    IMotherboardBuilder WithCpuSocket(Socket socket);
    IMotherboardBuilder WithChipset(Chipset chipset);
    IMotherboardBuilder WithFormFactor(MotherboardFormFactor motherboardFormFactor);
    IMotherboardBuilder WithBios(Bios bios);
    IMotherboardBuilder Reset();
    Motherboard Build();
}