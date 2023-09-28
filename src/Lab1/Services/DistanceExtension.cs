using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Distance;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class DistanceExtension
{
    public static double GetDistance(this Distance distance)
    {
        return distance switch
        {
            Distance.Small => 20,
            Distance.Medium => 40,
            Distance.Big => 60,
            _ => throw new ArgumentOutOfRangeException(nameof(distance), distance, null),
        };
    }
}