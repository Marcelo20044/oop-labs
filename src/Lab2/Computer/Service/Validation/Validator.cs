using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Service.Validation;

public static class Validator
{
    public static BuildResult Validate(PersonalComputer computer)
    {
        Cpu cpu = computer.Cpu;
        Motherboard motherboard = computer.Motherboard;
        PowerSupply powerSupply = computer.PowerSupply;
        ComputerCase computerCase = computer.ComputerCase;
        CpuCoolingSystem cpuCoolingSystem = computer.CpuCoolingSystem;
        Bios bios = motherboard.Bios;
        IReadOnlyCollection<Ram> ramCollection = computer.RamCollection;
        IReadOnlyCollection<Ssd> ssdCollection = computer.SsdCollection;
        IReadOnlyCollection<Hdd> hddCollection = computer.HddCollection;
        VideoCard? videoCard = computer.VideoCard;
        XmpProfile? xmpProfile = computer.XmpProfile;
        WiFiAdapter? wiFiAdapter = computer.WiFiAdapter;

        // Different simple checks
        if ((cpu.HasVideoCore && videoCard is null)
            || cpu.Socket.Name != motherboard.CpuSocket.Name
            || ramCollection.Count > motherboard.RamSlotsCount
            || ramCollection.Any(ram => !ram.ValidationWithCpu(cpu))
            || bios.SupportedProcessors.All(p => p != cpu.Name)
            || (ssdCollection.Count == 0 && hddCollection.Count == 0)
            || (wiFiAdapter is not null && motherboard.HasWiFiModule)
            || cpuCoolingSystem.SupportedSockets.All(s => s.Name != cpu.Socket.Name)
            || (xmpProfile is not null
                && (!motherboard.Chipset.IsXmpSupported
                    || cpu.SupportedMemoryFrequencies
                        .All(freq => freq != xmpProfile.FrequencyAndVoltage.Frequency))))
            return new BuildResult.InvalidBuild();

        // Computer Case dimensions check
        if (videoCard is not null)
        {
            if (videoCard.Dimensions.Width > computerCase.MaxVideoCardDimensions.Width
                || videoCard.Dimensions.Length > computerCase.MaxVideoCardDimensions.Length)
                return new BuildResult.InvalidBuild();
        }

        if (computerCase.SupportedMotherboardFormFactors.All(f => f != motherboard.MotherboardFormFactor))
            return new BuildResult.InvalidBuild();

        // Power Supply ability to withstand the system load check
        int totalPowerConsumption = cpu.PowerConsumption;
        if (videoCard != null) totalPowerConsumption += videoCard.PowerConsumption;
        if (wiFiAdapter != null) totalPowerConsumption += wiFiAdapter.PowerConsumption;
        ramCollection.ForEach(ram => totalPowerConsumption += ram.PowerConsumption);
        ssdCollection.ForEach(ssd => totalPowerConsumption += ssd.PowerConsumption);
        hddCollection.ForEach(hdd => totalPowerConsumption += hdd.PowerConsumption);

        switch (totalPowerConsumption - powerSupply.PeakLoad)
        {
            case > 50:
                return new BuildResult.InvalidBuild();
            case > 0 and <= 50:
                return new BuildResult.SuccessWithComment(
                    computer,
                    "System power consumption is slightly higher than the peak load of the power supply, we don't recommend this assembly");
        }

        // Computer Cooling System ability to dissipate CPU TPD check
        if (cpu.Tpd > cpuCoolingSystem.Tpd)
        {
            return new BuildResult.SuccessWithDisclaimerOfWarranty(
                computer,
                "TPD of CPU is greater than the maximum heat dissipation mass of the CPU cooling system, so we disclaim warranty");
        }

        // If everything is okay
        return new BuildResult.Success(computer);
    }
}