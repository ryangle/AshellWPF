using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfControls
{
    public class CurveChartDrawingVisual : FrameworkElement
    {
        private DrawingVisual visual = new DrawingVisual();
        private readonly VisualCollection _children;
        public CurveChartDrawingVisual()
        {
            //Visibility = Visibility.Visible;
            _children = new VisualCollection(this)
            {
                visual,
                //CreateDrawingVisualRectangle(),
            };
            //_children.Add();
        }
        private int count = 0;
        public void UpdateData(List<int> points)
        {
            count++;
            Random rnd = new Random();
            //this.Dispatcher.Invoke(() =>
            //{
            using (var dc = visual.RenderOpen())
            {
                Pen pen = new Pen(Brushes.Green, 2);
                ////for (int i = 0; i < points.Count - 1; i++)
                ////{
                ////    dc.DrawLine(pen, new Point(i, points[i]), new Point(i + 1, points[i + 1]));
                ////}
                //for (int i = 0; i < 1000; i++)
                //{
                //    dc.DrawLine(pen, new Point(i, rnd.Next()), new Point(rnd.Next(), rnd.Next()));
                //}

                //Rect rect = new Rect(new System.Windows.Point(160, 100), new System.Windows.Size(320, 80));
                //dc.DrawRectangle(System.Windows.Media.Brushes.LightBlue, null, rect);
                dc.DrawLine(pen, new System.Windows.Point(160 + count * 10, 100), new System.Windows.Point(160 + count * 10, 200));
            }
            // InvalidateVisual();
            // });
            //_children.Add(CreateDrawingVisualRectangle());
        }
        // Create a DrawingVisual that contains a rectangle.
        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext in order to create new drawing content.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            // Create a rectangle and draw it in the DrawingContext.
            Rect rect = new Rect(new System.Windows.Point(160, 100), new System.Windows.Size(320, 80));
            drawingContext.DrawRectangle(System.Windows.Media.Brushes.LightBlue, null, rect);

            // Persist the drawing content.
            drawingContext.Close();

            return drawingVisual;
        }
        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount => _children.Count;

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _children[index];
        }
    }
}
