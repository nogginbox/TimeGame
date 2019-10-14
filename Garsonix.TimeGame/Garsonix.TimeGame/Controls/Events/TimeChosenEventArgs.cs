using System;

namespace Garsonix.TimeGame.Controls.Events
{
    public class AnsweredEventArgs<T> : EventArgs
    {
        public readonly T Answer;

        public AnsweredEventArgs(T answer)
        {
            Answer = answer;
        }
    }
}