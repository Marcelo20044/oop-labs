using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public class Route
{
    public Route(IEnumerable<PathSection.PathSection> pathSections)
    {
        PathSections = pathSections;
    }

    public IEnumerable<PathSection.PathSection> PathSections { get; }

    public RouteReport GetRouteReport(BaseSpaceship baseSpaceship, ExchangeRate exchangeRate)
    {
        double generalTravelTime = 0;
        double generalFuelSpent = 0;
        double generalMoneySpent = 0;

        foreach (PathSection.PathSection pathSection in PathSections)
        {
            RouteReport report = pathSection.BaseEnvironment.TryGetThrough(baseSpaceship, exchangeRate);
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