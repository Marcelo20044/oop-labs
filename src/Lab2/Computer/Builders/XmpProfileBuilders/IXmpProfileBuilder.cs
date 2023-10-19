using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.XmpProfileBuilders;

public interface IXmpProfileBuilder
{
    IXmpProfileBuilder WithTimings(Timings timings);
    IXmpProfileBuilder WithFrequencyAndVoltage(FrequencyAndVoltage frequencyAndVoltage);
    XmpProfile Build();
}