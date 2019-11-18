#pragma warning disable CA1303 // Do not pass literals as localized parameters
using Garsonix.TimeGame.Extensions;
using NodaTime;
using System.Threading;
using Xamarin.Forms.Xaml;

namespace Garsonix.TimeGame.Controls.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WrongPopup : PopupBase
    {

        public WrongPopup(LocalTime wrongTime, CancellationTokenSource canceller) : base(canceller)
        {
            InitializeComponent();
            if(wrongTime == null)
            {
                // Show default message
                return;
            }

            Message.Text = $"No. That clock says {wrongTime.ToWordyString()}";
        }
    }
}