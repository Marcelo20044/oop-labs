using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class ComputerComponentRepository
{
    private static ComputerComponentRepository? _instance;

    private readonly Collection<Cpu> _cpus = new();
    private readonly Collection<Ram> _rams = new();
    private readonly Collection<Ssd> _ssds = new();
    private readonly Collection<Hdd> _hdds = new();
    private readonly Collection<VideoCard> _videoCards = new();
    private readonly Collection<XmpProfile> _xmpProfiles = new();
    private readonly Collection<Motherboard> _motherboards = new();
    private readonly Collection<WiFiAdapter> _wiFiAdapters = new();
    private readonly Collection<PowerSupply> _powerSupplies = new();
    private readonly Collection<ComputerCase> _computerCases = new();
    private readonly Collection<CpuCoolingSystem> _cpuCoolingSystems = new();

    private ComputerComponentRepository() { }

    public static ComputerComponentRepository Instance
    {
        get
        {
            return _instance ??= new ComputerComponentRepository();
        }
    }

    public void RegisterCpu(Cpu cpu)
    {
        _cpus.Add(cpu);
    }

    public void RegisterRam(Ram ram)
    {
        _rams.Add(ram);
    }

    public void RegisterCpu(Ssd ssd)
    {
        _ssds.Add(ssd);
    }

    public void RegisterHdd(Hdd hdd)
    {
        _hdds.Add(hdd);
    }

    public void RegisterVideoCard(VideoCard videoCard)
    {
        _videoCards.Add(videoCard);
    }

    public void RegisterXmpProfile(XmpProfile xmpProfile)
    {
        _xmpProfiles.Add(xmpProfile);
    }

    public void RegisterMotherboard(Motherboard motherboard)
    {
        _motherboards.Add(motherboard);
    }

    public void RegisterWifFAdapter(WiFiAdapter wiFiAdapter)
    {
        _wiFiAdapters.Add(wiFiAdapter);
    }

    public void RegisterPowerSupply(PowerSupply powerSupply)
    {
        _powerSupplies.Add(powerSupply);
    }

    public void RegisterComputerCase(ComputerCase computerCase)
    {
        _computerCases.Add(computerCase);
    }

    public void RegisterCpuCoolingSystem(CpuCoolingSystem coolingSystem)
    {
        _cpuCoolingSystems.Add(coolingSystem);
    }

    public Cpu FindFirstCpu(Func<Cpu, bool> predicate)
    {
        return _cpus.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable CPU");
    }

    public Motherboard FindFirstMotherboard(Func<Motherboard, bool> predicate)
    {
        return _motherboards.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable Motherboard");
    }

    public Ram FindFirstRam(Func<Ram, bool> predicate)
    {
        return _rams.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable RAM");
    }

    public Ssd FindFirstSsd(Func<Ssd, bool> predicate)
    {
        return _ssds.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable SSD");
    }

    public Hdd FindFirstHdd(Func<Hdd, bool> predicate)
    {
        return _hdds.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable HDD");
    }

    public CpuCoolingSystem FindFirstCpuCoolingSystem(Func<CpuCoolingSystem, bool> predicate)
    {
        return _cpuCoolingSystems.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable CPU Cooling System");
    }

    public ComputerCase FindFirstComputerCase(Func<ComputerCase, bool> predicate)
    {
        return _computerCases.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable Computer Case");
    }

    public PowerSupply FindFirstPowerSupply(Func<PowerSupply, bool> predicate)
    {
        return _powerSupplies.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable Power Supply");
    }

    public VideoCard FindFirstVideoCard(Func<VideoCard, bool> predicate)
    {
        return _videoCards.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable Video Card");
    }

    public XmpProfile FindFirstXmpProfile(Func<XmpProfile, bool> predicate)
    {
        return _xmpProfiles.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable Xmp Profile");
    }

    public WiFiAdapter FindFirstWiFiAdapters(Func<WiFiAdapter, bool> predicate)
    {
        return _wiFiAdapters.FirstOrDefault(predicate)
               ?? throw new ComputerComponentNotFoundException("There is no suitable WiFi Adapter");
    }
}