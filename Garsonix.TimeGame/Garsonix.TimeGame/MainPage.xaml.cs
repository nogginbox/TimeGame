using Garsonix.TimeGame.Controls;
using Garsonix.TimeGame.Services;
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

            var a = clock.Time;
            await DisplayAlert("The Time", a.ToString(), "Yes");
        }

        private void SetTimes()
        {
            foreach(var clock in _clocks)
            {
                clock.Time = _timeFactory.Random();
            }
        }
    }
}
