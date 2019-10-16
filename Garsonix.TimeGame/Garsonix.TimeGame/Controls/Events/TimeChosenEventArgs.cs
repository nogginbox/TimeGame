using System;

namespace Garsonix.TimeGame.Controls.Events
{
    public class AnsweredEventArgs<T> : EventArgs
    {
        public T Answer { get; private set; }

        public AnsweredEventArgs(T answer)
        {
            Answer = answer;
        }
    }
}