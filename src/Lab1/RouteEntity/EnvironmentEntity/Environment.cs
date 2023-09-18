using System;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.PathSectionEntity;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Organizations;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.EnvironmentEntity;

public abstract class Environment
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

    public abstract RouteReport TryGetThrough(Spaceship? spaceship, ExchangeRate exchangeRate);
}