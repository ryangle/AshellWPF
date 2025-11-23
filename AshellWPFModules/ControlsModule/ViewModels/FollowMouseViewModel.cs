
using System.Diagnostics;

namespace ControlSamples.ViewModels
{
    public class FollowMouseViewModel : BindableBase, INavigationAware
    {
        public string Title { get; set; } = "FollowMouseModel";
        public FollowMouseViewModel()
        {
            Debug.WriteLine("FollowMouseViewModel creator");
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Debug.WriteLine("FollowMouseViewModel IsNavigationTarget");
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Debug.WriteLine("FollowMouseViewModel OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Debug.WriteLine("FollowMouseViewModel OnNavigatedTo");
        }
    }
}
