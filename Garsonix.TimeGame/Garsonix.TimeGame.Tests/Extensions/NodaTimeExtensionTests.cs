using Garsonix.TimeGame.Extensions;
using NodaTime;
using System.Collections.Generic;
using Xunit;

namespace Garsonix.TimeGame.Tests.Extensions
{
    public class NodaTimeExtensionTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void ToWordyStringTests(LocalTime time, string expectedWordyString)
        {
            // Arrange / Act
            var wordy = time.ToWordyString();

            // Assert
            Assert.Equal(expectedWordyString, wordy);
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new LocalTime(0, 0), "12 o'clock" };
            yield return new object[] { new LocalTime(12, 0), "12 o'clock" };
            yield return new object[] { new LocalTime(1, 0), "1 o'clock" };
            yield return new object[] { new LocalTime(1, 5), "5 past 1" };
            yield return new object[] { new LocalTime(1, 55), "5 to 2" };
            yield return new object[] { new LocalTime(13, 30), "half past 1" };
            yield return new object[] { new LocalTime(12, 15), "quarter past 12" };
            yield return new object[] { new LocalTime(15, 45), "quarter to 4" };
            yield return new object[] { new LocalTime(14, 40), "20 to 3" };
            yield return new object[] { new LocalTime(3, 20), "20 past 3" };
        }
    }
}
