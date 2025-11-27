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

namespace DiagramDesignerSample.Views
{
    /// <summary>
    /// DiagramDesignerApp1View.xaml 的交互逻辑
    /// </summary>
    public partial class DiagramDesignerApp1View : UserControl
    {
        public DiagramDesignerApp1View()
        {
            InitializeComponent();
        }
        private void DesignerScrollViewer_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }
    }
}
