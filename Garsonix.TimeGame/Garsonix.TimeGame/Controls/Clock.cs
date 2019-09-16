using NodaTime;
using Xamarin.Forms;

namespace Garsonix.TimeGame.Controls
{
    public class Clock : Grid
    {
        private readonly SvgImage _clockHandHour;
        private readonly SvgImage _clockHandMinute;

        public Clock()
        {
            var clockFace = new SvgImage("Garsonix.TimeGame.Content.Images.clock.svg");
            Children.Add(clockFace);

            _clockHandHour = new SvgImage("Garsonix.TimeGame.Content.Images.clock_little_hand.svg");
            Children.Add(_clockHandHour);

            _clockHandMinute = new SvgImage("Garsonix.TimeGame.Content.Images.clock_big_hand.svg");
            Children.Add(_clockHandMinute);

            Time = new LocalTime(3, 30);
        }

        public LocalTime Time {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                _clockHandHour.Rotation = _time.Hour / 12.0 * 360.0;
                _clockHandMinute.Rotation = _time.Minute / 60.0 *360.0;
            }
        }

        private LocalTime _time;
    }
}