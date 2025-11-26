using System;
using System.Collections.Generic;
using System.Text;

namespace HandyControlSample.ViewModels
{
    public class HandyControlSampleViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public DelegateCommand<string> ShowViewCmd => new(ShowView);
        public HandyControlSampleViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        private void ShowView(string view)
        {
            regionManager.RequestNavigate("HandyControlSample.MainContent", view);
        }
    }
}
