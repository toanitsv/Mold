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
using MoldCalculator.Controllers;
using MoldCalculator.Models;

namespace MoldCalculator.Views
{
    /// <summary>
    /// Interaction logic for SupplierWindow.xaml
    /// </summary>
    public partial class SupplierWindow : Window
    {
        BackgroundWorker bwLoad;
        BackgroundWorker bwSave;
        BackgroundWorker bwRemove;
        List<Supplier> supplierCurrentList;
        List<Supplier> supplierToRemoveList;
        Supplier supplier;
        Supplier supplierClicked;

        int supplierStartID = 1611;
        bool insertOrUpdate = true;

        public SupplierWindow()
        {
            bwLoad = new BackgroundWorker();
            bwLoad.DoWork += bwLoad_DoWork;
            bwLoad.RunWorkerCompleted += bwLoad_RunWorkerCompleted;

            bwSave = new BackgroundWorker();
            bwSave.DoWork += bwSave_DoWork;
            bwSave.RunWorkerCompleted += bwSave_RunWorkerCompleted;

            bwRemove = new BackgroundWorker();
            bwRemove.DoWork += bwRemove_DoWork;
            bwRemove.RunWorkerCompleted += bwRemove_RunWorkerCompleted;

            supplierCurrentList = new List<Supplier>();
            supplierToRemoveList = new List<Supplier>();

            supplier = new Supplier();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (bwLoad.IsBusy == false)
            {
                dgSupplier.ItemsSource = null;
                txtSupplierName.Focus();
                this.Cursor = Cursors.Wait;
                bwLoad.RunWorkerAsync();
            }
        }
        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            supplierCurrentList = SupplierController.Select();
        }
        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var ran = new Random();
            txtSupplierID.Text = supplierStartID.ToString();
            ClearValue();

            if (supplierCurrentList.Count > 0)
            {
                txtSupplierID.Text = (supplierCurrentList.OrderBy(o => o.SupplierID).LastOrDefault().SupplierID + ran.Next(1, 100)).ToString();
            }

            dgSupplier.ItemsSource = supplierCurrentList;
            insertOrUpdate = true;
            NonHighlightItemClicked();

            this.Cursor = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (insertOrUpdate == true)
                GetValueFromControl(supplier);
            else
                GetValueFromControl(supplierClicked);

            if (String.IsNullOrEmpty(supplier.SupplierName) && String.IsNullOrEmpty(supplierClicked.SupplierName))
            {
                txtSupplierName.Focus();
                return;
            }

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
                SupplierController.Insert(supplier);
                supplierCurrentList.Add(supplier);
            }
            if (insertOrUpdate == false)
            {
                SupplierController.Update(supplierClicked);
                var oldSupplier = supplierCurrentList.FirstOrDefault(f => f.SupplierID == supplierClicked.SupplierID);
                if (oldSupplier != null)
                {
                    supplierCurrentList.RemoveAll(r => r.SupplierID == oldSupplier.SupplierID);
                    supplierCurrentList.Add(supplierClicked);
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

        private void miRemove_Click(object sender, RoutedEventArgs e)
        {
            supplierToRemoveList = dgSupplier.SelectedItems.OfType<Supplier>().ToList();

            if (supplierToRemoveList.Count <= 0 ||
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
            foreach (var removeItem in supplierToRemoveList)
            {
                SupplierController.Delete(removeItem.SupplierID);
                supplierCurrentList.Remove(removeItem);
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
            supplierToRemoveList.Clear();
            if (bwLoad.IsBusy == false)
            {
                bwLoad.RunWorkerAsync();
            }
        }

        private void dgSupplier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            supplierClicked = dgSupplier.CurrentItem as Supplier;
            if (supplierClicked == null)
                return;
            insertOrUpdate = false;
            InjectModelToControl(supplierClicked);
            HighlightItemClicked();
        }
        private void InjectModelToControl(Supplier supplier)
        {
            txtSupplierID.Text = supplierClicked.SupplierID.ToString();
            txtSupplierName.Text = supplierClicked.SupplierName;
            txtDescription.Text = supplierClicked.Description;
        }
        private Supplier GetValueFromControl(Supplier supplier)
        {
            supplier.SupplierID = Int32.Parse(txtSupplierID.Text);
            supplier.SupplierName = txtSupplierName.Text;
            supplier.Description = txtDescription.Text;
            supplier.CreatedTime = DateTime.Now;
            supplier.ModifiedTime = DateTime.Now;
            return supplier;
        }

        private void ClearValue()
        {
            txtDescription.Clear();
            txtSupplierName.Clear();
            txtSupplierName.Focus();
            supplier = new Supplier();
            supplierClicked = new Supplier();
        }

        private void HighlightItemClicked()
        {
            txtSupplierName.Foreground = Brushes.Blue;
            txtDescription.Foreground = Brushes.Blue;
        }
        private void NonHighlightItemClicked()
        {
            txtSupplierName.Foreground = Brushes.Black;
            txtDescription.Foreground = Brushes.Black;
        }
    }
}
