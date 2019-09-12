using SkiaSharp.Extended.Svg;
using SkiaSharp.Views.Forms;
using System;
using System.IO;
using Xamarin.Forms;

namespace Garsonix.TimeGame.Controls
{
    public class SvgImage : Frame
    {
        private readonly SKCanvasView _canvasView = new SKCanvasView();

        public SvgImage()
        {
            Padding = new Thickness(0);

            // Thanks to TheMax for pointing out that on mobile, the icon will have a shadow by default.
            // Also it has a white background, which we might not want.
            HasShadow = false;
            BackgroundColor = Color.Transparent;

            Content = _canvasView;
            _canvasView.PaintSurface += CanvasViewOnPaintSurface;
        }

        public static readonly BindableProperty IconFilePathProperty = BindableProperty.Create(
            nameof(ResourceId),
            typeof(string),
            typeof(SvgImage),
            default(string),
            propertyChanged: RedrawCanvas);

        public string ResourceId
        {
            get => (string)GetValue(IconFilePathProperty);
            set => SetValue(IconFilePathProperty, value);
        }

        private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
        {
            SvgImage svgIcon = bindable as SvgImage;
            svgIcon?._canvasView.InvalidateSurface();
        }

        private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            var canvas = args.Surface.Canvas;
            canvas.Clear();

            if (string.IsNullOrEmpty(ResourceId))
                return;

            using (Stream stream = GetType().Assembly.GetManifestResourceStream(ResourceId))
            {
                SKSvg svg = new SKSvg();
                svg.Load(stream);

                Scale(svg);

                canvas.DrawPicture(svg.Picture);
            }

            void Scale(SKSvg svg)
            {
                var info = args.Info;
                canvas.Translate(info.Width / 2f, info.Height / 2f);

                var bounds = svg.ViewBox;
                float xRatio = info.Width / bounds.Width;
                float yRatio = info.Height / bounds.Height;

                float ratio = Math.Min(xRatio, yRatio);

                canvas.Scale(ratio);
                canvas.Translate(-bounds.MidX, -bounds.MidY);
            }
        }
    }
}