using System;
using System.Linq;
using System.Collections.Generic;

namespace Garsonix.TimeGame.Extensions
{
    public static class Helpers
    {
        public static IEnumerable<T> Generate<T>(this Func<T> generator, int count)
        {
            for (var i = 0; i < count; i ++)
            {
                yield return generator();
            }
        }

        public static IEnumerable<T> GenerateDistinct<T>(this Func<T> generator, int count)
        {
            var maxTryCount = (count + 5) * 20;
            var items = Generate(generator, maxTryCount).Distinct().Take(count);
            return items;
        }
    }
}