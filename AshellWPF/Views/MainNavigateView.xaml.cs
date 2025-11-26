using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AshellWPF.Views
{
    /// <summary>
    /// MainNavigateView.xaml 的交互逻辑
    /// </summary>
    public partial class MainNavigateView : UserControl
    {
        public MainNavigateView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 映射左键单击事件为右键单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            var mouseDownEvent =
                new MouseButtonEventArgs(Mouse.PrimaryDevice,
                    Environment.TickCount,
                    MouseButton.Right)
                {
                    RoutedEvent = Mouse.MouseUpEvent,
                    Source = PhoneButton,
                };
            InputManager.Current.ProcessInput(mouseDownEvent);
        }
    }
}
