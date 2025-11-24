using ControlSamples.Views;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSamples
{
    [Module(ModuleName = "ControlSamplesView")]
    public class ControlSamplesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AdornerView>(nameof(AdornerView));
            containerRegistry.RegisterForNavigation<FollowMouseView>(nameof(FollowMouseView));
            containerRegistry.RegisterForNavigation<ControlSamplesView>(nameof(ControlSamplesView));
        }
    }
}
