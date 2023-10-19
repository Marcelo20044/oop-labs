using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.ComputerCaseBuilders;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private readonly List<FormFactor> _supportedMotherboardFormFactors = new();
    private Dimensions? _dimensions;
    private Dimensions? _maxVideoCardDimensions;

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

    public IComputerCaseBuilder AddSupportedMotherboardFormFactor(FormFactor formFactor)
    {
        _supportedMotherboardFormFactors.Add(formFactor);
        return this;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(
            _dimensions ?? throw new AttributeNullException(nameof(_dimensions)),
            _maxVideoCardDimensions ?? throw new AttributeNullException(nameof(_maxVideoCardDimensions)),
            _supportedMotherboardFormFactors);
    }
}