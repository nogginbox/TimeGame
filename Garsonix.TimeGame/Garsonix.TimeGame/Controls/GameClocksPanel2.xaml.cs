#pragma warning disable CA1303 // Do not pass literals as localized parameters
using Garsonix.TimeGame.Controls.Events;
using Garsonix.TimeGame.Controls.Interfaces;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garsonix.TimeGame.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameClocksPanel2 : ContentView, IGamePanel<LocalTime>
    {
        private readonly IReadOnlyList<AnswerButton> _answerButtons;

        public GameClocksPanel2()
        {
            InitializeComponent();
            _answerButtons = new List<AnswerButton>
            {
                Time1, Time2, Time3, Time4
            };
        }

        private EventHandler<AnsweredEventArgs<LocalTime>> _onTimeSelected;

        public View View => this;

        public event EventHandler<AnsweredEventArgs<LocalTime>> AnswerClicked
        {
            add
            {
                _onTimeSelected = value;
            }
            remove
            {
                _onTimeSelected = null;
            }
        }

        public void SetClockTimes(IList<LocalTime> times)
        {
            if(times?.Count != 4)
            {
                throw new ArgumentException($"This method required an array of 4 times (I have {times?.Count ?? 0}, this is not good enough.)");
            }

            for (var i = 0; i < 4; i++)
            {
                _answerButtons[i].Reset();
                _answerButtons[i].CommandParameter = times[i];
                _answerButtons[i].Text = times[i].ToString("hh:mm", CultureInfo.InvariantCulture);
            }
        }


        public void SetQuestionTime(LocalTime time)
        {
            Clock.Time = time;
        }

        private void ClockClicked(object sender, EventArgs e)
        {
            if (!(sender is Button clock))
            {
                throw new Exception($"{sender.GetType()} is not a Button");
            }

            var time = clock.CommandParameter as LocalTime?;
            if(time == null)
            {
                throw new ArgumentException("Clicked thing did not have a time");
            }

            var timeEventArgs = new AnsweredEventArgs<LocalTime>((LocalTime)time);

            _onTimeSelected?.Invoke(sender, timeEventArgs);
        }
    }

}