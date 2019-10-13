using Garsonix.TimeGame.Controls.Events;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Garsonix.TimeGame.Controls.Interfaces
{
    public interface IGamePanel<T>
    {
        event EventHandler<AnsweredEventArgs<T>> AnswerClicked;

        void SetClockTimes(IList<T> times);

        void SetQuestionTime(T time);

        View View { get; }
    }
}