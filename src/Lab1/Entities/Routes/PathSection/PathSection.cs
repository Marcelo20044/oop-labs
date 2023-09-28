using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.PathSection;

public class PathSection
{
    public PathSection(BaseEnvironment environment)
    {
        Environment = environment;
    }

    public BaseEnvironment Environment { get; }
}