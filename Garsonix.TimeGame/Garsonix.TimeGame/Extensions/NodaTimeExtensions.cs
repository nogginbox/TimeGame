using NodaTime;

namespace Garsonix.TimeGame.Extensions
{
    public static class NodaTimeExtensions
    {
        public static string ToWordyString(this LocalTime time)
        {
            

            switch(time.Minute)
            {
                case 0:
                    return $"{Hour(time)} o'clock";
                case 15:
                    return $"quarter {PlaceWord(time.Minute)} {Hour(time)}";
                case 30:
                    return $"Half past {Hour(time)}";
                default:
                    return $"{time.Minute} {PlaceWord(time.Minute)} {Hour(time)}";
            }

        }

        /// <summary>
        /// Are the minutes to or from the hour
        /// </summary>
        private static string PlaceWord(int minute)
        {
            return minute > 30
                ? "past"
                : "to";
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

    }
}