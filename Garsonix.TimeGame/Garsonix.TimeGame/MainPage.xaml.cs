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
        private readonly IReadOnlyList<ClockButton> _clocks;
        private readonly TimeFactory _timeFactory;
        private readonly Random _rnd = new Random();

        private LocalTime _theTime;

        public MainPage()
        {
            InitializeComponent();
            _timeFactory = new TimeFactory();
            _clocks = new List<ClockButton>
            {
                Clock1, Clock2, Clock3, Clock4
            };
            SetTimes();
        }

        private async void ClockClicked(object sender, EventArgs e)
        {
            if (!(sender is ClockButton clock))
            {
                throw new Exception($"{sender.GetType()} is not a Clock");
            }

            var isCorrect = clock.Time == _theTime;
            clock.SetAnswerIs(isCorrect);

            var msg = isCorrect
                ? (text: "Well done", button: "Next")
                : (text: $"No. That clock says {clock.Time.ToWordyString()}", button: "Try again");
            await DisplayAlert("The Time", msg.text, msg.button);

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
                clock.Reset();
            }
            _theTime = _clocks[_rnd.Next(0, 3)].Time;
            TimeQuestion.Text = $"Which clock says {_theTime.ToWordyString()}";
        }
    }
}