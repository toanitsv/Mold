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
    /// Interaction logic for ComponentWindow.xaml
    /// </summary>
    public partial class ComponentWindow : Window
    {
        BackgroundWorker bwLoad;
        BackgroundWorker bwSave;
        BackgroundWorker bwRemove;
        List<ComponentShoe> componentCurrentList;
        List<ComponentShoe> componentToRemoveList;
        ComponentShoe component;
        ComponentShoe componentClicked;

        int supplierStartID = 8319;
        bool insertOrUpdate = true;

        public ComponentWindow()
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

            componentCurrentList = new List<ComponentShoe>();
            componentToRemoveList = new List<ComponentShoe>();

            component = new ComponentShoe();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (bwLoad.IsBusy == false)
            {
                dgComponent.ItemsSource = null;
                txtComponentName.Focus();
                this.Cursor = Cursors.Wait;
                bwLoad.RunWorkerAsync();
            }
        }
        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            componentCurrentList = ComponentController.Select();
        }
        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var ran = new Random();
            txtComponentID.Text = supplierStartID.ToString();
            ClearValue();
            if (componentCurrentList.Count > 0)
            {
                txtComponentID.Text = (componentCurrentList.OrderBy(o => o.ComponentID).LastOrDefault().ComponentID + ran.Next(1, 200)).ToString();
            }

            dgComponent.ItemsSource = componentCurrentList;
            insertOrUpdate = true;
            NonHighlightItemClicked();

            this.Cursor = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (insertOrUpdate == true)
                GetValueFromControl(component);
            else
                GetValueFromControl(componentClicked);

            if (String.IsNullOrEmpty(component.ComponentName) && String.IsNullOrEmpty(componentClicked.ComponentName))
            {
                txtComponentName.Focus();
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
                ComponentController.Insert(component);
                componentCurrentList.Add(component);
            }
            if (insertOrUpdate == false)
            {
                ComponentController.Update(componentClicked);
                var oldComponent = componentCurrentList.FirstOrDefault(f => f.ComponentID == componentClicked.ComponentID);
                if (oldComponent != null)
                {
                    componentCurrentList.RemoveAll(r => r.ComponentID == oldComponent.ComponentID);
                    componentCurrentList.Add(componentClicked);
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
            componentToRemoveList = dgComponent.SelectedItems.OfType<ComponentShoe>().ToList();

            if (componentToRemoveList.Count <= 0 ||
                MessageBox.Show("Confirm Remove?", "Mold-Calculator", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
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
            foreach (var removeItem in componentToRemoveList)
            {
                ComponentController.Delete(removeItem.ComponentID);
                componentCurrentList.Remove(removeItem);
            }
        }
        private void bwRemove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled != null || e.Error != null)
            {
                
            }

            this.Cursor = null;
            miRemove.IsEnabled = true;
            componentToRemoveList.Clear();
            if (bwLoad.IsBusy == false)
            {
                bwLoad.RunWorkerAsync();
            }
        }

        private void dgComponent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            componentClicked = dgComponent.CurrentItem as ComponentShoe;
            if (componentClicked == null)
                return;
            insertOrUpdate = false;
            InjectValueToControl(componentClicked);
            HighlightItemClicked();
        }
        private void InjectValueToControl(ComponentShoe component)
        {
            txtComponentID.Text = componentClicked.ComponentID.ToString();
            txtComponentName.Text = componentClicked.ComponentName;
            txtDescription.Text = componentClicked.Description;
        }
        private ComponentShoe GetValueFromControl(ComponentShoe component)
        {
            component.ComponentID = Int32.Parse(txtComponentID.Text);
            component.ComponentName = txtComponentName.Text;
            component.Description = txtDescription.Text;
            component.CreatedTime = DateTime.Now;
            component.ModifiedTime = DateTime.Now;
            return component;
        }
        private void ClearValue()
        {
            txtComponentName.Focus();

            txtComponentName.Clear();
            txtDescription.Clear();

            component = new ComponentShoe();
            componentClicked = new ComponentShoe();
        }
        private void HighlightItemClicked()
        {
            txtComponentName.Foreground = Brushes.Blue;
            txtDescription.Foreground = Brushes.Blue;
        }
        private void NonHighlightItemClicked()
        {
            txtComponentName.Foreground = Brushes.Black;
            txtDescription.Foreground = Brushes.Black;
        }
    }
}
