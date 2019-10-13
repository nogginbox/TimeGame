using System;

namespace Garsonix.TimeGame.Controls.Interfaces
{
    internal interface IAnswerButton
    {
        event EventHandler Clicked;
        void Reset();
        void SetAnswerIs(bool isRight);
    }
}