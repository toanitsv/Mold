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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        BackgroundWorker bwLoad;
        BackgroundWorker bwSave;
        BackgroundWorker bwRemove;

        List<Order> orderCurrentList;
        List<Order> orderToRemoveList;

        Order order;
        Order orderClicked;

        int orderStartID = 6868;
        bool insertOrUpdate = true;

        public OrderWindow()
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

            orderCurrentList = new List<Order>();
            orderToRemoveList = new List<Order>();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (bwLoad.IsBusy == false)
            {
                dgOrder.ItemsSource = null;
                txtOutsoleCode.Focus();
                this.Cursor = Cursors.Wait;
                bwLoad.RunWorkerAsync();
            }
        }
        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            orderCurrentList = OrderController.Select();
        }
        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var ran = new Random();
            txtOrderID.Text = orderStartID.ToString();
            ClearValue();

            if (orderCurrentList.Count > 0)
            {
                txtOrderID.Text = (orderCurrentList.OrderBy(o => o.OrderID).LastOrDefault().OrderID + ran.Next(16, 1618)).ToString();
            }

            dgOrder.ItemsSource = orderCurrentList;
            insertOrUpdate = true;
            NonHighlightItemClicked();

            this.Cursor = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (insertOrUpdate == true)
                GetValueFromControl(order);
            else
                GetValueFromControl(orderClicked);

            if (String.IsNullOrEmpty(order.OutsoleCode) && String.IsNullOrEmpty(orderClicked.OutsoleCode))
            {
                txtOutsoleCode.Focus();
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
                OrderController.Insert(order);
                orderCurrentList.Add(order);
            }
            if (insertOrUpdate == false)
            {
                OrderController.Update(orderClicked);
                var oldOrder = orderCurrentList.FirstOrDefault(f => f.OrderID == orderClicked.OrderID);
                if (oldOrder != null)
                {
                    orderCurrentList.RemoveAll(r => r.OrderID == oldOrder.OrderID);
                    orderCurrentList.Add(orderClicked);
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
            orderToRemoveList = dgOrder.SelectedItems.OfType<Order>().ToList();

            if (orderToRemoveList.Count <= 0 || MessageBox.Show("Confirm Remove?", this.Title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
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
            foreach (var removeItem in orderToRemoveList)
            {
                OrderController.Delete(removeItem.OrderID);
                orderCurrentList.Remove(removeItem);
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
            orderToRemoveList.Clear();
            if (bwLoad.IsBusy == false)
            {
                bwLoad.RunWorkerAsync();
            }
        }

        private void dgOrder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            orderClicked = dgOrder.CurrentItem as Order;
            if (orderClicked == null)
                return;
            insertOrUpdate = false;
            InjectModelToControl(orderClicked);
            HighlightItemClicked();
        }

        private void InjectModelToControl(Order order)
        {
            txtOrderID.Text = order.OrderID.ToString();
            txtOutsoleCode.Text = order.OutsoleCode.ToUpper();
            txtArticle.Text = order.Article.ToUpper();
            txtShoeName.Text = order.ShoeName.ToUpper();
            txtQuantity.Text = order.Quantity.ToString();
            chkIsEnable.IsChecked = order.IsEnable;
            dpCSD.SelectedDate = order.CSD.Value.Date;
        }
        private Order GetValueFromControl(Order order)
        {
            int qty = 0;
            Int32.TryParse(txtQuantity.Text.ToString(), out qty);

            order.OrderID = Int32.Parse(txtOrderID.Text);
            order.OutsoleCode = txtOutsoleCode.Text.Trim().ToUpper();
            order.Article = txtArticle.Text.Trim().ToUpper();
            order.ShoeName = txtShoeName.Text.Trim().ToUpper();
            order.Quantity = qty;
            order.IsEnable = chkIsEnable.IsChecked;
            order.CSD = dpCSD.SelectedDate.Value.Date;
            order.CreatedTime = DateTime.Now;
            order.ModifiedTime = DateTime.Now;

            return order;
        }
        private void ClearValue()
        {
            txtOutsoleCode.Focus();

            txtOutsoleCode.Clear();
            txtArticle.Clear();
            txtShoeName.Clear();
            txtQuantity.Clear();

            dpCSD.SelectedDate = DateTime.Now.Date;
            chkIsEnable.IsChecked = true;

            order = new Order();
            orderClicked = new Order();
        }
        private void HighlightItemClicked()
        {
            txtOutsoleCode.Foreground = Brushes.Blue;
            txtArticle.Foreground = Brushes.Blue;
            txtShoeName.Foreground = Brushes.Blue;
            txtQuantity.Foreground = Brushes.Blue;

        }
        private void NonHighlightItemClicked()
        {
            txtOutsoleCode.Foreground = Brushes.Black;
            txtArticle.Foreground = Brushes.Black;
            txtShoeName.Foreground = Brushes.Black;
            txtQuantity.Foreground = Brushes.Black;
        }
    }
}
