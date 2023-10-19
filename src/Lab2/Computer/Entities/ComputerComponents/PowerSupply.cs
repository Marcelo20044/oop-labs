namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class PowerSupply : IComputerComponent
{
    public PowerSupply(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; }
}