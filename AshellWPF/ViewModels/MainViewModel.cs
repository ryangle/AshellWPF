using Prism.Navigation.Regions;
using AshellWPF.Core;
using AshellWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace AshellWPF.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ObservableCollection<string> Controls { get; set; } = [];

        public DelegateCommand BackCommand { get; set; }
        public DelegateCommand SettingsCommand { get; set; }
        public DelegateCommand<string> SelectViewCommand { get; set; }
        
        public bool CanNavigateback { get; set; } = true;
        private IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public MainViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.moduleCatalog = moduleCatalog;
            //_regionManager.RegisterViewWithRegion("WorkRegion", typeof(AdornerView));
            BackCommand = new DelegateCommand(Back);
            SettingsCommand = new DelegateCommand(Settings);
            SelectViewCommand = new DelegateCommand<string>(SelectView);
            eventAggregator.GetEvent<AppInitializedEvent>().Subscribe(AppInitialized);
            //Controls.Add("AdornerView");
            //Controls.Add("FollowMouseView");


        }
        private void AppInitialized()
        {
            foreach (var m in moduleCatalog.Modules)
            {
                Controls.Add(m.ModuleName);
            }
        }
        private void Back()
        {
            Debug.WriteLine("back");
        }
        private void Settings()
        {
            Debug.WriteLine($"{nameof(Settings)},{moduleCatalog.Modules.Count()}");
        }
        private void SelectView(string view)
        {
            Debug.WriteLine($"SelectView:{view}");

            regionManager.RequestNavigate("MainContentRegion", "AdornerView");
        }
    }
}
