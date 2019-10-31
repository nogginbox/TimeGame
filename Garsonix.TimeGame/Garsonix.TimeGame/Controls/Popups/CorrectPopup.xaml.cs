#pragma warning disable CA1303 // Do not pass literals as localized parameters
using Garsonix.TimeGame.Extensions;
using NodaTime;
using System.Threading;
using Xamarin.Forms.Xaml;

namespace Garsonix.TimeGame.Controls.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorrectPopup : PopupBase
    {
        public CorrectPopup(LocalTime correctTime, CancellationTokenSource canceller) : base(canceller)
        {
            InitializeComponent();
            if(correctTime == null)
            {
                // Default message
                return;
            }

            Message.Text = $"Correct!! That clock does say {correctTime.ToWordyString()}";
        }
    }
}