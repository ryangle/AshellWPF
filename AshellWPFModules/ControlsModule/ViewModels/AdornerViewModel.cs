


using System.Diagnostics;

namespace ControlSamples.ViewModels
{
    public class AdornerViewModel : BindableBase, INavigationAware
    {
        public string Title { get; set; } = "AdornerModel";
        public AdornerViewModel()
        {
            Debug.WriteLine("AdornerViewModel Creator");
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Debug.WriteLine("AdornerViewModel IsNavigationTarget");
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Debug.WriteLine("AdornerViewModel OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Debug.WriteLine("AdornerViewModel OnNavigatedTo");
        }
    }
}
