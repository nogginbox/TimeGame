using Garsonix.TimeGame.Controls.Events;
using Garsonix.TimeGame.Controls.Interfaces;
using Garsonix.TimeGame.Extensions;
using NodaTime;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garsonix.TimeGame.Controls
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameClocksPanel1 : ContentView, IGamePanel<LocalTime>
    {
        private readonly IReadOnlyList<ClockAnswerButton> _answerButtons;

        public GameClocksPanel1()
        {
            InitializeComponent();
            _answerButtons = new List<ClockAnswerButton>
            {
                Clock1, Clock2, Clock3, Clock4
            };
        }

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
        private EventHandler<AnsweredEventArgs<LocalTime>> _onTimeSelected;

        public void SetClockTimes(IList<LocalTime> times)
        {
            if(times?.Count != 4)
            {
                throw new ArgumentException($"This method required an array of 4 times (I have {times?.Count ?? 0}, this is not good enough.)");
            }

            for (var i = 0; i < 4; i++)
            {
                _answerButtons[i].Reset();
                _answerButtons[i].Time = times[i];
            }
        }


        public void SetQuestionTime(LocalTime time)
        {
            TimeQuestion.Text = $"Which clock says {time.ToWordyString()}";
        }

        private void ClockClicked(object sender, EventArgs e)
        {
            if (!(sender is ClockAnswerButton clock))
            {
                throw new Exception($"{sender.GetType()} is not a Clock");
            }

            var timeEventArgs = new AnsweredEventArgs<LocalTime>(clock.Time);

            _onTimeSelected?.Invoke(sender, timeEventArgs);
        }
    }

}