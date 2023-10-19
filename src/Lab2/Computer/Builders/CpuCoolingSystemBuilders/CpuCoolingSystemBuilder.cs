using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuCoolingSystemBuilders;

public class CpuCoolingSystemBuilder : ICpuCoolingSystemBuilder
{
    private readonly List<Socket> _supportedProcessors = new();
    private int _tpd;
    private Dimensions? _dimensions;

    public ICpuCoolingSystemBuilder WithTpd(int tpd)
    {
        _tpd = tpd;
        return this;
    }

    public ICpuCoolingSystemBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public ICpuCoolingSystemBuilder AddSupportedSocket(Socket socket)
    {
        _supportedProcessors.Add(socket);
        return this;
    }

    public CpuCoolingSystem Build()
    {
        return new CpuCoolingSystem(
            _tpd,
            _dimensions ?? throw new AttributeNullException(nameof(_dimensions)),
            _supportedProcessors);
    }
}