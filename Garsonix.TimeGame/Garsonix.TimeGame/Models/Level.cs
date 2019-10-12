using Garsonix.TimeGame.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Garsonix.TimeGame.Models
{
    public class Level
    {
        public Level(int difficulty, IGameClocksPanel gamePanel, IEnumerable<int> possibleMinutes)
        {
            Difficulty = difficulty;
            GamePanel = gamePanel;
            PossibleMinutes = possibleMinutes.ToList();
        }

        public int Difficulty { get; }

        public bool IsComplete => QuestionsAsked >= 10;

        public float Percentage => _scorePossible > 0
            ? (Score / (float)_scorePossible) * 100f
            : 0;

        public IGameClocksPanel GamePanel { get; private set; }

        public IList<int> PossibleMinutes { get; }

        public int QuestionsAsked { get; private set; }

        public int Score { get; private set; }

        private int _scorePossible;

        public void RightAfter(int attemptCount, int possibleAnswerCount)
        {
            QuestionsAsked++;
            Score += (possibleAnswerCount + 1 - attemptCount);
            _scorePossible += possibleAnswerCount;
        }
    }
}
