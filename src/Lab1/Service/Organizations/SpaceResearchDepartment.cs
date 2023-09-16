using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Organizations;

public static class SpaceResearchDepartment
{
    public static RouteResult GetTravelStatus(Route route, Spaceship spaceship)
    {
        if (route == null)
        {
            throw new ArgumentNullException(nameof(route), "Route can't be null");
        }

        return route.GetRouteReport(spaceship).Result;
    }

    public static Spaceship? FindBestSpaceshipForRoute(Route route, IEnumerable<Spaceship> spaceships)
    {
        if (route == null)
        {
            throw new ArgumentNullException(nameof(route), "Route can't be null");
        }

        if (spaceships == null)
        {
            throw new ArgumentNullException(nameof(spaceships), "Spaceships can't be null");
        }

        Spaceship? bestSpaceship = null;
        int lowestPrice = int.MaxValue;
        foreach (Spaceship ship in spaceships)
        {
            RouteReport report = route.GetRouteReport(ship);
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