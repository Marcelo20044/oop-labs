using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

public static class SpaceResearchDepartment
{
    public static RouteResult GetTravelStatus(Route route, ISpaceship spaceship, ExchangeRate exchangeRate)
    {
        if (route is null)
        {
            throw new ArgumentNullException(nameof(route), "Route can't be null");
        }

        return route.GetRouteReport(spaceship, exchangeRate).Result;
    }

    public static ISpaceship? FindBestSpaceshipForRoute(Route route, IEnumerable<ISpaceship> spaceships, ExchangeRate exchangeRate)
    {
        if (route is null)
        {
            throw new ArgumentNullException(nameof(route), "Route can't be null");
        }

        if (spaceships is null)
        {
            throw new ArgumentNullException(nameof(spaceships), "Spaceships can't be null");
        }

        ISpaceship? bestSpaceship = null;
        double lowestPrice = double.MaxValue;
        foreach (ISpaceship ship in spaceships)
        {
            RouteReport report = route.GetRouteReport(ship, exchangeRate);
            if (report.Result != RouteResult.Success)
            {
                continue;
            }

            if (report.SpentMoney >= lowestPrice) continue;
            bestSpaceship = ship;
            lowestPrice = report.SpentMoney;
        }

        return bestSpaceship;
    }
}