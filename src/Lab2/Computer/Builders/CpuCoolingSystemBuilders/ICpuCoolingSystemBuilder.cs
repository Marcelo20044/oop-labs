using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuCoolingSystemBuilders;

public interface ICpuCoolingSystemBuilder
{
    ICpuCoolingSystemBuilder WithTpd(int tpd);

    ICpuCoolingSystemBuilder WithDimensions(Dimensions dimensions);

    ICpuCoolingSystemBuilder AddSupportedSocket(Socket socket);

    CpuCoolingSystem Build();
}