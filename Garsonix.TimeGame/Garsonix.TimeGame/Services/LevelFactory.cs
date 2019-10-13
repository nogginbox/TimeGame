using Garsonix.TimeGame.Controls.Interfaces;
using Garsonix.TimeGame.Models;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garsonix.TimeGame.Services
{
    public class TimeLevelFactory : ILevelFactory<LocalTime>
    {
        private readonly IReadOnlyList<IGamePanel<LocalTime>> _gamePanels;

        public TimeLevelFactory(IList<IGamePanel<LocalTime>> gamePanels)
        {
            _gamePanels = gamePanels.ToList();
        }

        public Level<LocalTime> Next(Level<LocalTime> level)
        {
            var nextLevelDifficulty = level.Percentage > 70
                ? level.Difficulty + 1
                : level.Difficulty;
            return Create(nextLevelDifficulty);
        }

        public Level<LocalTime> Create(int difficulty)
        {
            var gamePanel = GetGamePanel(difficulty);
            switch(difficulty)
            {
                case 1:
                    return new Level<LocalTime>(difficulty, gamePanel, new[] { 0 });
                case 2:
                    return new Level<LocalTime>(difficulty, gamePanel, new[] { 30 });
                case 3:
                    return new Level<LocalTime>(difficulty, gamePanel, new[] { 0, 30 });
                case 4:
                    return new Level<LocalTime>(difficulty, gamePanel, new[] { 15 });
                case 5:
                    return new Level<LocalTime>(difficulty, gamePanel, new[] { 0, 15, 30 });
                case 6:
                    return new Level<LocalTime>(difficulty, gamePanel, new[] { 45 });
                case 7:
                    return new Level<LocalTime>(difficulty, gamePanel, new[] { 0, 15, 30, 45 });
                default:
                    throw new NotImplementedException("You've done too well");
            }

        }

        private IGamePanel<LocalTime> GetGamePanel(int difficulty)
        {
            return _gamePanels[0];
        }
    }
}