using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

public static class SpaceResearchDepartment
{
    public static RouteResult GetTravelStatus(Route route, BaseSpaceship baseSpaceship, ExchangeRate exchangeRate)
    {
        if (route == null)
        {
            throw new ArgumentNullException(nameof(route), "Route can't be null");
        }

        return route.GetRouteReport(baseSpaceship, exchangeRate).Result;
    }

    public static BaseSpaceship? FindBestSpaceshipForRoute(Route route, IEnumerable<BaseSpaceship> spaceships, ExchangeRate exchangeRate)
    {
        if (route == null)
        {
            throw new ArgumentNullException(nameof(route), "Route can't be null");
        }

        if (spaceships == null)
        {
            throw new ArgumentNullException(nameof(spaceships), "Spaceships can't be null");
        }

        BaseSpaceship? bestSpaceship = null;
        double lowestPrice = double.MaxValue;
        foreach (BaseSpaceship ship in spaceships)
        {
            RouteReport report = route.GetRouteReport(ship, exchangeRate);
            if (report.Result != RouteResult.Success)
            {
                continue;
            }

            if (report.SpentMoney < lowestPrice)
            {
                bestSpaceship = ship;
                lowestPrice = report.SpentMoney;
            }
        }

        return bestSpaceship;
    }
}