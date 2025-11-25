using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WpfControls
{
    public class DrawingVisualHost : UIElement
    {
        private readonly VisualCollection _children;

        public DrawingVisualHost()
        {
            _children = new VisualCollection(this)
            {
                CreateRectangle()
            };

            // Add the event handler for MouseLeftButtonUp.
            //MouseLeftButtonUp += MyVisualHost_MouseLeftButtonUp;
        }
        //override 
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawLine(new Pen(Brushes.Red, 2), new Point(10, 10), new Point(310, 10));
            //base.OnRender(drawingContext);
        }
        protected override int VisualChildrenCount => _children.Count;

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _children[index];
        }
        /// <summary>
        /// 画一个把所有点都包含的矩形
        /// </summary>
        /// <returns></returns>
        private DrawingVisual CreateRectangle()
        {
            List<Point> pointList = new List<Point> { new Point(40, 50), new Point(42, 54), new Point(45, 64), new Point(48, 50), new Point(60, 50), new Point(100, 50), new Point(210, 150) };
            DrawingVisual drawingVisual = new DrawingVisual();

            using DrawingContext dc = drawingVisual.RenderOpen();

            var rect = new Rect(pointList[0], new Size(0, 0));

            for (var i = 1; i < pointList.Count; i++)
            {
                rect.Union(pointList[i]);
                dc.DrawEllipse(Brushes.Red, null, pointList[i], 1, 1);
            }

            dc.DrawRectangle(Brushes.LightBlue, null, rect);
            return drawingVisual;
        }
        private DrawingVisual CreatePolygon()
        {
            List<Point> pointList = new List<Point> { new Point(40, 50), new Point(42, 54), new Point(45, 64), new Point(48, 50), new Point(60, 50), new Point(100, 50), new Point(210, 150) };
            DrawingVisual drawingVisual = new DrawingVisual();

            using DrawingContext dc = drawingVisual.RenderOpen();
            var polygon = new Polygon()
            {
                Points = new PointCollection(pointList),
                Stroke = Brushes.Red,
            };
            return drawingVisual;
        }
        // Capture the mouse event and hit test the coordinate point value against
        // the child visual objects.
        private void MyVisualHost_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Retrieve the coordinates of the mouse button event.
            Point pt = e.GetPosition((UIElement)sender);

            // Initiate the hit test by setting up a hit test result callback method.
            VisualTreeHelper.HitTest(this, null, MyCallback, new PointHitTestParameters(pt));
        }

        // If a child visual object is hit, toggle its opacity to visually indicate a hit.
        public HitTestResultBehavior MyCallback(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(System.Windows.Media.DrawingVisual))
            {
                double targetOpacity = 1.0;
                double epsilon = 0.0001; // Define a small tolerance
                double opacity = ((System.Windows.Media.DrawingVisual)result.VisualHit).Opacity;

                ((System.Windows.Media.DrawingVisual)result.VisualHit).Opacity =
                    Math.Abs(opacity - targetOpacity) < epsilon ? 0.4 : 1.0;
            }

            // Stop the hit test enumeration of objects in the visual tree.
            return HitTestResultBehavior.Stop;
        }

        // Create a DrawingVisual that contains a rectangle.
        private System.Windows.Media.DrawingVisual CreateDrawingVisualRectangle()
        {
            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();

            // Retrieve the DrawingContext in order to create new drawing content.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            // Create a rectangle and draw it in the DrawingContext.
            Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
            drawingContext.DrawRectangle(Brushes.LightBlue, null, rect);

            // Persist the drawing content.
            drawingContext.Close();

            return drawingVisual;
        }

        // Create a DrawingVisual that contains text.
        private System.Windows.Media.DrawingVisual CreateDrawingVisualText()
        {
            // Create an instance of a DrawingVisual.
            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();

            // Retrieve the DrawingContext from the DrawingVisual.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

#pragma warning disable CS0618 // 'FormattedText.FormattedText(string, CultureInfo, FlowDirection, Typeface, double, Brush)' is obsolete: 'Use the PixelsPerDip override'
            // Draw a formatted text string into the DrawingContext.
            drawingContext.DrawText(
                new FormattedText("Click Me!",
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface("Verdana"),
                    36, Brushes.Black),
                new Point(200, 116));
#pragma warning restore CS0618 // 'FormattedText.FormattedText(string, CultureInfo, FlowDirection, Typeface, double, Brush)' is obsolete: 'Use the PixelsPerDip override'

            // Close the DrawingContext to persist changes to the DrawingVisual.
            drawingContext.Close();

            return drawingVisual;
        }

        // Create a DrawingVisual that contains an ellipse.
        private System.Windows.Media.DrawingVisual CreateDrawingVisualEllipses()
        {
            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            drawingContext.DrawEllipse(Brushes.Maroon, null, new Point(430, 136), 20, 20);
            drawingContext.Close();

            return drawingVisual;
        }


    }
}
