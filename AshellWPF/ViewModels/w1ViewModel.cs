using AshellWPF.Core;
using AshellWPF.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using static DryIoc.Setup;

namespace AshellWPF.ViewModels
{
    public class w1ViewModel : BindableBase
    {
       

        //public DelegateCommand LoginCmd => new(Login);
        public DelegateCommand ChangeCmd => new(() =>
        {
            Debug.WriteLine("w1ViewModel ChangeCmd");
            PasswordString = "ChangedPassword";
        });

        public string Username { get; set; }
        
        private string passwordString;
        public string PasswordString
        {
            get { return passwordString; }
            set
            {
                passwordString = value;
                RaisePropertyChanged(nameof(PasswordString));
            }
        }

        IRegionManager regionManager;
        private readonly IContainerProvider containerProvider;

        public w1ViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            this.regionManager = regionManager;
            this.containerProvider = containerProvider;
        }
        private void Login()
        {
            Debug.WriteLine($"w1ViewModel Login  Username:{Username}, Password:{PasswordString}");
            //var shell = containerProvider.Resolve<HostView>();
            //shell.Visibility = System.Windows.Visibility.Hidden;
            //regionManager.RequestNavigate("HostRegion", "w2View");
            //shell.Visibility = System.Windows.Visibility.Visible;
        }
        public DelegateCommand<PasswordBox> LoginCmd => new(Login);
        private void Login(PasswordBox passwordBox)
        {
            Debug.WriteLine($"Password:{passwordBox.Password}");
            //var shell = containerProvider.Resolve<HostView>();
            //shell.Visibility = System.Windows.Visibility.Hidden;
            regionManager.RequestNavigate("HostRegion", "w2View");
            //shell.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
