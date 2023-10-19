using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuBuilders;

public class CpuBuilder : ICpuBuilder
{
    private int _coresFrequency;
    private int _coresCount;
    private int _supportedMemoryFrequency;
    private int _tpd;
    private int _powerConsumption;
    private bool _hasVideoCore;
    private Socket? _socket;

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

    public ICpuBuilder WithSupportedMemoryFrequency(int supportedFrequency)
    {
        _supportedMemoryFrequency = supportedFrequency;
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

    public ICpuBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _coresFrequency,
            _coresCount,
            _supportedMemoryFrequency,
            _tpd,
            _powerConsumption,
            _hasVideoCore,
            _socket ?? throw new AttributeNullException(nameof(_socket)));
    }
}