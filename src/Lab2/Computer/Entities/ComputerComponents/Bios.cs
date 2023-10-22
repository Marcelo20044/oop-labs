using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class Bios : IComputerComponent
{
    private Bios(string type, string version, IReadOnlyCollection<string> supportedProcessors)
    {
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
    }

    public string Type { get; }
    public string Version { get; }
    public IReadOnlyCollection<string> SupportedProcessors { get; }

    public static BiosBuilder Builder() => new();

    // Debuilder for getting BIOS builder based on finished one
    public BiosBuilder Direct(BiosBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        SupportedProcessors.ForEach(p => builder.AddSupportedProcessor(p));

        return builder
            .WithType(Type)
            .WithVersion(Version);
    }

    // Stateful constructor builder for Bios
    public class BiosBuilder
    {
        private readonly List<string> _supportedProcessors = new();
        private string? _type;
        private string? _version;

        public BiosBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public BiosBuilder WithVersion(string version)
        {
            _version = version;
            return this;
        }

        public BiosBuilder AddSupportedProcessor(string cpuName)
        {
            _supportedProcessors.Add(cpuName);
            return this;
        }

        public Bios Build()
        {
            return new Bios(
                _type ?? throw new AttributeNullException(nameof(_type)),
                _version ?? throw new AttributeNullException(nameof(_version)),
                _supportedProcessors);
        }
    }
}