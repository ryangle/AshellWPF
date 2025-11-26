using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Text;

namespace HandyControlSample.ViewModels
{
    public enum DemoType
    {
        Type1 = 1,
        Type2,
        Type3,
        Type4,
        Type5,
        Type6
    }
    public class DemoDataModel : BindableBase
    {
        public int Index { get; set; }

        //public string Name { get; set; }
        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }


        public bool IsSelected { get; set; }

        public string Remark { get; set; }

        public DemoType Type { get; set; }

        public string ImgPath { get; set; }

        public ObservableCollection<DemoDataModel> DataList { get; set; }

        // Card
        public string Header { get; set; }

        public string Content { get; set; }

        public string Footer { get; set; }

        // Avatar
        public string DisplayName { get; set; }

        public string Link { get; set; }

        public string AvatarUri { get; set; }

    }
}
