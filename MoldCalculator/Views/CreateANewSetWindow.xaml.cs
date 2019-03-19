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
using MoldCalculator.Controllers;
using System.ComponentModel;

namespace MoldCalculator.Views
{
    /// <summary>
    /// Interaction logic for CreateANewSetWindow.xaml
    /// </summary>
    public partial class CreateANewSetWindow : Window
    {
        BackgroundWorker bwLoad;

        List<Order> orderList;
        List<SizeRun> sizeRunList;
        List<Supplier> supplierList;
        List<ComponentShoe> componentList;
        List<OffDay> offDayList;
        List<OffDay_Supplier_Mapping> offDayMapList;

        Order orderClicked;
        Supplier supplierClicked;
        ComponentShoe componentClicked;

        List<Mold> currentMoldList;
        List<String> sizeNoClickedList;

        public CreateANewSetWindow()
        {
            bwLoad = new BackgroundWorker();
            bwLoad.DoWork += bwLoad_DoWork;
            bwLoad.RunWorkerCompleted += bwLoad_RunWorkerCompleted;

            orderList = new List<Order>();
            supplierList = new List<Supplier>();
            componentList = new List<ComponentShoe>();

            currentMoldList = new List<Mold>();

            orderClicked = new Order();
            sizeRunList = new List<SizeRun>();
            supplierClicked = new Supplier();
            componentClicked = new ComponentShoe();

            offDayList = new List<OffDay>();
            offDayMapList = new List<OffDay_Supplier_Mapping>();

            sizeNoClickedList = new List<String>();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (bwLoad.IsBusy == false)
            {
                dpStartDate.SelectedDate = DateTime.Now.Date;
                dpRequestDate.SelectedDate = DateTime.Now.Date;

                this.Cursor = Cursors.Wait;
                bwLoad.RunWorkerAsync();
            }
        }
        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            orderList = OrderController.Select();
            supplierList = SupplierController.Select();
            componentList = ComponentController.Select();
            sizeRunList = SizeRunController.Select();
            offDayList = OffDayController.Select();
            offDayMapList = OffDayMapController.Select();
        }
        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cbOutsoleCode.SelectedItem = orderList.FirstOrDefault();
            orderClicked = orderList.FirstOrDefault();
            cbOutsoleCode.ItemsSource = orderList;

            cbSupplier.SelectedItem = supplierList.FirstOrDefault();
            supplierClicked = supplierList.FirstOrDefault();
            cbSupplier.ItemsSource = supplierList;

            cbComponent.SelectedItem = componentList.FirstOrDefault();
            componentClicked = componentList.FirstOrDefault();
            cbComponent.ItemsSource = componentList;

            btnAddMold.Content = String.Format("Add a mold for\n{0}\n{1}\n{2}", orderClicked.OutsoleCode,
                                                                                    componentClicked.ComponentName,
                                                                                    supplierClicked.SupplierName);
            this.Cursor = null;
        }

        private void btnAddMold_Click(object sender, RoutedEventArgs e)
        {
            int quota = 0;
            Int32.TryParse(txtQuota.Text.ToString(), out quota);
            if (quota == 0)
            {
                MessageBox.Show("Input Quota (Pairs / Day)", "Mold-Calculator", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var moldCreate = new Mold()
            {
                MoldName = "",
                Quota = quota,
                OutsoleCode = orderClicked.OutsoleCode,
                SupplierID = supplierClicked.SupplierID,
                ComponentID = componentClicked.ComponentID,
                Round = 1,
                StartDate = dpStartDate.SelectedDate.Value.Date,
                RequestDate = dpRequestDate.SelectedDate.Value.Date,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now
            };

            var sizeRunListTranfer = sizeRunList.Where(w => w.OutsoleCode == orderClicked.OutsoleCode).ToList();
            if (sizeNoClickedList.Count() > 0)
            {
                sizeRunListTranfer = sizeRunListTranfer.Where(w => sizeNoClickedList.Contains(w.SizeNo) == false).ToList();
            }
            var order_OutsoleCode = orderList.SingleOrDefault(w => w.OutsoleCode == orderClicked.OutsoleCode);
            var offDayMapList_Supplier = offDayMapList.Where(w => w.SupplierID == supplierClicked.SupplierID).ToList();
            var offDayTranferList = offDayList.Where(w => offDayMapList_Supplier.Select(s => s.OffDayID).Contains(w.OffDayID)).ToList();

            AddAMoldWindow window = new AddAMoldWindow(moldCreate, order_OutsoleCode, sizeRunListTranfer, offDayTranferList);
            window.ShowDialog();
            if (window.isEdit == true)
            {
                moldCreate.Quantity = window.mold.Quantity;
                moldCreate.SizeNo = window.mold.SizeNo;
                moldCreate.Pairs = window.mold.Pairs;
                moldCreate.WorkingDay = window.mold.WorkingDay;
                moldCreate.FinishDate = window.mold.FinishDate;

                currentMoldList.Add(moldCreate);
                sizeNoClickedList.AddRange(window.sizeRunListClicked.Select(s => s.SizeNo));

                ShowData(currentMoldList);
            }
        }

        private void ShowData(List<Mold> sourceList)
        {
            dgCurrentMold.ItemsSource = null;
            foreach (var mold in sourceList)
            {
                mold.FinishDateBackground = Brushes.Transparent;
                if (mold.FinishDate > mold.RequestDate)
                {
                    mold.FinishDateBackground = Brushes.Red;
                }
            }
            dgCurrentMold.ItemsSource = sourceList;
        }

        private void cbOutsoleCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cbOutsoleClicked = sender as ComboBox;
            if (cbOutsoleClicked == null)
                return;
            orderClicked = cbOutsoleClicked.SelectedItem as Order;
            dpRequestDate.SelectedDate = orderClicked.CSD.Value.Date;
            ComboboxChanged();
        }
        private void cbSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cbSupllierClicked = sender as ComboBox;
            if (cbSupllierClicked == null)
                return;
            supplierClicked = cbSupllierClicked.SelectedItem as Supplier;
            ComboboxChanged();
        }
        private void cbComponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cbComponentClicked = sender as ComboBox;
            if (cbComponentClicked == null)
                return;
            componentClicked = cbComponentClicked.SelectedItem as ComponentShoe;
            ComboboxChanged();
        }
        private void ComboboxChanged()
        {
            currentMoldList = new List<Mold>();
            sizeNoClickedList = new List<String>();
            txtQuota.Clear();
            btnAddMold.Content = String.Format("Add a mold for\n{0}\n{1}\n{2}", orderClicked.OutsoleCode,
                                                                                     componentClicked.ComponentName,
                                                                                     supplierClicked.SupplierName);
        }

        private void btnOptionRequestDate_Click(object sender, RoutedEventArgs e)
        {
            popOptionRequestDate.IsOpen = true;
        }
        private void btnClosePopUp_Click(object sender, RoutedEventArgs e)
        {
            popOptionRequestDate.IsOpen = false;
        }
        private void btnOptioRequestDatePlus21_Click(object sender, RoutedEventArgs e)
        {
            popOptionRequestDate.IsOpen = false;
            dpRequestDate.SelectedDate = orderClicked.CSD.Value.AddDays(21);
        }
        private void btnOptioRequestDatePlus25_Click(object sender, RoutedEventArgs e)
        {
            popOptionRequestDate.IsOpen = false;
            dpRequestDate.SelectedDate = orderClicked.CSD.Value.AddDays(25);
        }
        private void btnOptioRequestDatePlus30_Click(object sender, RoutedEventArgs e)
        {
            popOptionRequestDate.IsOpen = false;
            dpRequestDate.SelectedDate = orderClicked.CSD.Value.AddDays(30);
        }

        private void dgCurrentMold_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var itemClicked = dgCurrentMold.CurrentItem as Mold;
            if (itemClicked == null)
                return;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
