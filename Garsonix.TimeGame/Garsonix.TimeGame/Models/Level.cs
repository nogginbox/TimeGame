using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garsonix.TimeGame.Models
{
    public class Level
    {
        public Level(int difficulty, IEnumerable<int> possibleMinutes)
        {
            Difficulty = difficulty;
            PossibleMinutes = possibleMinutes.ToList();
        }

        public int Difficulty { get; }

        public bool IsComplete => QuestionsAsked >= 10;

        public float Percentage => Score / (float)_scorePossible;

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
