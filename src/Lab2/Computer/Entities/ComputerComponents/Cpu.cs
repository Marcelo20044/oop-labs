using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class Cpu : IComputerComponent
{
    public Cpu(
        int coresFrequency,
        int coresCount,
        int tpd,
        int powerConsumption,
        bool hasVideoCore,
        string name,
        Socket socket,
        IReadOnlyCollection<int> supportedMemoryFrequencies)
    {
        CoresFrequency = coresFrequency;
        CoresCount = coresCount;
        Tpd = tpd;
        PowerConsumption = powerConsumption;
        HasVideoCore = hasVideoCore;
        Name = name;
        Socket = socket;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
    }

    public int CoresFrequency { get; }
    public int CoresCount { get; }
    public int Tpd { get; }
    public int PowerConsumption { get; }
    public bool HasVideoCore { get; }
    public string Name { get; }
    public Socket Socket { get; }
    public IReadOnlyCollection<int> SupportedMemoryFrequencies { get; }

    // Debuilder for getting CPU builder based on finished one
    public ICpuBuilder Direct(ICpuBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        SupportedMemoryFrequencies.ForEach(p => builder.AddSupportedMemoryFrequency(p));

        builder
            .WithCoresFrequency(CoresFrequency)
            .WithCoresCount(CoresCount)
            .WithTpd(Tpd)
            .WithPowerConsumption(PowerConsumption)
            .WithName(Name)
            .WithSocket(Socket);

        return HasVideoCore ? builder.WithVideoCore() : builder;
    }
}