#pragma warning disable CA1303 // Do not pass literals as localized parameters
using System;
using Garsonix.TimeGame.Extensions;
using NodaTime;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace Garsonix.TimeGame.Controls.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorrectPopup : PopupPage
    {
        public CorrectPopup(LocalTime correctTime)
        {
            InitializeComponent();
            if(correctTime == null)
            {
                // Default message
                return;
            }

            Message.Text = $"Correct!! That clock does say {correctTime.ToWordyString()}";
        }

        private async void OnContinue(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync().ConfigureAwait(true);
        }
    }
}