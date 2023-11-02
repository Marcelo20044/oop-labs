using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuCoolingSystemBuilders;

public class CpuCoolingSystemBuilder : ICpuCoolingSystemBuilder
{
    private int _tpd;
    private Dimensions? _dimensions;
    private List<Socket> _supportedSockets = new();

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
        _supportedSockets.Add(socket);
        return this;
    }

    public ICpuCoolingSystemBuilder Reset()
    {
        _tpd = 0;
        _dimensions = null;
        _supportedSockets = new List<Socket>();

        return this;
    }

    public CpuCoolingSystem Build()
    {
        int tpd = _tpd;
        Dimensions? dimensions = _dimensions;
        List<Socket> supportedSockets = _supportedSockets;

        Reset();

        return new CpuCoolingSystem(
            tpd,
            dimensions ?? throw new AttributeNullException(nameof(_dimensions)),
            supportedSockets);
    }
}