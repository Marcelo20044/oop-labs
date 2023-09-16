using Itmo.ObjectOrientedProgramming.Lab1.Route.EnvironmentEntity;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class PathSection
{
    private readonly Environment _environment;

    public PathSection(Environment environment, PathSectionDistance pathSectionDistance)
    {
        _environment = environment;
        _environment.Distance = pathSectionDistance;
    }
}