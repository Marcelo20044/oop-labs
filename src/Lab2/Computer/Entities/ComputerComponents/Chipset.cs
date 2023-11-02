using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class Chipset : IComputerComponent
{
    private Chipset(
        bool isXmpSupported,
        IReadOnlyCollection<int> availableMemoryFrequencies)
    {
        IsXmpSupported = isXmpSupported;
        AvailableMemoryFrequencies = availableMemoryFrequencies;
    }

    public bool IsXmpSupported { get; }
    public IReadOnlyCollection<int> AvailableMemoryFrequencies { get; }

    public static ChipsetBuilder Builder() => new();

    // Debuilder for getting Chipset builder based on finished one
    public ChipsetBuilder Direct(ChipsetBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        AvailableMemoryFrequencies.ForEach(p => builder.AddAvailableMemoryFrequency(p));

        return IsXmpSupported ? builder.WithXmpSupport() : builder;
    }

    public class ChipsetBuilder
    {
        private readonly List<int> _availableMemoryFrequencies = new();
        private bool _isXmpSupported;

        public ChipsetBuilder WithXmpSupport()
        {
            _isXmpSupported = true;
            return this;
        }

        public ChipsetBuilder AddAvailableMemoryFrequency(int frequency)
        {
            _availableMemoryFrequencies.Add(frequency);
            return this;
        }

        public Chipset Build()
        {
            return new Chipset(
                _isXmpSupported,
                _availableMemoryFrequencies);
        }
    }
}