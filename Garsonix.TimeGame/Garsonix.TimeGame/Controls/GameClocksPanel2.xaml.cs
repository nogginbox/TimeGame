using Garsonix.TimeGame.Controls.Events;
using Garsonix.TimeGame.Extensions;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garsonix.TimeGame.Controls
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameClocksPanel2 : ContentView, IGameClocksPanel
    {
        private readonly IReadOnlyList<Button> _timeButtons;

        public GameClocksPanel2()
        {
            InitializeComponent();
            _timeButtons = new List<Button>
            {
                Time1, Time2, Time3, Time4
            };
        }

        private EventHandler<TimeChosenEventArgs> _onTimeSelected;

        public View View => this;

        public event EventHandler<TimeChosenEventArgs> TimeClicked
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
                _timeButtons[i].CommandParameter = times[i];
                _timeButtons[i].Text = times[i].ToString("hh:mm", CultureInfo.InvariantCulture);
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

            var timeEventArgs = new TimeChosenEventArgs((LocalTime)time);

            _onTimeSelected?.Invoke(sender, timeEventArgs);
        }
    }

}