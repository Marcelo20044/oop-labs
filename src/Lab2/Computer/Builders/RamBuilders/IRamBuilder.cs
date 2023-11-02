using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.RamBuilders;

public interface IRamBuilder
{
    IRamBuilder WithAvailableMemory(int availableMemory);
    IRamBuilder WithPowerConsumption(int consumption);
    IRamBuilder WithDdrVersion(string version);
    IRamBuilder WithFormFactor(string formFactor);
    IRamBuilder AddSupportedRamPairs(FrequencyAndVoltage frequencyAndVoltagePair);
    IRamBuilder AddAvailableXmpProfiles(XmpProfile profile);
    IRamBuilder Reset();
    Ram Build();
}