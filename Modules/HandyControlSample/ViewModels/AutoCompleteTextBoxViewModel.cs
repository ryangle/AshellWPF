using HandyControl.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Text;

namespace HandyControlSample.ViewModels
{
    public class AutoCompleteTextBoxViewModel : BindableBase
    {
        private string _searchText=string.Empty;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _ = SetProperty(ref _searchText, value);
                // 输入文本更新时修改绑定的数据源
                FilterItems(value);
            }
        }


        public ManualObservableCollection<DemoDataModel> Items { get; set; } = new ManualObservableCollection<DemoDataModel>();


        private List<DemoDataModel> SourceDataList { get; set; }

        public AutoCompleteTextBoxViewModel()
        {
            // 初始化数据源
            SourceDataList = new List<DemoDataModel>();
            for (int i = 1; i <= 10; i++)
            {
                DemoDataModel model = new DemoDataModel
                {
                    Name = $"Name{i}",
                };
                SourceDataList.Add(model);
            }
        }

        private void FilterItems(string key)
        {
            Items.CanNotify = false;
            Items.Clear();
            foreach (DemoDataModel data in SourceDataList)
            {
                if (data.Name.ToLower().Contains(key.ToLower()))
                {
                    Items.Add(data);
                }
            }
            Items.CanNotify = true;
        }

    }
}
