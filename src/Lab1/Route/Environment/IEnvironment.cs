namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Environment;

public interface IEnvironment
{
    public RouteResult TryGetThrough(Spaceship.Spaceship? spaceship);
}