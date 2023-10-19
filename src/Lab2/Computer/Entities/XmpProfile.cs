using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

public class XmpProfile : IComputerComponent
{
    public XmpProfile(Timings timings, FrequencyAndVoltage frequencyAndVoltage)
    {
        Timings = timings;
        FrequencyAndVoltage = frequencyAndVoltage;
    }

    public Timings Timings { get; }
    public FrequencyAndVoltage FrequencyAndVoltage { get; }
}