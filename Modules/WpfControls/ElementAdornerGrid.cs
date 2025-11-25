using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfControls
{
    /// <summary>
    /// https://www.cnblogs.com/loveis715/archive/2012/03/31/2427734.html
    /// </summary>
    public class ElementAdornerGrid : Grid
    {
        public ElementAdornerGrid()
        {
            Loaded += ElementAdornerGrid_Loaded;
            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, 0);
        }

        private void ElementAdornerGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var layer = AdornerLayer.GetAdornerLayer(this);

            layer.Add(new ElementAdorner(this));
        }
    }
}
