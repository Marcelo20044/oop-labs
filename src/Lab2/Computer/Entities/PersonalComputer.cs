using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.PersonalComputerBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

public class PersonalComputer
{
    public PersonalComputer(
        Cpu cpu,
        Motherboard motherboard,
        PowerSupply powerSupply,
        ComputerCase computerCase,
        CpuCoolingSystem cpuCoolingSystem,
        IReadOnlyCollection<Ram> ramCollection,
        IReadOnlyCollection<Ssd> ssdCollection,
        IReadOnlyCollection<Hdd> hddCollection,
        VideoCard? videoCard,
        XmpProfile? xmpProfile,
        WiFiAdapter? wiFiAdapter)
    {
        Cpu = cpu;
        Motherboard = motherboard;
        PowerSupply = powerSupply;
        ComputerCase = computerCase;
        CpuCoolingSystem = cpuCoolingSystem;
        RamCollection = ramCollection;
        SsdCollection = ssdCollection;
        HddCollection = hddCollection;
        VideoCard = videoCard;
        XmpProfile = xmpProfile;
        WiFiAdapter = wiFiAdapter;
    }

    public Cpu Cpu { get; }
    public Motherboard Motherboard { get; }
    public PowerSupply PowerSupply { get; }
    public ComputerCase ComputerCase { get; }
    public CpuCoolingSystem CpuCoolingSystem { get; }
    public IReadOnlyCollection<Ram> RamCollection { get; }
    public IReadOnlyCollection<Ssd> SsdCollection { get; }
    public IReadOnlyCollection<Hdd> HddCollection { get; }
    public VideoCard? VideoCard { get; }
    public XmpProfile? XmpProfile { get; }
    public WiFiAdapter? WiFiAdapter { get; }

    public IPersonalComputerBuilder Direct(IPersonalComputerBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        RamCollection.ForEach(ram => builder.AddRam(ram));
        SsdCollection.ForEach(ssd => builder.AddSsd(ssd));
        HddCollection.ForEach(hdd => builder.AddHdd(hdd));

        return builder
            .WithCpu(Cpu)
            .WithMotherboard(Motherboard)
            .WithPowerSupply(PowerSupply)
            .WithComputerCase(ComputerCase)
            .WithCpuCoolingSystem(CpuCoolingSystem)
            .WithVideoCard(VideoCard)
            .WithXmpProfile(XmpProfile)
            .WithWiFiAdapter(WiFiAdapter);
    }
}