using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.PersonalComputerBuilders;

public interface IPersonalComputerBuilder
{
    IPersonalComputerBuilder AddRam(Ram ram);
    IPersonalComputerBuilder AddSsd(Ssd ssd);
    IPersonalComputerBuilder AddHdd(Hdd hdd);
    IPersonalComputerBuilder WithCpu(Cpu cpu);
    IPersonalComputerBuilder WithVideoCard(VideoCard? videoCard);
    IPersonalComputerBuilder WithXmpProfile(XmpProfile? xmpProfile);
    IPersonalComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter);
    IPersonalComputerBuilder WithMotherboard(Motherboard motherboard);
    IPersonalComputerBuilder WithPowerSupply(PowerSupply powerSupply);
    IPersonalComputerBuilder WithComputerCase(ComputerCase computerCase);
    IPersonalComputerBuilder WithCpuCoolingSystem(CpuCoolingSystem coolingSystem);
    BuildResult Build();
}