using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        BackgroundWorker bwSaveSizeRun;
        BackgroundWorker bwRemoveSizeRun;

        List<Order> orderCurrentList;
        List<Order> orderToRemoveList;

        List<SizeRun> sizeRunList;

        List<SizeRun> sizeRunList_OutsoleCode;

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

            bwSaveSizeRun = new BackgroundWorker();
            bwSaveSizeRun.DoWork += bwSaveSizeRun_DoWork;
            bwSaveSizeRun.RunWorkerCompleted += bwSaveSizeRun_RunWorkerCompleted;

            bwRemoveSizeRun = new BackgroundWorker();
            bwRemoveSizeRun.DoWork += bwRemoveSizeRun_DoWork;
            bwRemoveSizeRun.RunWorkerCompleted += bwRemoveSizeRun_RunWorkerCompleted;

            orderCurrentList = new List<Order>();
            orderToRemoveList = new List<Order>();

            sizeRunList = new List<SizeRun>();

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
            sizeRunList = SizeRunController.Select();
        }
        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var ran = new Random();
            txtOrderID.Text = orderStartID.ToString();
            ClearValue();

            if (orderCurrentList.Count > 0)
            {
                txtOrderID.Text = (orderCurrentList.OrderBy(o => o.OrderID).LastOrDefault().OrderID + ran.Next(16, 1618)).ToString();

                cbOutsoleCode.SelectedItem = orderCurrentList.FirstOrDefault();
                cbOutsoleCode.ItemsSource = orderCurrentList;

                // Size run order first
                //sizeRunList_OutsoleCode = sizeRunList.Where(w => w.OutsoleCode == orderCurrentList.FirstOrDefault().OutsoleCode).ToList();
                //var regex = new Regex(@"[a-z]|[A-Z]");
                //sizeRunList_OutsoleCode = sizeRunList_OutsoleCode.OrderBy(o => regex.IsMatch(o.SizeNo) ? Double.Parse(regex.Replace(o.SizeNo, "100")) : Double.Parse(o.SizeNo)).ToList();
                //LoadSizeRun(sizeRunList_OutsoleCode);

                dgOrder.ItemsSource = orderCurrentList;
                insertOrUpdate = true;
                NonHighlightItemClicked();

                this.Cursor = null;
            }
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

            if (orderToRemoveList.Count <= 0 || MessageBox.Show("Confirm Remove?", "Mold-Calculator", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
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

            cbOutsoleCode.SelectedItem = orderClicked;

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

        private void btnAddSize_Click(object sender, RoutedEventArgs e)
        {
            var cbSelect = cbOutsoleCode.SelectedItem as Order;
            if (cbSelect == null)
                return;

            var sizeRunAdd = new SizeRun()
            {
                OutsoleCode = cbSelect.OutsoleCode,
                SizeNo = "SizeNo",
                CreatedTime = DateTime.Now,
                Quantity = 0
            };
            sizeRunList_OutsoleCode.Add(sizeRunAdd);
            LoadSizeRun(sizeRunList_OutsoleCode);
            scrSizeRun.ScrollToRightEnd();
        }

        private void miContextMenu_Click(object sender, RoutedEventArgs e)
        {
            var menuItemClicked = sender as MenuItem;
            if (menuItemClicked == null)
                return;

            var sizeRunRemove = menuItemClicked.Tag as SizeRun;
            if (MessageBox.Show(String.Format("Confirm Remove Size: {0}?", sizeRunRemove.SizeNo), "Mold-Calculator", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            if (bwRemoveSizeRun.IsBusy == false)
            {
                this.Cursor = Cursors.Wait;
                bwRemoveSizeRun.RunWorkerAsync(sizeRunRemove);
            }
        }

        private void bwRemoveSizeRun_DoWork(object sender, DoWorkEventArgs e)
        {
            var sizeRunRemove = e.Argument as SizeRun;
            SizeRunController.Delete(sizeRunRemove);
            sizeRunList_OutsoleCode.Remove(sizeRunRemove);
        }
        private void bwRemoveSizeRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = null;
            LoadSizeRun(sizeRunList_OutsoleCode);
        }

        private void LoadSizeRun(List<SizeRun> sizeRunAddList)
        {
            wpSizeRun.Children.Clear();
            
            foreach (var sizeRunAdd in sizeRunAddList)
            {
                List<SizeRun> itemsSource = new List<SizeRun>();
                itemsSource.Add(sizeRunAdd);

                DataGrid dgSizeRun = new DataGrid();
                dgSizeRun.HeadersVisibility = DataGridHeadersVisibility.None;
                dgSizeRun.AutoGenerateColumns = false;
                dgSizeRun.AlternationCount = 2;
                dgSizeRun.CanUserDeleteRows = true;
                dgSizeRun.CanUserAddRows = false;
                dgOrder.SelectionUnit = DataGridSelectionUnit.Cell;
                dgSizeRun.Margin = new Thickness(0, 0, 5, 0);

                var style_Size = new Style(typeof(DataGridCell));
                var setter = new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center);
                var setter_1 = new Setter(TextBlock.FontWeightProperty, FontWeights.Bold);
                style_Size.Setters.Add(setter);
                style_Size.Setters.Add(setter_1);

                var style_Qty = new Style(typeof(DataGridCell));
                style_Qty.Setters.Add(setter);

                DataGridTextColumn clSize = new DataGridTextColumn();
                clSize.Binding = new Binding("SizeNo");
                dgSizeRun.Columns.Add(clSize);
                clSize.MinWidth = 50;
                clSize.CellStyle = style_Size;

                DataGridTextColumn clQuantity = new DataGridTextColumn();
                clQuantity.Binding = new Binding("Quantity");
                clQuantity.MinWidth = 50;
                clQuantity.CellStyle = style_Qty;

                dgSizeRun.Columns.Add(clQuantity);

                ContextMenu contextMenu = new ContextMenu();
                MenuItem miContextMenu = new MenuItem();

                miContextMenu.Header = "Remove";
                miContextMenu.Tag = sizeRunAdd;
                miContextMenu.Click += miContextMenu_Click;
                contextMenu.Items.Add(miContextMenu);

                dgSizeRun.ContextMenu = contextMenu;

                dgSizeRun.ItemsSource = null;
                dgSizeRun.ItemsSource = itemsSource;

                wpSizeRun.Children.Add(dgSizeRun);
            }
        }

        private void cbOutsoleCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cbSelect = cbOutsoleCode.SelectedItem as Order;
            sizeRunList = SizeRunController.Select();

            sizeRunList_OutsoleCode = sizeRunList.Where(w => w.OutsoleCode == cbSelect.OutsoleCode).ToList();
            var regex = new Regex(@"[a-z]|[A-Z]");
            sizeRunList_OutsoleCode = sizeRunList_OutsoleCode.OrderBy(o => regex.IsMatch(o.SizeNo) ? Double.Parse(regex.Replace(o.SizeNo, "100")) : Double.Parse(o.SizeNo)).ToList();
            LoadSizeRun(sizeRunList_OutsoleCode);
        }

        private void btnSizeRunSave_Click(object sender, RoutedEventArgs e)
        {
            if (bwSaveSizeRun.IsBusy == false)
            {
                btnSizeRunSave.IsEnabled = false;
                this.Cursor = Cursors.Wait;
                bwSaveSizeRun.RunWorkerAsync();
            }
        }
        private void bwSaveSizeRun_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var sizeRun in sizeRunList_OutsoleCode)
            {
                SizeRunController.Insert(sizeRun);
            }
        }
        private void bwSaveSizeRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = null;
            btnSizeRunSave.IsEnabled = true;
            if (bwLoad.IsBusy == false)
            {
                bwLoad.RunWorkerAsync();
            }
        }  
    }
}
