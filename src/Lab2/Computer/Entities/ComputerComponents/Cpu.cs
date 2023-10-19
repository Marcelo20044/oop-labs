using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class Cpu : IComputerComponent
{
    public Cpu(
        int coresFrequency,
        int coresCount,
        int supportedMemoryFrequency,
        int tpd,
        int powerConsumption,
        bool hasVideoCore,
        Socket socket)
    {
        CoresFrequency = coresFrequency;
        CoresCount = coresCount;
        SupportedMemoryFrequency = supportedMemoryFrequency;
        Tpd = tpd;
        PowerConsumption = powerConsumption;
        HasVideoCore = hasVideoCore;
        Socket = socket;
    }

    public int CoresFrequency { get; }
    public int CoresCount { get; }
    public int SupportedMemoryFrequency { get; }
    public int Tpd { get; }
    public int PowerConsumption { get; }
    public bool HasVideoCore { get; }
    public Socket Socket { get; }

    public ICpuBuilder Direct(ICpuBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        builder
            .WithCoresFrequency(CoresFrequency)
            .WithCoresCount(CoresCount)
            .WithSupportedMemoryFrequency(SupportedMemoryFrequency)
            .WithTpd(Tpd)
            .WithPowerConsumption(PowerConsumption)
            .WithSocket(Socket);

        return HasVideoCore ? builder.WithVideoCore() : builder;
    }
}