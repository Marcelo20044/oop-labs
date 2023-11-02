using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.ComputerCaseBuilders;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private Dimensions? _dimensions;
    private Dimensions? _maxVideoCardDimensions;
    private List<MotherboardFormFactor> _supportedMotherboardFormFactors = new();

    public IComputerCaseBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IComputerCaseBuilder WithMaxVideoCardDimensions(Dimensions dimensions)
    {
        _maxVideoCardDimensions = dimensions;
        return this;
    }

    public IComputerCaseBuilder AddSupportedMotherboardFormFactor(MotherboardFormFactor motherboardFormFactor)
    {
        _supportedMotherboardFormFactors.Add(motherboardFormFactor);
        return this;
    }

    public IComputerCaseBuilder Reset()
    {
        _supportedMotherboardFormFactors = new List<MotherboardFormFactor>();
        _dimensions = _maxVideoCardDimensions = null;
        return this;
    }

    public ComputerCase Build()
    {
        Dimensions? dimensions = _dimensions;
        Dimensions? videoCardDimensions = _maxVideoCardDimensions;
        List<MotherboardFormFactor> formFactors = _supportedMotherboardFormFactors;

        Reset();

        return new ComputerCase(
            dimensions ?? throw new AttributeNullException(nameof(_dimensions)),
            videoCardDimensions ?? throw new AttributeNullException(nameof(_maxVideoCardDimensions)),
            formFactors);
    }
}