using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

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
}