#pragma warning disable CA1303 // Do not pass literals as localized parameters
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Garsonix.TimeGame.Controls.Popups
{
    public abstract class PopupBase : PopupPage
    {
        private readonly CancellationTokenSource _canceller;

        public PopupBase(CancellationTokenSource canceller)
        {
            _canceller = canceller;
            CloseWhenBackgroundIsClicked = false;
        }

        protected async void OnContinue(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync().ConfigureAwait(true);
            _canceller.Cancel();
        }
    }
}