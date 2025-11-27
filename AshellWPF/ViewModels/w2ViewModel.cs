using AshellWPF.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static DryIoc.Setup;

namespace AshellWPF.ViewModels
{
    public class w2ViewModel : BindableBase
    {
        public DelegateCommand BackCommand { get; set; }
        IRegionManager regionManager;
        public w2ViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            BackCommand = new DelegateCommand(Back);
        }

        private void Back()
        {
            regionManager.RequestNavigate("HostRegion", "w1View");
        }
    }
}
