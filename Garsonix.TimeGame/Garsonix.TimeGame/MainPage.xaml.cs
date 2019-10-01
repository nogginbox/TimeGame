using Garsonix.TimeGame.Controls;
using Garsonix.TimeGame.Extensions;
using Garsonix.TimeGame.Services;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Garsonix.TimeGame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly IReadOnlyList<Clock> _clocks;
        private readonly TimeFactory _timeFactory;
        private readonly Random _rnd = new Random();

        private LocalTime _theTime;

        public MainPage()
        {
            InitializeComponent();
            _timeFactory = new TimeFactory();
            _clocks = new List<Clock>
            {
                Clock1, Clock2, Clock3, Clock4
            };
            SetTimes();
        }

        private async void ClockClicked(object sender, EventArgs e)
        {
            if (!(sender is Clock clock))
            {
                throw new Exception($"{sender.GetType()} is not a Clock");
            }

            var isCorrect = clock.Time == _theTime;
            var msg = isCorrect
                ? "Well done"
                : "Try again";

            // Todo: Wrong answer: Tell them what time the clock says

            await DisplayAlert("The Time", msg, "Yes");

            if (isCorrect)
            {
                SetTimes();
            }
        }

        private void SetTimes()
        {
            foreach(var clock in _clocks)
            {
                clock.Time = _timeFactory.Random(new[] {0, 30 }, true);
            }
            _theTime = _clocks[_rnd.Next(0, 3)].Time;
            TimeQuestion.Text = $"Which clock says {_theTime.ToWordyString()}";
        }
    }
}
