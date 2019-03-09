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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MoldCalculator.Views;

namespace MoldCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void miOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow window = new OrderWindow();
            window.Show();
        }

        private void miSupplier_Click(object sender, RoutedEventArgs e)
        {
            SupplierWindow window = new SupplierWindow();
            window.Show();
        }

        private void miComponent_Click(object sender, RoutedEventArgs e)
        {
            ComponentWindow window = new ComponentWindow();
            window.Show();
        }

        private void miOffDay_Click(object sender, RoutedEventArgs e)
        {
            OffDayWindow window = new OffDayWindow();
            window.Show();
        }

        private void miCreateANewSet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
