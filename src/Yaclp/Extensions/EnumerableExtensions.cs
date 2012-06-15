using System;
using System.Collections.Generic;
using System.Linq;

namespace Yaclp.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool None<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.Any(predicate);
        }

        public static IEnumerable<T> DepthFirst<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> children)
        {
            foreach (var item in source)
            {
                yield return item;
                foreach (var descendant in children(item).DepthFirst(children)) yield return descendant;
            }
        }

        public static IEnumerable<T> Traverse<T>(this T item, Func<T, T> child) where T : class
        {
            if (item == null) yield break;
            yield return item;
            foreach (var descendant in child(item).Traverse(child)) yield return descendant;
        }
    }
}