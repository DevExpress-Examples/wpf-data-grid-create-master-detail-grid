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

        protected bool _Ready;
        public bool Ready
        {
            get { return this._Ready; }
            set { this.SetProperty(ref this._Ready, value, "Ready"); }
        }

        protected string _Text;
        public string Text
        {
            get { return this._Text; }
            set { this.SetProperty(ref this._Text, value, "Text"); }
        }

        protected int _Number;
        public int Number
        {
            get { return this._Number; }
            set { this.SetProperty(ref this._Number, value, "Number"); }
        }
    }

    public class ParentTestData : BindableBase
    {
        protected string _Text;
        public string Text
        {
            get { return this._Text; }
            set { this.SetProperty(ref this._Text, value, "Text"); }
        }

        protected int _Number;
        public int Number
        {
            get { return this._Number; }
            set { this.SetProperty(ref this._Number, value, "Number"); }
        }

        protected ObservableCollection<TestData> _Data;
        public ObservableCollection<TestData> Data
        {
            get { return this._Data; }
            set { this.SetProperty(ref this._Data, value, "Data"); }
        }
    }
}
