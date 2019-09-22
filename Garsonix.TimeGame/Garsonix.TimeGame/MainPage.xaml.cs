using Garsonix.TimeGame.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Garsonix.TimeGame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
    }
}
