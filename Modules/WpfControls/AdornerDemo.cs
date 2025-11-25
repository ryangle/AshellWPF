using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfControls
{
    public class AdornerDemo : Adorner
    {
        public AdornerDemo(UIElement adornedElement) : base(adornedElement) { }
        protected override void OnRender(DrawingContext drawingContext)
        {

            FormattedText t = new(
                "!!!!!",
                CultureInfo.InstalledUICulture,
                FlowDirection.LeftToRight,
                new Typeface("微软雅黑"),
                15,
                new SolidColorBrush(Colors.Red),
                VisualTreeHelper.GetDpi(this).PixelsPerDip
            );
            drawingContext.DrawText(t, new Point(270, 0));

            base.OnRender(drawingContext);
        }
        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    // 绘制虚线矩形。注意右下角的矩形并不是由OnRender绘制的，而是由 
        //    // AddVisualChild()添加的
        //    SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
        //    Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1);
        //    renderPen.DashStyle = new DashStyle(new double[] { 2.5, 2.5 }, 0);
        //    Rect rect = new Rect(0, 0, _adornedElement.ActualWidth, _adornedElement.ActualHeight);
        //    drawingContext.DrawRectangle(Brushes.Transparent, renderPen, rect);
        //    base.OnRender(drawingContext);
        //}
        //private void CreateGrip()
        //{
        //    // Scaling grip
        //    Rectangle rect = new Rectangle();
        //    rect.Stroke = Brushes.Blue;
        //    rect.Fill = Brushes.White;
        //    rect.Cursor = Cursors.SizeNWSE;
        //    rect.MouseDown += OnGripMouseDown;
        //    rect.MouseUp += OnGripMouseUp;
        //    rect.MouseMove += OnGripMouseMove;
        //    // 添加子元素，从而允许基类的OnRender()函数绘制该界面元素。
        //    // 同时需要重写VisualChildrenCount属性及GetVisualChild()函数
        //    AddVisualChild(rect);
        //    _scalingGrip = rect;
        //}
    }
}
