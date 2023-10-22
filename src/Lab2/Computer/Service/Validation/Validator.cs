using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Service.Validation;

public class Validator
{
    public Validator(PersonalComputer computer)
    {
        Computer = computer;
        Cpu = computer.Cpu;
        Motherboard = computer.Motherboard;
        PowerSupply = computer.PowerSupply;
        ComputerCase = computer.ComputerCase;
        CpuCoolingSystem = computer.CpuCoolingSystem;
        Bios = Motherboard.Bios;
        RamCollection = computer.RamCollection;
        SsdCollection = computer.SsdCollection;
        HddCollection = computer.HddCollection;
        VideoCard = computer.VideoCard;
        XmpProfile = computer.XmpProfile;
        WiFiAdapter = computer.WiFiAdapter;
    }

    private PersonalComputer Computer { get; }
    private Cpu Cpu { get; }
    private Bios Bios { get; }
    private Motherboard Motherboard { get; }
    private PowerSupply PowerSupply { get; }
    private ComputerCase ComputerCase { get; }
    private CpuCoolingSystem CpuCoolingSystem { get; }
    private IReadOnlyCollection<Ram> RamCollection { get; }
    private IReadOnlyCollection<Ssd> SsdCollection { get; }
    private IReadOnlyCollection<Hdd> HddCollection { get; }
    private VideoCard? VideoCard { get; }
    private XmpProfile? XmpProfile { get; }
    private WiFiAdapter? WiFiAdapter { get; }

    public BuildResult Validate()
    {
        // Different simple checks
        if ((Cpu.HasVideoCore && VideoCard is null)
            || Cpu.Socket != Motherboard.CpuSocket
            || RamCollection.Count > Motherboard.RamSlotsCount
            || RamCollection.Any(ram => !ram.ValidationWithCpu(Cpu))
            || Bios.SupportedProcessors.All(p => p != Cpu.Name)
            || (SsdCollection.Count == 0 && HddCollection.Count == 0)
            || (WiFiAdapter is not null && Motherboard.HasWiFiModule)
            || (XmpProfile is not null
                 && (!Motherboard.Chipset.IsXmpSupported
                 || Cpu.SupportedMemoryFrequencies
                     .All(freq => freq != XmpProfile.FrequencyAndVoltage.Frequency))))
            return new BuildResult.InvalidBuild();

        // Computer Case dimensions check
        if (VideoCard is not null)
        {
            if (VideoCard.Dimensions.Width > ComputerCase.MaxVideoCardDimensions.Width
                || VideoCard.Dimensions.Length > ComputerCase.MaxVideoCardDimensions.Length)
                return new BuildResult.InvalidBuild();
        }

        if (ComputerCase.SupportedMotherboardFormFactors.All(f => f != Motherboard.FormFactor))
            return new BuildResult.InvalidBuild();

        // Power Supply ability to withstand the system load check
        int totalPowerConsumption = Cpu.PowerConsumption;
        if (VideoCard != null) totalPowerConsumption += VideoCard.PowerConsumption;
        if (WiFiAdapter != null) totalPowerConsumption += WiFiAdapter.PowerConsumption;
        RamCollection.ForEach(ram => totalPowerConsumption += ram.PowerConsumption);
        SsdCollection.ForEach(ssd => totalPowerConsumption += ssd.PowerConsumption);
        HddCollection.ForEach(hdd => totalPowerConsumption += hdd.PowerConsumption);

        switch (totalPowerConsumption - PowerSupply.PeakLoad)
        {
            case > 50:
                return new BuildResult.InvalidBuild();
            case > 0 and <= 50:
                return new BuildResult.SuccessWithComment(
                    Computer,
                    "System power consumption is slightly higher than the peak load of the power supply, we don't recommend this assembly");
        }

        // Computer Cooling System ability to dissipate CPU TPD check
        if (Cpu.Tpd > CpuCoolingSystem.Tpd)
        {
            return new BuildResult.SuccessWithDisclaimerOfWarranty(
                Computer,
                "TPD of CPU is greater than the maximum heat dissipation mass of the CPU cooling system, so we disclaim warranty");
        }

        // If everything is okay
        return new BuildResult.Success(Computer);
    }
}