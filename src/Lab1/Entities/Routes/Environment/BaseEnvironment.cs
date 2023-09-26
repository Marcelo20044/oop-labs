using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Distance;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment;

public abstract class BaseEnvironment
{
    private PathSectionDistance _distance;

    public PathSectionDistance Distance
    {
        get => _distance;

        set
        {
            if (value == PathSectionDistance.None)
            {
                throw new ArgumentException("The distance of path section can't be None");
            }

            _distance = value;
        }
    }

    public abstract RouteReport TryGetThrough(BaseSpaceship? spaceship, ExchangeRate exchangeRate);
}