#pragma warning disable CA1303 // Do not pass literals as localized parameters
using System;
using System.Threading;
using Xamarin.Forms.Xaml;

namespace Garsonix.TimeGame.Controls.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LevelDonePopup : PopupBase
    {
        public LevelDonePopup(Models.Level<NodaTime.LocalTime> level, CancellationTokenSource canceller) : base(canceller)
        {
            InitializeComponent();
            if(level == null)
            {
                throw new NullReferenceException("Attempt to show LevelDonePopup for null level");
            }

            //Title = $"Level {_level.Difficulty}";
            Message.Text = $"You scored {level.Percentage}%";
        }
    }
}