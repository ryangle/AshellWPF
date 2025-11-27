

using AshellWPF.Core;
using Prism.Navigation.Regions;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DiagramDesignerSample.ViewModels
{
    public class DiagramDesignerSampleViewModel : BindableBase, INavigationAware
    {
        public ObservableCollection<NavigatateItem> Controls { get; set; } = [];
        private readonly IRegionManager regionManager;

        public DelegateCommand<string> BasicControlCmd => new DelegateCommand<string>(BasicControlView);
        public DiagramDesignerSampleViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            Controls.Add(new NavigatateItem() { Name = "设计器1", ViewName = "DiagramDesignerApp1View", IconData = "ContactsIcon" });
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
