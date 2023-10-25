using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuBuilders;

public interface ICpuBuilder
{
    ICpuBuilder WithCoresFrequency(int frequency);
    ICpuBuilder WithCoresCount(int count);
    ICpuBuilder WithTpd(int tpd);
    ICpuBuilder WithPowerConsumption(int consumption);
    ICpuBuilder WithVideoCore();
    ICpuBuilder WithName(string name);
    ICpuBuilder WithSocket(Socket socket);
    ICpuBuilder AddSupportedMemoryFrequency(int supportedFrequency);
    ICpuBuilder Reset();
    Cpu Build();
}