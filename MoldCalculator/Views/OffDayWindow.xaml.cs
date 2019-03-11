using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MoldCalculator.Views
{
    /// <summary>
    /// Interaction logic for OffDayWindow.xaml
    /// </summary>
    public partial class OffDayWindow : Window
    {
        BackgroundWorker bwLoad;
        BackgroundWorker bwSave;
        BackgroundWorker bwRemove;

        List<Supplier> supplierDefaultList;
        List<Supplier> supplierCurrentList;

        List<OffDay> offDayCurrentList;
        List<OffDay> offDayToRemoveList;

        List<OffDay_Supplier_Mapping> offDayMapList;

        OffDay offDay;
        OffDay offDayCurrent;

        bool insertOrUpdate = true;
        int offDayIDStart = 4815;
        public OffDayWindow()
        {
            bwLoad = new BackgroundWorker();
            bwLoad.DoWork += bwLoad_DoWork;
            bwLoad.RunWorkerCompleted += bwLoad_RunWorkerCompleted;

            bwSave = new BackgroundWorker();
            bwSave.DoWork += bwSave_DoWork;
            bwSave.RunWorkerCompleted += bwSave_RunWorkerCompleted;

            bwRemove = new BackgroundWorker();
            bwRemove.RunWorkerCompleted += bwRemove_RunWorkerCompleted;
            bwRemove.DoWork += bwRemove_DoWork;

            supplierDefaultList = new List<Supplier>();
            supplierCurrentList = new List<Supplier>();

            offDayCurrentList = new List<OffDay>();
            offDayMapList = new List<OffDay_Supplier_Mapping>();

            offDay = new OffDay();
            offDayCurrent = new OffDay();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpSelectOffDay.SelectedDate = DateTime.Now.Date;
            if (bwLoad.IsBusy == false)
            {
                dgOffDay.ItemsSource = null;
                this.Cursor = Cursors.Wait;
                bwLoad.RunWorkerAsync();
            }
        }
        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            supplierDefaultList = SupplierController.Select();
            offDayCurrentList = OffDayController.Select();
        }

        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var ran = new Random();
            txtID.Text = offDayIDStart.ToString();

            ClearValue();
            if (offDayCurrentList.Count() > 0)
            {
                txtID.Text = (offDayCurrentList.OrderBy(o => o.OffDayID).LastOrDefault().OffDayID + ran.Next(34, 1700)).ToString();
            }

            LoadSupplier(supplierDefaultList);
            supplierCurrentList.Clear();
            supplierCurrentList.AddRange(supplierDefaultList);
            dgOffDay.ItemsSource = offDayCurrentList;

            insertOrUpdate = true;
            btnSave.IsEnabled = true;
            NonHighlightItemClicked();

            this.Cursor = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (insertOrUpdate == true)
                GetValueFromControl(offDay);
            else
                GetValueFromControl(offDayCurrent);

            if (bwSave.IsBusy == false)
            {
                this.Cursor = Cursors.Wait;
                btnSave.IsEnabled = false;
                bwSave.RunWorkerAsync();
            }
        }

        private void bwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            if (insertOrUpdate == true)
            {
                OffDayController.Insert(offDay);
                offDayCurrentList.Add(offDay);

                foreach (var supp in supplierCurrentList)
                {
                    var offDayMapInsert = new OffDay_Supplier_Mapping()
                    {
                        SupplierID = supp.SupplierID,
                        OffDayID = offDay.OffDayID
                    };
                    OffDayMapController.Insert(offDayMapInsert);
                }
            }
            if (insertOrUpdate == false)
            {
                // Update OffDay
                OffDayController.Update(offDayCurrent);

                // Delete OffDayMap
                RemoveOffDayMap(offDayCurrent.OffDayID);
                // Insert OffDayMap
                foreach (var supp in supplierCurrentList)
                {
                    var offDayMapInsert = new OffDay_Supplier_Mapping()
                    {
                        SupplierID = supp.SupplierID,
                        OffDayID = offDayCurrent.OffDayID
                    };
                    OffDayMapController.Insert(offDayMapInsert);
                }
            }
        }

        private void bwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled != null || e.Error != null)
            {
                // show error
            }
            btnSave.IsEnabled = true;
            if (bwLoad.IsBusy == false)
            {
                this.Cursor = Cursors.Wait;
                bwLoad.RunWorkerAsync();
            }
        }

        private void dgOffDay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            offDayCurrent = dgOffDay.CurrentItem as OffDay;
            if (offDayCurrent == null)
                return;
            insertOrUpdate = false;
            InjectModelToControl(offDayCurrent);
            HighlightItemClicked();

            var offDayMapClickedList = OffDayMapController.Select().Where(w => w.OffDayID == offDayCurrent.OffDayID).ToList();
            var supplierID_OffDayMapClickedList = offDayMapClickedList.Select(s => s.SupplierID).Distinct().ToList();
            var supplier_OffDayMapClicked = supplierDefaultList.Where(w => supplierID_OffDayMapClickedList.Contains(w.SupplierID)).ToList();
            supplierCurrentList.Clear();
            supplierCurrentList.AddRange(supplier_OffDayMapClicked);

            LoadSupplier(supplierCurrentList);
        }

        private void miRemove_Click(object sender, RoutedEventArgs e)
        {
            offDayToRemoveList = dgOffDay.SelectedItems.OfType<OffDay>().ToList();

            if (offDayToRemoveList.Count <= 0 ||
                MessageBox.Show("Confirm Remove?", this.Title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            if (bwRemove.IsBusy == false)
            {
                miRemove.IsEnabled = false;
                this.Cursor = Cursors.Wait;
                bwRemove.RunWorkerAsync();
            }
        }

        private void bwRemove_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var removeItem in offDayToRemoveList)
            {
                // Remove offday
                OffDayController.Delete(removeItem.OffDayID);
                offDayCurrentList.Remove(removeItem);

                // Remove offdaymap by OffDayID
                RemoveOffDayMap(removeItem.OffDayID);
            }
        }

        private void RemoveOffDayMap(int offDayID)
        {
            var offDayMapList_RemoveItem = OffDayMapController.Select().Where(w => w.OffDayID == offDayID).ToList();
            if (offDayMapList_RemoveItem.Count() > 0)
            {
                foreach (var removeOffDayMap in offDayMapList_RemoveItem)
                {
                    OffDayMapController.Delete(removeOffDayMap.ID);
                }
            }
        }

        private void bwRemove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled != null || e.Error != null)
            {
                // Show Error
            }

            this.Cursor = null;
            miRemove.IsEnabled = true;
            offDayToRemoveList.Clear();
            if (bwLoad.IsBusy == false)
            {
                bwLoad.RunWorkerAsync();
            }
        }

        private void LoadSupplier(List<Supplier> supplierList)
        {
            grSupplier.Children.Clear();
            grSupplier.RowDefinitions.Clear();

            int countColumn = grSupplier.ColumnDefinitions.Count();
            int countRow = countRow = supplierList.Count / countColumn;
            if (supplierList.Count % countColumn != 0)
            {
                countRow = supplierList.Count / countColumn + 1;
            }
            for (int i = 1; i <= countRow; i++)
            {
                RowDefinition rd = new RowDefinition
                {
                    Height = new GridLength(1, GridUnitType.Star),
                };
                grSupplier.RowDefinitions.Add(rd);
            }

            for (int i = 0; i <= supplierList.Count() - 1; i++)
            {
                Grid gridSupplierDetail = new Grid();
                ColumnDefinition cdSupplier = new ColumnDefinition();
                ColumnDefinition cdRemove = new ColumnDefinition();
                cdRemove.Width = GridLength.Auto;

                gridSupplierDetail.ColumnDefinitions.Add(cdSupplier);
                gridSupplierDetail.ColumnDefinitions.Add(cdRemove);
                gridSupplierDetail.Margin = new Thickness(0, 0, 0, 5);

                Button btnSupplier = new Button();
                btnSupplier.Style = (Style)FindResource("MyButton");
                btnSupplier.Content = supplierList[i].SupplierName;
                btnSupplier.ToolTip = supplierList[i].SupplierName;

                Button btnRemoveSupplier = new Button();
                btnRemoveSupplier.Content = "X";
                btnRemoveSupplier.ToolTip = String.Format("Remove: {0}", supplierList[i].SupplierName);
                btnRemoveSupplier.Margin = new Thickness(1, 0, 5, 0);
                btnRemoveSupplier.Padding = new Thickness(4, 0, 4, 0);
                btnRemoveSupplier.Background = Brushes.Red;
                btnRemoveSupplier.Tag = supplierList[i].SupplierID;
                btnRemoveSupplier.Click += btnRemoveSupplier_Click;

                Grid.SetColumn(btnSupplier, 0);
                Grid.SetColumn(btnRemoveSupplier, 1);
                gridSupplierDetail.Children.Add(btnSupplier);
                gridSupplierDetail.Children.Add(btnRemoveSupplier);

                Grid.SetColumn(gridSupplierDetail, i % countColumn);
                Grid.SetRow(gridSupplierDetail, i / countColumn);

                grSupplier.Children.Add(gridSupplierDetail);

            }
        }

        private void btnRemoveSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (supplierCurrentList.Count() == 1)
            {
                MessageBox.Show("Supplier can not empty !", "Mold Calculator", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var buttonClicked = sender as Button;
            int supplierIDClicked = (int)buttonClicked.Tag;

            supplierCurrentList.RemoveAll(r => r.SupplierID == supplierIDClicked);
            LoadSupplier(supplierCurrentList);
        }

        private void btnApplyForAll_Click(object sender, RoutedEventArgs e)
        {
            supplierCurrentList.Clear();
            supplierCurrentList.AddRange(supplierDefaultList);

            LoadSupplier(supplierDefaultList);
        }

        private void InjectModelToControl(OffDay offDay)
        {
            txtID.Text = offDay.OffDayID.ToString();
            dpSelectOffDay.SelectedDate = offDay.OffDate.Value.Date;
            txtDescription.Text = offDay.Description;
        }
        private OffDay GetValueFromControl(OffDay offDay)
        {
            offDay.OffDayID = Int32.Parse(txtID.Text);
            offDay.OffDate = dpSelectOffDay.SelectedDate.Value.Date;
            offDay.Description = txtDescription.Text.Trim();
            offDay.CreatedTime = DateTime.Now;

            return offDay;
        }

        private void ClearValue()
        {
            txtDescription.Clear();
            dpSelectOffDay.SelectedDate = DateTime.Now.Date;

            offDay = new OffDay();
            offDayCurrent = new OffDay();
        }

        private void HighlightItemClicked()
        {
            dpSelectOffDay.Foreground = Brushes.Blue;
            txtDescription.Foreground = Brushes.Blue;
        }
        private void NonHighlightItemClicked()
        {
            dpSelectOffDay.Foreground = Brushes.Black;
            txtDescription.Foreground = Brushes.Black;
        }
    }

}
