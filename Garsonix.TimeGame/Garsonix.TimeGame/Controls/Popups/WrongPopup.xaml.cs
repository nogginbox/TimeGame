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
    public partial class WrongPopup : PopupPage
    {
        public WrongPopup(LocalTime wrongTime)
        {
            InitializeComponent();
            if(wrongTime == null)
            {
                // Show default message
                return;
            }

            Message.Text = $"No. That clock says {wrongTime.ToWordyString()}";
        }

        private async void OnContinue(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync().ConfigureAwait(true);
        }
    }
}