using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.CpuCoolingSystemBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.MotherboardBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.PersonalComputerBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.RamBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

#pragma warning disable CA1707

public class ComputerConfiguratorTests
{
    private readonly ComputerComponentRepository _repository = ComputerComponentRepository.Instance;

    public ComputerConfiguratorTests()
    {
        var cpuBuilder = new CpuBuilder();
        var ramBuilder = new RamBuilder();
        var motherboardBuilder = new MotherboardBuilder();

        // CPU registration
        _repository.RegisterCpu(cpuBuilder.WithName("Intel Core i7-10700F")
            .WithCoresCount(8).WithCoresFrequency(2900).WithSocket(new Socket("LGA 1200"))
            .WithPowerConsumption(100).WithTpd(65).AddSupportedMemoryFrequency(2933)
            .AddSupportedMemoryFrequency(2800).AddSupportedMemoryFrequency(2666)
            .AddSupportedMemoryFrequency(2400).AddSupportedMemoryFrequency(2133).Build());

        // Motherboard registration
        Bios ami325 = Bios.Builder().WithType("ami").WithVersion("3.25")
            .AddSupportedProcessor("Intel Core i7-10700F").Build();

        Chipset intelH470Chipset = Chipset.Builder().WithXmpSupport()
            .AddAvailableMemoryFrequency(2933).AddAvailableMemoryFrequency(2800)
            .AddAvailableMemoryFrequency(2666).Build();

        _repository.RegisterMotherboard(motherboardBuilder.WithPciELinesCount(2)
            .WithSataPortsCount(4).WithRamSlotsCount(2).WithSupportedDdrVersion("DDR4")
            .WithCpuSocket(new Socket("LGA 1200")).WithChipset(intelH470Chipset)
            .WithFormFactor(new MotherboardFormFactor("АTX", new Dimensions(305, 244)))
            .WithBios(ami325).Build());

        // RAM registration
        _repository.RegisterRam(ramBuilder.WithAvailableMemory(8)
            .WithPowerConsumption(2).WithDdrVersion("DDR4")
            .WithFormFactor("DIMM")
            .AddSupportedRamPairs(new FrequencyAndVoltage(2666, 1)).Build());

        // HDD registration
        const int hddMemoryCapacityInGb = 1024;
        const int hddSpindleSpeedInRpm = 7200;
        const int hddPowerConsumption = 6;
        _repository.RegisterHdd(new Hdd(
            hddMemoryCapacityInGb,
            hddSpindleSpeedInRpm,
            hddPowerConsumption));

        // CPU Cooling System registration
        const int coolingSystemTpd = 150;
        const int coolingSystemLength = 155;
        const int coolingSystemWidth = 80;
        Socket[] coolingSystemSupportedSockets =
        {
            new Socket("LGA 1366"), new Socket("LGA 1200"),
            new Socket("LGA 1156"), new Socket("LGA 1156"),
        };

        _repository.RegisterCpuCoolingSystem(new CpuCoolingSystem(
            coolingSystemTpd,
            new Dimensions(coolingSystemLength, coolingSystemWidth),
            coolingSystemSupportedSockets));

        // Video Card registration
        const int videoMemoryCountInGb = 4;
        const int videoChipFrequencyInMHz = 1100;
        const int videoCardPowerConsumption = 50;
        const int videoCardLength = 155;
        const int videoCardWidth = 112;
        const string videoCardPciEVersion = "3.0";

        _repository.RegisterVideoCard(new VideoCard(
            videoMemoryCountInGb,
            videoChipFrequencyInMHz,
            videoCardPowerConsumption,
            videoCardPciEVersion,
            new Dimensions(videoCardLength, videoCardWidth)));

        // Computer Case registration
        const int computerCaseLength = 405;
        const int computerCaseWidth = 190;
        const int maxVideoCardLength = 250;
        const int maxVideoCardWidth = 200;
        MotherboardFormFactor[] supportedMotherboardFormFactors =
        {
            new("АTX", new Dimensions(305, 244)),
        };

        _repository.RegisterComputerCase(new ComputerCase(
            new Dimensions(computerCaseLength, computerCaseWidth),
            new Dimensions(maxVideoCardLength, maxVideoCardWidth),
            supportedMotherboardFormFactors));

        // Power Supply registration
        const int peakLoad = 450;
        _repository.RegisterPowerSupply(new PowerSupply(peakLoad));
    }

    [Fact]
    public void ValidComputerBuild_ShouldBeSuccess()
    {
        BuildResult result = GetBuilderWithValidBuild().Build();

        Assert.IsType<BuildResult.Success>(result);
    }

    [Fact]
    public void
        BuildWithDeclaredConsumptionGreaterThanMaximumAvailableButSufficientToStartSystem_ShouldBeSuccessWithComment()
    {
        const int smallPeakLoad = 120;
        BuildResult buildResult = GetBuilderWithValidBuild()
            .WithPowerSupply(new PowerSupply(smallPeakLoad)).Build();

        Assert.IsType<BuildResult.SuccessWithComment>(buildResult);
    }

    [Fact]
    public void BuildWithInsufficientCoolerPower_ShouldBeSuccessWithDisclaimerOfWarranty()
    {
        PersonalComputer validComputer = GetValidComputer();

        const int smallCoolerTpd = 50;
        CpuCoolingSystem weakCooler = validComputer.CpuCoolingSystem
            .Direct(new CpuCoolingSystemBuilder()).WithTpd(smallCoolerTpd).Build();

        BuildResult buildResult = validComputer.Direct(new PersonalComputerBuilder())
            .WithCpuCoolingSystem(weakCooler).Build();

        Assert.IsType<BuildResult.SuccessWithDisclaimerOfWarranty>(buildResult);
    }

    [Fact]
    public void BuildWithIncompatibleCpuAndMotherboard_ShouldBeInvalidBuild()
    {
        PersonalComputer validComputer = GetValidComputer();

        var cpuSocket = new Socket("LGA 1366");
        Cpu incompatibleCpu = validComputer.Cpu.Direct(new CpuBuilder())
            .WithSocket(cpuSocket).Build();

        BuildResult buildResult = validComputer.Direct(new PersonalComputerBuilder())
            .WithCpu(incompatibleCpu).Build();

        Assert.IsType<BuildResult.InvalidBuild>(buildResult);
    }

    private IPersonalComputerBuilder GetBuilderWithValidBuild()
    {
        Cpu cpu = _repository.FindFirstCpu(c => c.Name == "Intel Core i7-10700F");
        Motherboard motherboard = _repository
            .FindFirstMotherboard(m => m.CpuSocket.Name == cpu.Socket.Name);

        Ram ram = _repository.FindFirstRam(r => r.DdrVersion == motherboard.SupportedDdrVersion);
        Hdd hdd = _repository.FindFirstHdd(h => h.Capacity > 500);

        CpuCoolingSystem cpuCoolingSystem = _repository
            .FindFirstCpuCoolingSystem(ccs => ccs.Tpd > cpu.Tpd);
        ComputerCase computerCase = _repository
            .FindFirstComputerCase(cc => cc.SupportedMotherboardFormFactors
                .Any(f => f == motherboard.MotherboardFormFactor));

        VideoCard videoCard = _repository.FindFirstVideoCard(v => v.VideoMemoryCount > 2);
        PowerSupply powerSupply = _repository.FindFirstPowerSupply(p => p.PeakLoad > 200);

        return new PersonalComputerBuilder().WithCpu(cpu).WithMotherboard(motherboard)
            .AddRam(ram).AddHdd(hdd).WithCpuCoolingSystem(cpuCoolingSystem)
            .WithComputerCase(computerCase).WithVideoCard(videoCard)
            .WithPowerSupply(powerSupply);
    }

    private PersonalComputer GetValidComputer()
    {
        var result = (BuildResult.Success)GetBuilderWithValidBuild().Build();
        return result.Computer;
    }
}

#pragma warning restore CA1707