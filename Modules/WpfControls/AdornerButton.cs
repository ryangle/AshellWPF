using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfControls
{
    /// <summary>
    /// 
    /// </summary>
    public class AdornerButton : Button
    {
        public AdornerButton()
        {
            Loaded += AdornerButton_Loaded;
        }

        private void AdornerButton_Loaded(object sender, RoutedEventArgs e)
        {
            var layer = AdornerLayer.GetAdornerLayer(this);

            layer.Add(new AdornerDemo(this));
        }
    }
}
