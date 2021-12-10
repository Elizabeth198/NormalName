using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
            DataGridEmp.ItemsSource = SourceCore.DB.employee.ToList();
            DataGridOrd.ItemsSource = SourceCore.DB.orders.ToList();
            ComboBoxCust.ItemsSource = SourceCore.DB.customers.ToList();
            ComboBoxPro.ItemsSource = SourceCore.DB.product.ToList();
            ComboBoxEmp.ItemsSource = SourceCore.DB.employee.ToList();

        }

        private void ClickAddOrder(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(250);
            SplitterColumn.Width = new GridLength(5);
        }

        private void TestingDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void TestingDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void CloseEdChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(0);
            SplitterColumn.Width = new GridLength(0);
        }


        private void CommitButtonOrd(object sender, RoutedEventArgs e)
        {

        }
    }
}
