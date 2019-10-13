using Garsonix.TimeGame.Controls.Interfaces;
using System;
using Xamarin.Forms;

namespace Garsonix.TimeGame.Controls
{
    public class ClockAnswerButton : Clock, IAnswerButton
    {
        private static readonly Color DisabledColour = Color.FromRgba(20, 20, 20, 50);
        private static readonly Color WellDoneColour = Color.FromRgba(255, 255, 20, 50);

        private EventHandler _click;

        public event EventHandler Clicked
        {
            add
            {
                lock (this)
                {
                    _click += value;
                    var g = new TapGestureRecognizer();
                    g.Tapped += (s, e) => _click?.Invoke(s, e);
                    GestureRecognizers.Add(g);
                }
            }
            remove
            {
                lock (this)
                {
                    _click -= value;
                    GestureRecognizers.Clear();
                }
            }
        }

        public void SetAnswerIs(bool isRight)
        {
            IsEnabled = false;
            BackgroundColor = isRight
                ? WellDoneColour
                : DisabledColour;
        }

        public void Reset()
        {
            IsEnabled = true;
            BackgroundColor = Color.Transparent;
        }
    }
}