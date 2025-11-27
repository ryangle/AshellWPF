using AshellWPF.Core;
using AshellWPF.ViewModels;
using AshellWPF.Views;
using ControlSamples;
using ControlSamples.Views;
using DryIoc;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AshellWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<LoginView>();
            //return Container.Resolve<HostView>();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("HostRegion", nameof(w1View));
            regionManager.RegisterViewWithRegion(RegionsConstants.MainNavigateRegion, typeof(MainNavigateView));
            regionManager.RegisterViewWithRegion(RegionsConstants.SubNavigateRegion, "ControlSamplesView");
            regionManager.RequestNavigate(RegionsConstants.MainContentRegion, nameof(MainContentView));
            Container.Resolve<IEventAggregator>().GetEvent<AppInitializedEvent>().Publish();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry
            //    .RegisterSingleton<MainView>()
            //    .RegisterSingleton<LoginView>();

            //containerRegistry.Register<MainView>();
            //containerRegistry.Register<MainViewModel>();

            //containerRegistry.RegisterForNavigation<MainNavigateView>("MainNavigateRegion");
            //containerRegistry.RegisterForNavigation<FollowMouseView>("FollowMouseView");
            containerRegistry.RegisterForNavigation<MainContentView>(nameof(MainContentView));
            containerRegistry.RegisterForNavigation<ThirdpartyLibraryView>(nameof(ThirdpartyLibraryView));
            containerRegistry.RegisterForNavigation<w1View>(nameof(w1View));
            containerRegistry.RegisterForNavigation<w2View>(nameof(w2View));
            //containerRegistry.RegisterDialog<ConfirmationDialog, ConfirmationDialogViewModel>();

        }
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            // ViewModelLocationProvider.Register<MainNavigateView, MainNavigateViewModel>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<ControlSamplesModule>();
            moduleCatalog.AddModule<HandyControlSampleModule>();
            moduleCatalog.AddModule<DiagramDesignerSampleModule>();
        }
        ////运行时加载Module的方式
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog { ModulePath = @".\Modules" };
        //}
    }

}
