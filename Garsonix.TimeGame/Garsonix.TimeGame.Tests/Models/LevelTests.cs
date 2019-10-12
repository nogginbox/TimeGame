using Garsonix.TimeGame.Models;
using Xunit;

namespace Garsonix.TimeGame.Tests.Models
{
    public class LevelTests
    {
        [Fact]
        public void ScoreTest()
        {
            // arrange
            var level = new Level(1, null, new[] { 0 });

            // act
            level.RightAfter(3, 4);

            // assert
            Assert.Equal(2, level.Score);
            Assert.Equal(1, level.QuestionsAsked);
            Assert.Equal(50f, level.Percentage);
        }
    }
}
