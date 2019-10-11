using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Garsonix.TimeGame.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameClocks1 : ContentView
    {
        private readonly IReadOnlyList<ClockButton> _clocks;

        public GameClocks1()
        {
            InitializeComponent();
            _clocks = new List<ClockButton>
            {
                Clock1, Clock2, Clock3, Clock4
            };
        }

        private EventHandler _onTimeSelected;

        public event EventHandler TimeClicked
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
                _clocks[i].Reset();
                _clocks[i].Time = times[i];
            }
        }

        public void SetQuestion(string question)
        {
            TimeQuestion.Text = question;
        }

        private void ClockClicked(object sender, EventArgs e)
        {
            if (!(sender is ClockButton clock))
            {
                throw new Exception($"{sender.GetType()} is not a Clock");
            }

            _onTimeSelected?.Invoke(sender, e);
        }
    }

}