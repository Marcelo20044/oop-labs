using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.PathSectionEntity;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Organizations;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteEntity;

public class Route
{
    public Route(IEnumerable<PathSection> pathSections)
    {
        PathSections = pathSections;
    }

    public IEnumerable<PathSection> PathSections { get; }

    public RouteReport GetRouteReport(Spaceship spaceship, ExchangeRate exchangeRate)
    {
        double generalTravelTime = 0;
        double generalFuelSpent = 0;
        double generalMoneySpent = 0;

        foreach (PathSection pathSection in PathSections)
        {
            RouteReport report = pathSection.Environment.TryGetThrough(spaceship, exchangeRate);
            if (report.Result != RouteResult.Success)
            {
                return report;
            }

            generalTravelTime += report.TravelTime;
            generalFuelSpent += report.SpentFuel;
            generalMoneySpent += report.SpentMoney;
        }

        return new RouteReport(RouteResult.Success, generalTravelTime, generalFuelSpent, generalMoneySpent);
    }
}