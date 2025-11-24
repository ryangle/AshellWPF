using AshellWPF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace AshellWPF.ViewModels
{
    public class NavigatateItem
    {
        public string Name { get; set; } = string.Empty;
        public string IconData { get; set; } = string.Empty;
    }
    public class MainNavigateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public ObservableCollection<NavigatateItem> Controls { get; set; } = [];
        public DelegateCommand<string> BasicControlCmd { get; private set; }
        public MainNavigateViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.regionManager = regionManager;
            this.moduleCatalog = moduleCatalog;
            BasicControlCmd = new DelegateCommand<string>(BasicControlView);
            Controls.Add(new NavigatateItem() { Name = "ControlSamplesView", IconData = "M525.764052 901.488558c-33.101977 0-100.670962-10.46523-132.123528-15.413464l-240.188402 137.811154v-230.348812C47.77605 706.346145-0.170629 588.555432-0.170629 445.909798c0-246.217285 235.06954-445.796045 525.934681-445.796046 241.837814 0 497.89469 188.886025 497.894691 435.103311 0 246.217285-207.427683 466.271495-497.894691 466.271495z m222.272384-389.488558a59.037547 59.037547 0 1 0 0-118.075094 59.037547 59.037547 0 0 0 0 118.075094z m-236.263941 0a59.094423 59.094423 0 1 0-0.056876-118.131971 59.094423 59.094423 0 0 0 0 118.131971z m-236.263941 0a59.094423 59.094423 0 1 0 0-118.188847 59.094423 59.094423 0 0 0 0 118.188847z" });
            Controls.Add(new NavigatateItem() { Name = "FollowMouseView", IconData = "M405.333333 138.666667c147.285333 0 266.666667 119.381333 266.666667 266.666666 0 97.834667-52.693333 183.36-131.2 229.76 105.664 44.053333 186.133333 138.346667 209.621333 255.210667a32 32 0 1 1-62.72 12.586667c-26.389333-131.157333-140.672-227.626667-275.498666-230.826667l-6.314667-0.085333L405.333333 672h-0.853333c-137.386667 0.384-254.698667 97.749333-281.472 230.826667a32 32 0 0 1-62.741333-12.608c23.488-116.821333 103.978667-211.072 209.621333-255.146667A266.453333 266.453333 0 0 1 138.666667 405.333333c0-147.285333 119.381333-266.666667 266.666666-266.666666z m256-42.666667c135.488 0 245.333333 109.845333 245.333334 245.333333 0 79.786667-38.442667 152.128-99.456 197.312l-2.389334 1.706667C904.725333 591.893333 970.666667 693.76 970.666667 810.666667a32 32 0 0 1-64 0c0-113.045333-78.08-208.298667-188.757334-234.730667a32 32 0 0 1-0.704-62.08l-1.237333 0.426667A181.418667 181.418667 0 0 0 842.666667 341.333333a181.333333 181.333333 0 0 0-216.853334-177.856 32 32 0 0 1-12.437333-62.784c15.68-3.114667 31.722667-4.693333 47.957333-4.693333z m-256 106.666667a202.666667 202.666667 0 0 0 0 405.333333l-0.810666-0.021333 0.810666 0.021333h0.810667A202.666667 202.666667 0 0 0 405.333333 202.666667z" });
            Controls.Add(new NavigatateItem() { Name = "AdornerView", IconData = "M512.118374 131.072L603.766374 317.44c20.48 41.472 59.392 70.144 104.96 76.8l205.824 30.208-148.992 145.92c-32.768 32.256-47.616 78.336-39.936 123.392l35.328 205.824-183.296-96.768c-19.968-10.752-42.496-16.384-65.024-16.384-22.528 0-45.056 5.632-65.024 16.384l-183.296 96.768 35.328-205.824c7.68-45.056-7.168-91.136-39.936-123.392L109.686374 424.448 314.998374 394.24c45.568-6.656 84.992-35.328 104.96-76.8l92.16-186.368m0-112.64c-20.48 0-41.472 10.752-51.712 32.256L346.742374 281.6c-8.192 16.896-24.576 29.184-43.52 31.744L49.270374 350.208C2.166374 357.376-16.777626 415.232 17.526374 449.024l183.808 180.224c13.312 13.312 19.968 32.256 16.384 51.2l-43.52 253.952c-6.144 37.376 23.552 67.584 56.832 67.584 8.704 0 17.92-2.048 27.136-6.656L484.982374 875.52c8.192-4.608 17.92-6.656 27.136-6.656 9.216 0 18.432 2.048 27.136 6.656l226.816 119.808c8.704 4.608 17.92 6.656 27.136 6.656 33.792 0 63.488-30.208 56.832-67.584l-43.52-253.952c-3.072-18.944 3.072-37.888 16.384-51.2l183.808-180.224c34.304-33.28 15.36-91.648-32.256-98.304l-253.952-36.864c-18.944-2.56-35.328-14.848-43.52-31.744L563.830374 50.688c-10.752-21.504-31.232-32.256-51.712-32.256z" });
        }
        private void BasicControlView(string view)
        {
            //Debug.WriteLine("BasicControlView");
            regionManager.RequestNavigate(RegionsConstants.SubNavigateRegion, view);
        }
        private void AppInitialized()
        {
            //foreach (var m in moduleCatalog.Modules)
            //{
            //    Controls.Add(m.ModuleName);
            //}
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //foreach (var m in moduleCatalog.Modules)
            //{
            //    Controls.Add(m.ModuleName);
            //}
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}
