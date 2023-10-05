using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment;

public abstract class BaseEnvironment
{
    protected BaseEnvironment(double distance)
    {
        Distance = distance;
    }

    protected double Distance { get; }

    public abstract bool TryGetThrough(ISpaceship spaceship, ExchangeRate exchangeRate, out RouteReport report);
}