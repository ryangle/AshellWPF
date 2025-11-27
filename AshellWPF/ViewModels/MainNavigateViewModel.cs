using AshellWPF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace AshellWPF.ViewModels
{

    public class MainNavigateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public ObservableCollection<NavigatateItem> Controls { get; set; } = [];
        public DelegateCommand<string> BasicControlCmd { get; private set; }
        public MainNavigateViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.regionManager = regionManager;
            this.moduleCatalog = moduleCatalog;
            BasicControlCmd = new DelegateCommand<string>(BasicControlView);
            Controls.Add(new NavigatateItem() { ViewName = "ControlSamplesView", IconData = "MessageIcon" });
            Controls.Add(new NavigatateItem() { ViewName = "ThirdpartyLibraryView", IconData = "ContactsIcon" });
            Controls.Add(new NavigatateItem() { ViewName = "DiagramDesignerSampleView", IconData = "FavoriteIcon" });
        }
        private void BasicControlView(string view)
        {
            Debug.WriteLine($"BasicControlView {view}");
            if (string.IsNullOrEmpty(view))
            {
                return;
            }
            var rs = regionManager.Regions;
            regionManager.RequestNavigate(RegionsConstants.SubNavigateRegion, view);
        }
        private void AppInitialized()
        {
            //foreach (var m in moduleCatalog.Modules)
            //{
            //    Controls.Add(m.ModuleName);
            //}
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //foreach (var m in moduleCatalog.Modules)
            //{
            //    Controls.Add(m.ModuleName);
            //}
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
