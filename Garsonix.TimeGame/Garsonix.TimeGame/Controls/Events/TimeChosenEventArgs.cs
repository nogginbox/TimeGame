using NodaTime;
using System;

namespace Garsonix.TimeGame.Controls.Events
{
    public class TimeChosenEventArgs : EventArgs
    {
        public readonly LocalTime Time;

        public TimeChosenEventArgs(LocalTime time)
        {
            Time = time;
        }
    }
}