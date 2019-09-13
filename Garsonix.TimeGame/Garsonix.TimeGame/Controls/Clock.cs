using Xamarin.Forms;

namespace Garsonix.TimeGame.Controls
{
    public class Clock : Frame
    {
        private readonly SvgImage _clockSvg;

        public Clock()
        {
            _clockSvg = new SvgImage
            {
                ResourceId = "Garsonix.TimeGame.Content.Images.clock.svg"
            };
            Content = _clockSvg;
        }
    }
}