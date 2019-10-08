using NodaTime;

namespace Garsonix.TimeGame.Extensions
{
    public static class NodaTimeExtensions
    {
        /// <summary>
        /// The English word description of the time
        /// </summary>
        public static string ToWordyString(this LocalTime time)
        {
            switch(time.Minute)
            {
                case 0:
                    return $"{Hour(time)} o'clock";
                case 15:
                case 45:
                    return $"quarter {PlaceWord(time.Minute)} {Hour(time)}";
                case 30:
                    return $"half past {Hour(time)}";
                default:
                    return $"{Minute(time)} {PlaceWord(time.Minute)} {Hour(time)}";
            }

        }

        /// <summary>
        /// Are the minutes 'to' or 'from' the hour
        /// </summary>
        private static string PlaceWord(int minute)
        {
            return minute > 30
                ? "to"
                : "past";
        }

        private static int Hour(LocalTime time)
        {
            var hour = time.Minute > 30
                ? time.Hour + 1
                : time.Hour;
            hour = hour % 12;
            hour = hour != 0
                ? hour
                : 12;
            return hour;
        }

        /// <summary>
        /// The number of minutes (0-30) to or from the hour
        /// </summary>
        private static int Minute(LocalTime time)
        {
            return time.Minute > 30
                ? 60 - time.Minute
                : time.Minute;
        }
    }
}