using AshellWPF.Core;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AshellWPF.ViewModels
{
    public class ThirdpartyLibraryViewModel : BindableBase, INavigationAware
    {
        public ObservableCollection<NavigatateItem> Controls { get; set; } = [];
        private readonly IRegionManager regionManager;

        public DelegateCommand<string> BasicControlCmd => new DelegateCommand<string>(BasicControlView);
        public ThirdpartyLibraryViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            Controls.Add(new NavigatateItem() { Name = "HandyControl", ViewName = "HandyControlSampleView", IconData = "ContactsIcon" });
            Controls.Add(new NavigatateItem() { Name = "ScottPlot", ViewName = "", IconData = "FavoriteIcon" });
        }
        private void BasicControlView(string view)
        {
            //Debug.WriteLine("BasicControlView");
            regionManager.RequestNavigate(RegionsConstants.MainContentRegion, view);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Debug.WriteLine($"OnNavigatedTo {Controls.Count}");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Debug.WriteLine("OnNavigatedFrom");
        }
    }
}
