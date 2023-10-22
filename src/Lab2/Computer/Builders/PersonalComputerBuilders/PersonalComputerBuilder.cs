using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Service.Validation;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.PersonalComputerBuilders;

public class PersonalComputerBuilder : IPersonalComputerBuilder
{
    private readonly List<Ram> _ramCollection = new();
    private readonly List<Ssd> _ssdCollection = new();
    private readonly List<Hdd> _hddCollection = new();
    private Cpu? _cpu;
    private Motherboard? _motherboard;
    private PowerSupply? _powerSupply;
    private ComputerCase? _computerCase;
    private CpuCoolingSystem? _cpuCoolingSystem;
    private VideoCard? _videoCard;
    private XmpProfile? _xmpProfile;
    private WiFiAdapter? _wiFiAdapter;

    public IPersonalComputerBuilder AddRam(Ram ram)
    {
        _ramCollection.Add(ram);
        return this;
    }

    public IPersonalComputerBuilder AddSsd(Ssd ssd)
    {
        _ssdCollection.Add(ssd);
        return this;
    }

    public IPersonalComputerBuilder AddHdd(Hdd hdd)
    {
        _hddCollection.Add(hdd);
        return this;
    }

    public IPersonalComputerBuilder WithCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IPersonalComputerBuilder WithVideoCard(VideoCard? videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public IPersonalComputerBuilder WithXmpProfile(XmpProfile? xmpProfile)
    {
        _xmpProfile = xmpProfile;
        return this;
    }

    public IPersonalComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public IPersonalComputerBuilder WithMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IPersonalComputerBuilder WithPowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IPersonalComputerBuilder WithComputerCase(ComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IPersonalComputerBuilder WithCpuCoolingSystem(CpuCoolingSystem coolingSystem)
    {
        _cpuCoolingSystem = coolingSystem;
        return this;
    }

    public BuildResult Build()
    {
        if (_cpu is null
            || _motherboard is null
            || _powerSupply is null
            || _computerCase is null
            || _cpuCoolingSystem is null)
            return new BuildResult.InvalidBuild();

        return new Validator(new PersonalComputer(
            _cpu,
            _motherboard,
            _powerSupply,
            _computerCase,
            _cpuCoolingSystem,
            _ramCollection,
            _ssdCollection,
            _hddCollection,
            _videoCard,
            _xmpProfile,
            _wiFiAdapter)).Validate();
    }
}