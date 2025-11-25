using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfControls
{
    /// <summary>
    /// M512 1024C229.7 1024 0 794.3 0 512S229.7 0 512 0s512 205.4 512 457.8c0 162.8-132.5 295.3-295.3 295.3h-96.2c-31.4 0-56.9 25.5-56.9 56.9 0 13.2 5.2 26.4 14.6 37.3 17.9 20.5 27.4 45.1 27.4 71.1 0 58.2-47.3 105.6-105.6 105.6z m0-975.2C256.6 48.8 48.8 256.6 48.8 512c0 255.4 207.8 463.2 463.2 463.2 31.4 0 56.9-25.5 56.9-56.9 0-14.2-5.2-27.3-15.5-39.1-17.2-19.8-26.6-44.4-26.6-69.3 0-58.3 47.4-105.7 105.6-105.7h96.2c135.9 0 246.5-110.6 246.5-246.5 0.1-225.4-207.7-408.9-463.1-408.9z
    /// </summary>
    public class IconButton : Button
    {
        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
        }

        public Geometry IconData
        {
            get { return (Geometry)GetValue(IconDataProperty); }
            set { SetValue(IconDataProperty, value); }
        }

        public static readonly DependencyProperty IconDataProperty =
            DependencyProperty.Register(nameof(IconData), typeof(Geometry), typeof(IconButton), new PropertyMetadata(default(Geometry)));


    }
}
