#pragma warning disable CA1303 // Do not pass literals as localized parameters
using System;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace Garsonix.TimeGame.Controls.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LevelDonePopup : PopupPage
    {
        public LevelDonePopup(Models.Level<NodaTime.LocalTime> level)
        {
            InitializeComponent();
            if(level == null)
            {
                throw new NullReferenceException("Attempt to show LevelDonePopup for null level");
            }

            //Title = $"Level {_level.Difficulty}";
            Message.Text = $"You scored {level.Percentage}%";
        }

        private async void OnContinue(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync().ConfigureAwait(true);
        }
    }
}