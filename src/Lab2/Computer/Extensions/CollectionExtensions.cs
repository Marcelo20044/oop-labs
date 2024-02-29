using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;

public static class CollectionExtensions
{
    public static void ForEach<T>(this IReadOnlyCollection<T> collection, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(action);

        foreach (T item in collection)
        {
            action(item);
        }
    }
}