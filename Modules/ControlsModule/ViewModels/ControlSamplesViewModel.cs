

using AshellWPF.Core;
using Prism.Navigation.Regions;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ControlSamples.ViewModels
{
    public class ControlSamplesViewModel : BindableBase, INavigationAware
    {
        public ObservableCollection<NavigatateItem> Controls { get; set; } = [];
        private readonly IRegionManager regionManager;

        public DelegateCommand<string> BasicControlCmd => new DelegateCommand<string>(BasicControlView);
        public ControlSamplesViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            Controls.Add(new NavigatateItem() { Name = "鼠标跟随", ViewName = "FollowMouseView", IconData = "ContactsIcon" });
            Controls.Add(new NavigatateItem() { Name = "Adorner控件", ViewName = "AdornerView", IconData = "FavoriteIcon" });
            Controls.Add(new NavigatateItem() { Name = "Thumb拖动控件", ViewName = "ThumbSampleView", IconData = "FavoriteIcon" });
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
