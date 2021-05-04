using BlazorTry.Extends;
using System;
using System.Collections.ObjectModel;

namespace BlazorTry.Models {
    public class Lottery : BindableBase {
        /// <summary>名称</summary>
        public string Name { get => name; set => SetProperty(ref name, value); }
        private string name;

        public ObservableCollection<string> NameList {
            get => nameList;
            set => SetProperty(ref nameList, value);
        }
        private ObservableCollection<string> nameList;

        public Lottery(ObservableCollection<string> nameList) {
            NameList = nameList;
            Name = "抽選結果表示";
        }

        public void Action() {
            if (NameList == null) return;
            var rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            Name = NameList[rnd.Next(0, NameList.Count)];
        }

        public void Add(string name) {
            NameList.Add(name);
        }
    }
}
