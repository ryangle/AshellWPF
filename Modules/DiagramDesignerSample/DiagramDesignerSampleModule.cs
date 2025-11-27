using DiagramDesignerSample.Views;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSamples
{
    [Module(ModuleName = "DiagramDesignerSampleModule")]
    public class DiagramDesignerSampleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DiagramDesignerSampleView>(nameof(DiagramDesignerSampleView));
            containerRegistry.RegisterForNavigation<DiagramDesignerApp1View>(nameof(DiagramDesignerApp1View));
        }
    }
}
