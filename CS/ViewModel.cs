using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MasterDetailInside {
    public class ViewModel {
        ObservableCollection<ParentTestData> data;
        public ObservableCollection<ParentTestData> Data {
            get {
                if(data == null){
                    data = new ObservableCollection<ParentTestData>();
                    for(int i = 0; i < 100; i++) {
                        ParentTestData parentTestData = new ParentTestData() { Text = "Master" + i, Number = i, Data = new ObservableCollection<TestData>() };
                        for(int j = 0; j < 50; j++)
                            parentTestData.Data.Add(new TestData() { Text = "Detail" + j + " Master" + i, Number = j, Ready = j % 2 != 0 });
                        data.Add(parentTestData);
                    }
                }
                return data;
            }
        }
    }

    public class TestData : BindableBase
    {
        public bool Ready
        {
            get { return GetProperty(() => Ready); }
            set { SetProperty(() => Ready, value); }
        }
        public string Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }
        public int Number
        {
            get { return GetProperty(() => Number); }
            set { SetProperty(() => Number, value); }
        }
    }

    public class ParentTestData : BindableBase
    {
        public string Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }
        public int Number
        {
            get { return GetProperty(() => Number); }
            set { SetProperty(() => Number, value); }
        }
        public ObservableCollection<TestData> Data
        {
            get { return GetProperty(() => Data); }
            set { SetProperty(() => Data, value); }
        }
    }
}
