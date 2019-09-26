using System;
using NodaTime;

namespace Garsonix.TimeGame.Services
{
    public class TimeFactory
    {
        public LocalTime Random()
        {
            return new LocalTime(DateTime.Now.Hour, DateTime.Now.Minute);
        }
    }
}
