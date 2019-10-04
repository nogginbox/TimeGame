using Garsonix.TimeGame.Controls;
using Garsonix.TimeGame.Extensions;
using Garsonix.TimeGame.Models;
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
        private readonly LevelFactory _levelFactory;
        private readonly TimeFactory _timeFactory;
        private readonly Random _rnd = new Random();

        private LocalTime _theTime;
        private Level _level;
        private int _tries = 0;

        public MainPage()
        {
            InitializeComponent();

            _levelFactory = new LevelFactory();
            _timeFactory = new TimeFactory();
            _level = _levelFactory.Create(1);
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

            _tries++;

            var isCorrect = clock.Time == _theTime;
            clock.SetAnswerIs(isCorrect);

            var msg = isCorrect
                ? (text: "Well done", button: "Next")
                : (text: $"No. That clock says {clock.Time.ToWordyString()}", button: "Try again");
            await DisplayAlert("The Time", msg.text, msg.button);

            if (isCorrect)
            {
                SetTimes();
                _level.RightAfter(_tries, 4);
                if(_level.IsComplete)
                {
                    // Todo:
                    // * Show different screen with stars for level on
                    // * Keep levels completed
                    _level = _levelFactory.Next(_level);
                }
                _tries = 0;
            }
        }

        private void SetTimes()
        {
            foreach(var clock in _clocks)
            {
                clock.Time = _timeFactory.Random(_level.PossibleMinutes, true);
                clock.Reset();
            }
            _theTime = _clocks[_rnd.Next(0, 3)].Time;
            TimeQuestion.Text = $"Which clock says {_theTime.ToWordyString()}";
        }
    }
}