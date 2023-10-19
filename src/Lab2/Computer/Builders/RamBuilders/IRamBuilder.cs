using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.RamBuilders;

public interface IRamBuilder
{
    IRamBuilder WithAvailableMemory(int availableMemory);
    IRamBuilder WithPowerConsumption(int consumption);
    IRamBuilder WithDdrVersion(string version);
    IRamBuilder WithFormFactor(RamFormFactor formFactor);
    IRamBuilder AddSupportedRamPairs(FrequencyAndVoltage frequencyAndVoltagePair);
    IRamBuilder AddAvailableXmpProfiles(XmpProfile profile);
    Ram Build();
}