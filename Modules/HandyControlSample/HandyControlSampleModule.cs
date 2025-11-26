using HandyControlSample.Views;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSamples
{
    [Module(ModuleName = "HandyControlSampleModule")]
    public class HandyControlSampleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HandyControlSampleView>(nameof(HandyControlSampleView));
        }
    }
}
