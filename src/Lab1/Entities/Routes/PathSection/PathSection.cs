using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Distance;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.PathSection;

public class PathSection
{
    public PathSection(BaseEnvironment baseEnvironment, PathSectionDistance pathSectionDistance)
    {
        BaseEnvironment = baseEnvironment;
        BaseEnvironment.Distance = pathSectionDistance;
    }

    public BaseEnvironment BaseEnvironment { get; }
}