using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.MotherboardBuilders;

public class MotherboardBuilder : IMotherboardBuilder
{
    private int _pciELinesCount;
    private int _sataPortsCount;
    private int _ramSlotsCount;
    private bool _hasWiFiModule;
    private string? _supportedDdrVersion;
    private Socket? _cpuSocket;
    private Chipset? _chipset;
    private FormFactor? _formFactor;
    private Bios? _bios;

    public IMotherboardBuilder WithPciELinesCount(int pciELinesCount)
    {
        _pciELinesCount = pciELinesCount;
        return this;
    }

    public IMotherboardBuilder WithSataPortsCount(int sataPortsCount)
    {
        _sataPortsCount = sataPortsCount;
        return this;
    }

    public IMotherboardBuilder WithRamSlotsCount(int ramSlotsCount)
    {
        _ramSlotsCount = ramSlotsCount;
        return this;
    }

    public IMotherboardBuilder WithWiFiModule()
    {
        _hasWiFiModule = true;
        return this;
    }

    public IMotherboardBuilder WithSupportedDdrVersion(string version)
    {
        _supportedDdrVersion = version;
        return this;
    }

    public IMotherboardBuilder WithCpuSocket(Socket socket)
    {
        _cpuSocket = socket;
        return this;
    }

    public IMotherboardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _pciELinesCount,
            _sataPortsCount,
            _ramSlotsCount,
            _hasWiFiModule,
            _supportedDdrVersion ?? throw new AttributeNullException(nameof(_supportedDdrVersion)),
            _cpuSocket ?? throw new AttributeNullException(nameof(_cpuSocket)),
            _chipset ?? throw new AttributeNullException(nameof(_chipset)),
            _formFactor ?? throw new AttributeNullException(nameof(_formFactor)),
            _bios ?? throw new AttributeNullException(nameof(_bios)));
    }
}