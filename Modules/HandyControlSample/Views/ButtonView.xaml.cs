using HandyControl.Controls;
using System;
using System.Collections.Generic;
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

namespace HandyControlSample.Views
{
    /// <summary>
    /// ButtonView.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonView : UserControl
    {
        private int count = 0;
        public ButtonView()
        {
            InitializeComponent();
        }
        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            count += 1;
            if (!(sender is RepeatButton button))
            {
                return;
            }
            button.Content = "Repeat Button: " + count;
        }

        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is ProgressButton button))
            {
                return;
            }
            for (int i = 0; i < 1000; i++)
            {
                button.Progress = 0.1 * (i + 1);
                //DispatcherHelper.DoEvents();
            }
        }
    }
}
