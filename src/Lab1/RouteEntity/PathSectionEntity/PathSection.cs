using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.EnvironmentEntity;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.PathSectionEntity;

public class PathSection
{
    public PathSection(Environment environment, PathSectionDistance pathSectionDistance)
    {
        Environment = environment;
        Environment.Distance = pathSectionDistance;
    }

    public Environment Environment { get; }
}