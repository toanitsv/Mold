using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MoldCalculator.Models;
using MoldCalculator.Helpers;

namespace MoldCalculator.Views
{
    /// <summary>
    /// Interaction logic for AddAMold.xaml
    /// </summary>
    public partial class AddAMoldWindow : Window
    {
        public Mold mold;
        public bool isEdit = false;
        public List<SizeRun> sizeRunListClicked;

        Order order_OutsoleCode;
        List<SizeRun> sizeRunList;
        List<OffDay> offDayList;
        public AddAMoldWindow(Mold mold, Order order_OutsoleCode, List<SizeRun> sizeRunList, List<OffDay> offDayList)
        {
            this.mold = mold;
            this.order_OutsoleCode = order_OutsoleCode;
            this.sizeRunList = sizeRunList;
            this.offDayList = offDayList;

            sizeRunListClicked = new List<SizeRun>();
            InitializeComponent();
        }

        int qtyMold;
        private void btnAddSizeNo_Click(object sender, RoutedEventArgs e)
        {
            qtyMold = 0;
            Int32.TryParse(txtQuantityMold.Text, out qtyMold);
            if (qtyMold == 0)
            {
                MessageBox.Show("Input Quantity", "Mold", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            popAddSizeNo.IsOpen = true;
            CreatePopupSizeRun(sizeRunList);
        }
       
        private void CreatePopupSizeRun(List<SizeRun> sizeRunList)
        {
            stkSizeRunList.Children.Clear();
            for (int i = 0; i < sizeRunList.Count(); i++)
            {
                var sizeRun = sizeRunList[i];
                Button btnSizeRun = new Button();
                btnSizeRun.Content = string.Format("+ {0} / {1}", sizeRun.SizeNo, sizeRun.Quantity);
                btnSizeRun.Margin = new Thickness(0, 0, 0, 5);
                if (i == sizeRunList.Count() - 1)
                    btnSizeRun.Margin = new Thickness(0, 0, 0, 0);

                btnSizeRun.Tag = sizeRun;
                btnSizeRun.Click += btnSizeRun_Click;
                stkSizeRunList.Children.Add(btnSizeRun);
            }
        }

        int? pairs;
        string sizeNo;
        double workingDay;
        bool canTextChange = false;
        private void btnSizeRun_Click(object sender, RoutedEventArgs e)
        {
            popAddSizeNo.IsOpen = false;
            canTextChange = true;

            var buttonClicked = sender as Button;
            var sizeRunClicked = buttonClicked.Tag as SizeRun;
            sizeRunListClicked.Add(sizeRunClicked);

            sizeRunList.Remove(sizeRunClicked);

            sizeNo = String.Join(" | ", sizeRunListClicked.Select(s => s.SizeNo).ToList());

            pairs = sizeRunListClicked.Sum(s => s.Quantity);

            txtSizeNo.Text = sizeNo;
            txtPairs.Text = String.Format("{0:0,00}", pairs);
            Display();
        }

        private void Display()
        {
            workingDay = Math.Round((double)pairs / (double)qtyMold / (double)mold.Quota, 2);
            txtWorkingDay.Text = workingDay.ToString();
            var checkOffDayList = TimerHelper.CheckOffDay(mold.StartDate.Value.Date, offDayList.Select(s => s.OffDate.Value.Date).ToList(), workingDay);
            dpFinishDate.SelectedDate = checkOffDayList.LastOrDefault();
            btnAdd.IsEnabled = true;
        }

        private void txtQuantityMold_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (canTextChange == true)
            {
                qtyMold = 0;
                Int32.TryParse(txtQuantityMold.Text, out qtyMold);
                if (qtyMold == 0)
                {
                    MessageBox.Show("Input Quantity", "Mold-Calculator", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Display();
            }
        }

        private void btnClosePopUp_Click(object sender, RoutedEventArgs e)
        {
            stkSizeRunList.Children.Clear();
            popAddSizeNo.IsOpen = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mold.Quantity = qtyMold;
            mold.SizeNo = sizeNo;
            mold.WorkingDay = workingDay;
            mold.Pairs = pairs;
            mold.FinishDate = dpFinishDate.SelectedDate.Value.Date;

            isEdit = true;
            this.Close();
        }
    }
}
