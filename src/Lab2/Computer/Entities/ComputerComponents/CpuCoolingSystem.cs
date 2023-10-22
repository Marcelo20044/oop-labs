using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuCoolingSystemBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class CpuCoolingSystem : IComputerComponent
{
    public CpuCoolingSystem(int tpd, Dimensions dimensions, IReadOnlyCollection<Socket> supportedSockets)
    {
        Tpd = tpd;
        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
    }

    public int Tpd { get; }
    public Dimensions Dimensions { get; }
    public IReadOnlyCollection<Socket> SupportedSockets { get; }

    // Debuilder for getting CPU Cooling System builder based on finished one
    public ICpuCoolingSystemBuilder Direct(ICpuCoolingSystemBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        SupportedSockets.ForEach(p => builder.AddSupportedSocket(p));

        return builder
            .WithTpd(Tpd)
            .WithDimensions(Dimensions);
    }
}