using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.ComputerCaseBuilders;

public interface IComputerCaseBuilder
{
    IComputerCaseBuilder WithDimensions(Dimensions dimensions);
    IComputerCaseBuilder WithMaxVideoCardDimensions(Dimensions dimensions);
    IComputerCaseBuilder AddSupportedMotherboardFormFactor(MotherboardFormFactor motherboardFormFactor);
    IComputerCaseBuilder Reset();
    ComputerCase Build();
}