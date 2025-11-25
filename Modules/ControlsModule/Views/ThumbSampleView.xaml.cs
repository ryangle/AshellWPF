using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlSamples.Views
{
    /// <summary>
    /// ThumbSampleView.xaml 的交互逻辑
    /// </summary>
    public partial class ThumbSampleView : UserControl
    {
        public ThumbSampleView()
        {
            InitializeComponent();
            var thumb = new Thumb()
            {
                Cursor = Cursors.SizeAll,
                Template = new ControlTemplate(typeof(Thumb))
                {
                    VisualTree = GetFactoryMove()
                },
                Width = 100,
                Height = 100,
                Background = Brushes.Aqua
            };
            thumb.DragDelta += (sender, e) =>
            {
                //Debug.WriteLine($"DragDelta e.VerticalChange:{e.VerticalChange},e.HorizontalChange:{e.HorizontalChange} ");
                //Canvas.SetLeft(thumb, Canvas.GetLeft(thumb) + e.HorizontalChange);
                //Canvas.SetTop(thumb, Canvas.GetTop(thumb) + e.VerticalChange);

                //Move the Thumb to the mouse position during the drag operation
                double yadjust = canvas.Height + e.VerticalChange;
                double xadjust = canvas.Width + e.HorizontalChange;
                if ((xadjust >= 0) && (yadjust >= 0))
                {
                    //canvas.Width = xadjust;
                    //canvas.Height = yadjust;
                    Canvas.SetLeft(button, Canvas.GetLeft(button) +
                                            e.HorizontalChange);
                    Canvas.SetTop(button, Canvas.GetTop(button) +
                                            e.VerticalChange);
                    //changes.Text = "Size: " +
                    //                myCanvasStretch.Width.ToString() +
                    //                 ", " +
                    //                myCanvasStretch.Height.ToString();
                }
            };
            thumb.DragEnter += (sender, e) =>
            {
                Debug.WriteLine("DragEnter");
            };
            thumb.DragLeave += (sender, e) =>
            {
                Debug.WriteLine("DragLeave");
            };
            thumb.DragOver += (sender, e) =>
            {
                Debug.WriteLine("DragOver");
            };
            thumb.DragStarted += (sender, e) =>
            {
                Debug.WriteLine("DragStarted");
                canvas.Background = Brushes.Orange;
            };
            thumb.DragCompleted += (sender, e) =>
            {
                canvas.Background = Brushes.Blue;
                Debug.WriteLine($"DragCompleted canvas.Height:{canvas.ActualHeight},canvas.Width:{canvas.ActualWidth}");
            };
            button.Content = thumb;
        }
        private FrameworkElementFactory GetFactoryMove()
        {
            FrameworkElementFactory elementFactory = new(typeof(Rectangle));
            elementFactory.SetValue(Shape.FillProperty, Brushes.Beige);
            return elementFactory;
        }
    }
}
