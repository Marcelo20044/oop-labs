using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

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
}