using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HandyControlSample.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => SetProperty(ref dataList, value);
        }

        public MenuViewModel()
        {
            dataList = new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ Header = "Name1", Content = "\ue603" , DataList = new ObservableCollection<DemoDataModel>{ new DemoDataModel { Header = "Name1-1", Content = "\ue604"},
                                                                                                         new DemoDataModel { Header = "Name1-2", Content = "\ue604"},} },
                new DemoDataModel{ Header = "Name2", Content = "\ue603" , DataList = new ObservableCollection<DemoDataModel>{ new DemoDataModel { Header = "Name2-1", Content = "\ue604"},
                                                                                                         new DemoDataModel { Header = "Name2-2", Content = "\ue604"},} },
                new DemoDataModel{ Header = "Name3", Content = "\ue603"},
            };
        }

        private string _tagName = string.Empty;
        public string TagName
        {
            get => _tagName;
            set => SetProperty(ref _tagName, value);
        }


    }
}
