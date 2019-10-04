using Garsonix.TimeGame.Services;
using NodaTime;
using System;
using System.Linq;
using Xunit;

namespace Garsonix.TimeGame.Tests
{
    public class TimeFactoryTests
    {
        [Fact]
        public void TestAllPossibleMinutesHappen()
        {
            // Arrange
            var factory = new TimeFactory();

            // Act
            var possibleMinutes = new[] { 0, 15 };
            var randomTimes = Enumerable.Range(0, 50).Select(i => factory.Random(possibleMinutes, true)).ToList();

            // Assert
            var count0 = randomTimes.Count(t => t.Minute == 0);
            var count15 = randomTimes.Count(t => t.Minute == 15);

            Assert.True(count0 > 0);
            Assert.True(count15 > 0);
            Assert.Equal(50, count0 + count15);
        }

        private void AssertOneIs(Func<LocalTime> timeGenerator, Func<LocalTime, bool> isTrue, int maxTries = 100)
        {
            for(var i=0; i < maxTries; i++)
            {
                var time = timeGenerator();
                Assert.False(isTrue(time));
            }
        }
    }
}
