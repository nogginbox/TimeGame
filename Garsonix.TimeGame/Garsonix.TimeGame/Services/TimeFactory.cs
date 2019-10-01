using NodaTime;
using System;
using System.Collections.Generic;

namespace Garsonix.TimeGame.Services
{
    public class TimeFactory
    {
        private readonly Random _rnd;

        public TimeFactory()
        {
            _rnd = new Random();  
        }

        public LocalTime Random(IList<int> possibleMinutes, bool justMorning)
        {
            var maxHours = justMorning ? 11 : 23;
            var hour = _rnd.Next(0, maxHours);
            var mins = possibleMinutes.Count > 0
                ? possibleMinutes[_rnd.Next(0, possibleMinutes.Count - 1)]
                : 0;
            return new LocalTime(hour, mins);
        }
    }
}