using Garsonix.TimeGame.Controls;
using Garsonix.TimeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garsonix.TimeGame.Services
{
    public class LevelFactory
    {
        private readonly IReadOnlyList<IGameClocksPanel> _gamePanels;

        public LevelFactory(IList<IGameClocksPanel> gamePanels)
        {
            _gamePanels = gamePanels.ToList();
        }

        public Level Next(Level level)
        {
            var nextLevelDifficulty = level.Percentage > 70
                ? level.Difficulty + 1
                : level.Difficulty;
            return Create(nextLevelDifficulty);
        }

        public Level Create(int difficulty)
        {
            var gamePanel = GetGamePanel(difficulty);
            switch(difficulty)
            {
                case 1:
                    return new Level(difficulty, gamePanel, new[] { 0 });
                case 2:
                    return new Level(difficulty, gamePanel, new[] { 30 });
                case 3:
                    return new Level(difficulty, gamePanel, new[] { 0, 30 });
                case 4:
                    return new Level(difficulty, gamePanel, new[] { 15 });
                case 5:
                    return new Level(difficulty, gamePanel, new[] { 0, 15, 30 });
                case 6:
                    return new Level(difficulty, gamePanel, new[] { 45 });
                case 7:
                    return new Level(difficulty, gamePanel, new[] { 0, 15, 30, 45 });
                default:
                    throw new NotImplementedException("You've done too well");
            }

        }

        private IGameClocksPanel GetGamePanel(int difficulty)
        {
            return _gamePanels[0];
        }
    }
}