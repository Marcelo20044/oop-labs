using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.ComputerCaseBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class ComputerCase : IComputerComponent
{
    public ComputerCase(
        Dimensions dimensions,
        Dimensions maxVideoCardDimensions,
        IReadOnlyCollection<MotherboardFormFactor> supportedMotherboardFormFactors)
    {
        Dimensions = dimensions;
        MaxVideoCardDimensions = maxVideoCardDimensions;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
    }

    public Dimensions Dimensions { get; }
    public Dimensions MaxVideoCardDimensions { get; }
    public IReadOnlyCollection<MotherboardFormFactor> SupportedMotherboardFormFactors { get; }

    // Debuilder for getting Computer Case builder based on finished one
    public IComputerCaseBuilder Direct(IComputerCaseBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        SupportedMotherboardFormFactors.ForEach(p => builder.AddSupportedMotherboardFormFactor(p));

        return builder
            .WithDimensions(Dimensions)
            .WithMaxVideoCardDimensions(MaxVideoCardDimensions);
    }
}