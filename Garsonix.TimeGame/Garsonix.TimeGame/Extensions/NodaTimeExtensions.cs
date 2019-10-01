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
                    return $"{time.Hour} o'clock";
                case 15:
                    return $"quarter {placeWord(time.Minute)} {time.Hour}";
                case 30:
                    return $"Half past {time.Hour}";
                default:
                    return $"{time.Minute} {placeWord(time.Minute)} {time.Hour}";
            }

        }

        private static string placeWord(int minute)
        {
            return minute > 30
                ? "past"
                : "to";
        }
    }
}