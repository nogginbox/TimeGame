using Garsonix.TimeGame.Controls;
using Garsonix.TimeGame.Controls.Events;
using Garsonix.TimeGame.Controls.Interfaces;
using Garsonix.TimeGame.Extensions;
using Garsonix.TimeGame.Models;
using Garsonix.TimeGame.Services;
using NodaTime;
using Rg.Plugins.Popup.Services;
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
        private readonly ILevelFactory<LocalTime> _levelFactory;
        private readonly TimeFactory _timeFactory;
        private readonly Random _rnd = new Random();

        private LocalTime _theTime;
        private Level<LocalTime> _level;
        private int _tries = 0;

        public MainPage()
        {
            InitializeComponent();
            var panels = SetupGamePanels();
            _levelFactory = new TimeLevelFactory(panels);
            _timeFactory = new TimeFactory();
            _level = _levelFactory.CreateLevel(1);

            SetTimes(_level);
        }

        private List<IGamePanel<LocalTime>> SetupGamePanels()
        {
            var gamePanels = new List<IGamePanel<LocalTime>>
            {
                new GameClocksPanel1(),
                new GameClocksPanel2()
            };
            // Hook up events
            foreach(var panel in gamePanels)
            {
                panel.AnswerClicked += ClockClicked;
            }
            return gamePanels;
        }

        private async void ClockClicked(object sender, AnsweredEventArgs<LocalTime> e)
        {
            _tries++;

            var isCorrect = e.Answer == _theTime;
            var answerButton = sender as IAnswerButton;
            answerButton.SetAnswerIs(isCorrect);

            var msg = isCorrect
                ? (text: "Well done", button: "Next")
                : (text: $"No. That clock says {e.Answer.ToWordyString()}", button: "Try again");


            await DisplayAlert("The Time", msg.text, msg.button).ConfigureAwait(true);

            if (isCorrect)
            {
                _level.RightAfter(_tries, 4);
                if(_level.IsComplete)
                {
                    // Show level score
                    var popup = new LevelDonePopup(_level);
                    await PopupNavigation.Instance.PushAsync(popup).ConfigureAwait(true);

                    // Increase level
                    // Todo:
                    _level = _levelFactory.NextLevel(_level);
                }
                
                // Start next level
                SetTimes(_level);
                _tries = 0;
            }
        }

        private void SetTimes(Level<LocalTime> level)
        {
            var times = Helpers.GenerateDistinct(() => _timeFactory.Random(_level.PossibleMinutes, true), 4).ToList();
            level.GamePanel.SetClockTimes(times);
            _theTime = times[_rnd.Next(0, 3)];
            level.GamePanel.SetQuestionTime(_theTime);
            GameClockPanel.Content = _level.GamePanel.View;
        }
    }
}