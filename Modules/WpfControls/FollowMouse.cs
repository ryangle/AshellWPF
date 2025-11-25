using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfControls
{
    /// <summary>
    /// 跟随鼠标移动的椭圆
    /// </summary>
    public class FollowMouse : FrameworkElement
    {
        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register(nameof(BackgroundColor), typeof(Color), typeof(FollowMouse),
                new FrameworkPropertyMetadata(Colors.Yellow, FrameworkPropertyMetadataOptions.AffectsRender));
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.InvalidateVisual();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            this.InvalidateVisual();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Rect bounds = new Rect(0, 0, base.ActualWidth, base.ActualHeight);
            drawingContext.DrawRectangle(GetForegroundBrush(), null, bounds);
            //drawingContext.DrawEllipse(GetForegroundBrush(), null, bounds);

        }

        private Brush GetForegroundBrush()
        {
            if (IsMouseOver)
            {
                RadialGradientBrush brush = new RadialGradientBrush(Color.FromRgb(0xE0, 0xE0, 0xE0), Color.FromRgb(0x7D, 0x7D, 0xFF));
                //brush.RelativeTransform = new RotateTransform(90, 0.5, 0.5);
                brush.RadiusX = 0.1;
                brush.RadiusY = 0.1;
                Point absoluteGradientOrigin = Mouse.GetPosition(this);
                Point relativeGradientOrigin = new Point(absoluteGradientOrigin.X / base.ActualWidth, absoluteGradientOrigin.Y / base.ActualHeight);
                brush.GradientOrigin = relativeGradientOrigin;
                brush.Center = relativeGradientOrigin;
                return brush;
            }
            else
            {
                return new SolidColorBrush(Color.FromRgb(0x7D, 0x7D, 0xFF));
            }
        }

    }
}
