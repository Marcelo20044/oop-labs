using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Extensions;

public static class CollectionExtensions
{
    public static void ForEach<T>(this IReadOnlyCollection<T> collection, Action<T> action)
    {
        if (collection is null) throw new ArgumentNullException(nameof(collection));
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (T item in collection)
        {
            action(item);
        }
    }
}