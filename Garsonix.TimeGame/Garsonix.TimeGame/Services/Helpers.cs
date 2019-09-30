using System;
using System.Collections.Generic;

namespace Garsonix.TimeGame.Services
{
    public static class Helpers
    {
        public static IEnumerable<T> Generate<T>(Func<T> generator, int count)
        {
            for (var i = 0; i < count; i ++)
            {
                yield return generator();
            }
        }
    }
}