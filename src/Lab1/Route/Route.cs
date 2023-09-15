using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class Route
{
    public Route(IEnumerable<PathSection> pathSections)
    {
        PathSections = pathSections;
    }

    public IEnumerable<PathSection> PathSections { get; }
}