using Garsonix.TimeGame.Controls;
using Garsonix.TimeGame.Extensions;
using Garsonix.TimeGame.Models;
using Garsonix.TimeGame.Services;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Garsonix.TimeGame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
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
                _level.RightAfter(_tries, 4);
                if(_level.IsComplete)
                {
                    // Show level score
                    // Todo:
                    // * Show nicer overlay screen with stars for level on
                    await DisplayAlert($"Level {_level.Difficulty}", $"You scored {_level.Percentage}%", "Continue");

                    // Increase level
                    // Todo:
                    _level = _levelFactory.Next(_level);
                }
                
                // Start next level
                SetTimes();
                _tries = 0;
            }
        }

        private void SetTimes()
        {
            var times = Helpers.Generate(() => _timeFactory.Random(_level.PossibleMinutes, true), 4).ToList();
            GameClocks.SetClockTimes(times);
            _theTime = times[_rnd.Next(0, 3)];
            GameClocks.SetQuestion($"Which clock says {_theTime.ToWordyString()}");
        }
    }
}