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

namespace WpfApp1
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

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new Pages.Product());
            Height = 450;
            Width = 800;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new Pages.Order());
            Height = 600;
            Width = 1300;
        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new Pages.Customer());
            Height = 450;
            Width = 800;
        }

        private void SuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new Pages.Supplier());
            Height = 450;
            Width = 800;
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new Pages.Employee());
            Height = 450;
            Width = 800;
        }

        private void TypesFurnitureButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new Pages.TypeOfFurniture());
            Height = 450;
            Width = 800;
        }

        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new Pages.Department());
            Height = 450;
            Width = 800;
        }

        private void PositionButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new Pages.Position());
            Height = 450;
            Width = 800;
        }

        private void RootFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }

        private void PreviosPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClosePageButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
