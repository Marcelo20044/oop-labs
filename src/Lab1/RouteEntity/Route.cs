using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteEntity;

public class Route
{
    public Route(IEnumerable<PathSection> pathSections)
    {
        PathSections = pathSections;
    }

    public IEnumerable<PathSection> PathSections { get; }

    public RouteReport GetRouteReport(Spaceship spaceship)
    {
        int generalTravelTime = 0;
        int generalFuelSpent = 0;

        foreach (PathSection pathSection in PathSections)
        {
            RouteReport report = pathSection.Environment.TryGetThrough(spaceship);
            if (report.Result != RouteResult.Success)
            {
                return report;
            }

            generalTravelTime += report.TravelTime;
            generalFuelSpent += report.SpentFuel;
        }

        return new RouteReport(RouteResult.Success, generalTravelTime, generalFuelSpent);
    }
}