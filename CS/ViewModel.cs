using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MasterDetailInside {
    public class ParentDataItem : BindableBase {
        public string Text { get { return GetValue<string>(); } set { SetValue(value); } }

        public int Number { get { return GetValue<int>(); } set { SetValue(value); } }

        public ObservableCollection<DataItem> Data { get { return GetValue<ObservableCollection<DataItem>>(); } set { SetValue(value); } }
    }

    public class DataItem : BindableBase {
        public bool Ready { get { return GetValue<bool>(); } set { SetValue(value); } }

        public string Text { get { return GetValue<string>(); } set { SetValue(value); } }

        public int Number { get { return GetValue<int>(); } set { SetValue(value); } }
    }

    public class ViewModel {
        public ObservableCollection<ParentDataItem> Data { get; set; }

        public ViewModel() {
            Data = new ObservableCollection<ParentDataItem>(GetData());
        }

        static IEnumerable<ParentDataItem> GetData() {
            for(int i = 0; i < 100; i++) {
                var parentTestData = new ParentDataItem() { Text = "Master" + i, Number = i, Data = new ObservableCollection<DataItem>() };
                for(int j = 0; j < 50; j++) {
                    parentTestData.Data.Add(new DataItem() { Text = "Detail" + j + " Master" + i, Number = j, Ready = j % 2 != 0 });
                }
                yield return parentTestData;
            }
        }
    }
}
