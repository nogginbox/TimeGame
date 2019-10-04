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
            yield return new object[] { new LocalTime(1, 0), "1 o'clock" };
            yield return new object[] { new LocalTime(1, 5), "5 past 1" };
            yield return new object[] { new LocalTime(1, 55), "5 to 2" };
        }
    }
}
