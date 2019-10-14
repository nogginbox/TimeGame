using System;
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
    }
}