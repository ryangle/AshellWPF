using AshellWPF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace AshellWPF.ViewModels
{
    public class MainNavigateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;
        private readonly IEventAggregator eventAggregator;

        public ObservableCollection<string> Controls { get; set; } = ["MainContentView", "AdornerView", "FollowMouseView"];
        public DelegateCommand<string> BasicControlCmd { get; private set; }
        public MainNavigateViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.moduleCatalog = moduleCatalog;
            this.eventAggregator = eventAggregator;
            BasicControlCmd = new DelegateCommand<string>(BasicControlView);

            eventAggregator.GetEvent<AppInitializedEvent>().Subscribe(AppInitialized);
        }
        private void BasicControlView(string view)
        {
            //Debug.WriteLine("BasicControlView");
            regionManager.RequestNavigate(RegionsConstants.MainContentRegion, view);
        }
        private void AppInitialized()
        {
            foreach (var m in moduleCatalog.Modules)
            {
                Controls.Add(m.ModuleName);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            foreach (var m in moduleCatalog.Modules)
            {
                Controls.Add(m.ModuleName);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}
