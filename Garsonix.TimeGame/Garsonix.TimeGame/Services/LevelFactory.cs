#pragma warning disable CA1303 // Do not pass literals as localized parameters
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
        private readonly Random _rand;

        public TimeLevelFactory(IList<IGamePanel<LocalTime>> gamePanels)
        {
            _gamePanels = gamePanels.ToList();
            _rand = new Random();
        }

        public Level<LocalTime> NextLevel(Level<LocalTime> level)
        {
            if(level == null)
            {
                throw new NullReferenceException("LevelFactory.Next needs a level to work out next level");
            }
            var nextLevelDifficulty = level.Percentage > 70
                ? level.Difficulty + 1
                : level.Difficulty;
            return CreateLevel(nextLevelDifficulty);
        }

        public Level<LocalTime> CreateLevel(int difficulty)
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
            // todo: don't return same game panel more than once for a difficulty level
            var rIndex = _rand.Next(2);
            return _gamePanels[rIndex];
        }
    }
}