using Garsonix.TimeGame.Models;
using System;

namespace Garsonix.TimeGame.Services
{
    public class LevelFactory
    {
        public Level Next(Level level)
        {
            var nextLevelDifficulty = level.Percentage > 70
                ? level.Difficulty + 1
                : level.Difficulty;
            return Create(nextLevelDifficulty);
        }

        public Level Create(int difficulty)
        {
            switch(difficulty)
            {
                case 1:
                    return new Level(difficulty, new[] { 0 });
                case 2:
                    return new Level(difficulty, new[] { 30 });
                case 3:
                    return new Level(difficulty, new[] { 0, 30 });
                case 4:
                    return new Level(difficulty, new[] { 15 });
                case 5:
                    return new Level(difficulty, new[] { 0, 15, 30 });
                case 6:
                    return new Level(difficulty, new[] { 45 });
                case 7:
                    return new Level(difficulty, new[] { 0, 15, 30, 45 });
                default:
                    throw new NotImplementedException("You've done too well");
            }

        }
    }
}