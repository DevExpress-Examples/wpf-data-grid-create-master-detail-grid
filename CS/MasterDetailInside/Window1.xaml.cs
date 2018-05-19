using System;
using System.Collections.Generic;
using System.Windows;
using DevExpress.Wpf.Grid;

namespace MasterDetailInside {

    public partial class Window1 : Window {

        #region ExpandedProperty
        public static readonly DependencyProperty ExpandedProperty;

        public static void SetExpanded(DependencyObject element, bool value) {
            element.SetValue(ExpandedProperty, value);
        }

        public static bool GetExpanded(DependencyObject element) {
            return (bool)element.GetValue(ExpandedProperty);
        }

        static Window1() {
            ExpandedProperty = DependencyProperty.RegisterAttached("Expanded", typeof(bool),
                typeof(Window1), new PropertyMetadata(false));
        }
        #endregion

        #region Test data objects
        public class TestRecord {
            public TestRecord(string column1, TestRecordList2 column2) {
                this.column1 = column1;
                this.column2 = column2;
            }

            string column1;
            public string Column1 {
                get { return column1; }
                set { column1 = value; }
            }

            TestRecordList2 column2;
            public object Column2 {
                get { return column2; }
                set { column2 = (TestRecordList2)value; }
            }

        }

        public class TestRecordList : List<TestRecord> {

        }

        public class TestRecord2 {
            public TestRecord2(string column1, string column2) {
                this.column1 = column1;
                this.column2 = column2;
            }

            string column1;
            public string Column1 {
                get { return column1; }
                set { column1 = value; }
            }

            string column2;
            public string Column2 {
                get { return column2; }
                set { column2 = value; }
            }
        }

        public class TestRecordList2 : List<TestRecord2> {
            public override string ToString() {
                return "Detail (Count = " + Count.ToString() + ")";
            }
        }
        #endregion

        TestRecordList recListMain;
        public Window1() {
            InitializeComponent();

            recListMain = new TestRecordList();

            Random rnd = new Random();
            for (int i = 0; i < 50; i++) {
                TestRecordList2 recList = new TestRecordList2();
                recListMain.Add(new TestRecord("col 1 row " + i, recList));
                int count = rnd.Next(40) + 10;
                for (int j = 0; j < count; j++) {
                    recList.Add(new TestRecord2("detatil " + i + " col 1 row " + j, 
                        "detatil " + i + " col 2 row " + j));
                }
            }

            grid.DataSource = recListMain;
        }

        bool odd = true;
        private void Button_Click(object sender, RoutedEventArgs e) {
            if (odd) {
                (grid.View as TableView).MoveFocusedRow(40);
                odd = false;
            }
            else {
                odd = true;
                (grid.View as TableView).MoveFocusedRow(0);
            }
        }
    }

    
}
