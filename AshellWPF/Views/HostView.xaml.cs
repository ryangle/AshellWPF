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
using System.Windows.Shapes;
using System.Windows.Shell;

namespace AshellWPF.Views
{
    /// <summary>
    /// HostView.xaml 的交互逻辑
    /// </summary>
    public partial class HostView : Window
    {
        public HostView()
        {
            InitializeComponent();
            WindowChrome.SetWindowChrome(
            this,
            new WindowChrome
            {
                CaptionHeight = 50,
                CornerRadius = new CornerRadius(10),
                GlassFrameThickness = new Thickness(-1),
                ResizeBorderThickness = default,
                UseAeroCaptionButtons = true,
                NonClientFrameEdges = SystemParameters.HighContrast ? NonClientFrameEdges.None :
                    NonClientFrameEdges.Right | NonClientFrameEdges.Bottom | NonClientFrameEdges.Left
            });
        }
    }
}
