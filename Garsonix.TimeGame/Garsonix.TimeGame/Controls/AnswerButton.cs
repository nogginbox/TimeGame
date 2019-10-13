using Garsonix.TimeGame.Controls.Interfaces;
using Xamarin.Forms;

namespace Garsonix.TimeGame.Controls
{
    public class AnswerButton : Button, IAnswerButton
    {
        private static readonly Color DisabledColour = Color.FromRgba(20, 20, 20, 50);
        private static readonly Color WellDoneColour = Color.FromRgba(255, 255, 20, 50);

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