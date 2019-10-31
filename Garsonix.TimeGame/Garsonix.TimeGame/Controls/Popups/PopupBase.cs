#pragma warning disable CA1303 // Do not pass literals as localized parameters
using Rg.Plugins.Popup.Pages;
using System;
using System.Threading;

namespace Garsonix.TimeGame.Controls.Popups
{
    public abstract class PopupBase : PopupPage
    {
        private readonly CancellationTokenSource _canceller;

        public PopupBase(CancellationTokenSource canceller)
        {
            _canceller = canceller;
        }

        protected async void OnContinue(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(true);
            _canceller.Cancel();
        }
    }
}