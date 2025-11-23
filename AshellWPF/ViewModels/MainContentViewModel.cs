using AshellWPF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace AshellWPF.ViewModels
{
    public class MainContentViewModel : BindableBase, INavigationAware, IActiveAware
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;
        private readonly IEventAggregator eventAggregator;

        public event EventHandler IsActiveChanged;
        public DelegateCommand LoginCmd { get; set; }
        public DelegateCommand<string> BasicControlCmd { get; private set; }
        public bool IsActive { get; set; }

        public MainContentViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.moduleCatalog = moduleCatalog;
            this.eventAggregator = eventAggregator;
            BasicControlCmd = new DelegateCommand<string>(BasicControlView);
            LoginCmd = new DelegateCommand(Login);
            Debug.WriteLine("MainContentViewModel Creator");

            IsActiveChanged += MainContentViewModel_IsActiveChanged;

        }
        private void Login()
        {
            Debug.WriteLine($"MainContentViewModel Login  IsActive:{IsActive}");
        }
        private void MainContentViewModel_IsActiveChanged(object? sender, EventArgs e)
        {
            Debug.WriteLine($"MainContentViewModel MainContentViewModel_IsActiveChanged  IsActive:{IsActive}");
        }

        private void BasicControlView(string view)
        {
            //Debug.WriteLine("BasicControlView");
            regionManager.RequestNavigate(RegionsConstants.MainContentRegion, view);
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Debug.WriteLine("MainContentViewModel IsNavigationTarget");
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Debug.WriteLine($"MainContentViewModel OnNavigatedFrom IsActive:{IsActive}");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Debug.WriteLine($"MainContentViewModel OnNavigatedTo IsActive:{IsActive}");
        }
    }
}
