using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuBuilders;

public class CpuBuilder : ICpuBuilder
{
    private int _coresFrequency;
    private int _coresCount;
    private int _tpd;
    private int _powerConsumption;
    private bool _hasVideoCore;
    private string? _name;
    private Socket? _socket;
    private List<int> _supportedMemoryFrequency = new();

    public ICpuBuilder WithCoresFrequency(int frequency)
    {
        _coresFrequency = frequency;
        return this;
    }

    public ICpuBuilder WithCoresCount(int count)
    {
        _coresCount = count;
        return this;
    }

    public ICpuBuilder WithTpd(int tpd)
    {
        _tpd = tpd;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public ICpuBuilder WithVideoCore()
    {
        _hasVideoCore = true;
        return this;
    }

    public ICpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder AddSupportedMemoryFrequency(int supportedFrequency)
    {
        _supportedMemoryFrequency.Add(supportedFrequency);
        return this;
    }

    public ICpuBuilder Reset()
    {
        _coresFrequency = _coresCount = _tpd = _powerConsumption = 0;
        _hasVideoCore = false;
        _name = null;
        _socket = null;
        _supportedMemoryFrequency = new List<int>();

        return this;
    }

    public Cpu Build()
    {
        int coresFrequency = _coresFrequency;
        int coresCount = _coresCount;
        int tpd = _tpd;
        int powerConsumption = _powerConsumption;
        bool hasVideoCore = _hasVideoCore;
        string? name = _name;
        Socket? socket = _socket;
        List<int> supportedMemoryFrequency = _supportedMemoryFrequency;

        Reset();

        return new Cpu(
            coresFrequency,
            coresCount,
            tpd,
            powerConsumption,
            hasVideoCore,
            name ?? throw new AttributeNullException(nameof(_name)),
            socket ?? throw new AttributeNullException(nameof(_socket)),
            supportedMemoryFrequency);
    }
}