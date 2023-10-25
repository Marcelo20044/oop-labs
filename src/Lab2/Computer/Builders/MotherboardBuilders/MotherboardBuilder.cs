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
    private Bios? _bios;
    private Socket? _cpuSocket;
    private Chipset? _chipset;
    private MotherboardFormFactor? _formFactor;

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

    public IMotherboardBuilder WithFormFactor(MotherboardFormFactor motherboardFormFactor)
    {
        _formFactor = motherboardFormFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboardBuilder Reset()
    {
        _pciELinesCount = _sataPortsCount = _ramSlotsCount = 0;
        _hasWiFiModule = false;
        _supportedDdrVersion = null;
        _bios = null;
        _cpuSocket = null;
        _chipset = null;
        _formFactor = null;

        return this;
    }

    public Motherboard Build()
    {
        int pciELinesCount = _pciELinesCount;
        int sataPortsCount = _sataPortsCount;
        int ramSlotsCount = _ramSlotsCount;
        bool hasWiFiModule = _hasWiFiModule;
        string? supportedDdrVersion = _supportedDdrVersion;
        Bios? bios = _bios;
        Socket? cpuSocket = _cpuSocket;
        Chipset? chipset = _chipset;
        MotherboardFormFactor? formFactor = _formFactor;

        Reset();

        return new Motherboard(
            pciELinesCount,
            sataPortsCount,
            ramSlotsCount,
            hasWiFiModule,
            supportedDdrVersion ?? throw new AttributeNullException(nameof(_supportedDdrVersion)),
            cpuSocket ?? throw new AttributeNullException(nameof(_cpuSocket)),
            chipset ?? throw new AttributeNullException(nameof(_chipset)),
            formFactor ?? throw new AttributeNullException(nameof(_formFactor)),
            bios ?? throw new AttributeNullException(nameof(_bios)));
    }
}