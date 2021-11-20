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
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class Department : Page
    {
       
        public Department()
        {
            InitializeComponent();
            DataContext = this;
            DataGridDep.ItemsSource = SourceCore.DB.department.ToList();
        }

        private void AddDep_Click(object sender, RoutedEventArgs e)
        {
            
            if (ChangeColumn.Width.Value == 0)
            {
                ChangeColumn.Width = new GridLength(250);
                SplitterColumn.Width = GridLength.Auto;
                if ((sender as Button).Content.ToString() == "Новый отдел")
                {
                    DataGridDep.SelectedItem = null;
                }
            }
            else
            {
                ChangeColumn.Width = new GridLength(0);
                SplitterColumn.Width = new GridLength(0);
            }
        }

        private void CloseEdChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(0);
            SplitterColumn.Width = new GridLength(0);
            
        }

        private void DeleteDep_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                SourceCore.DB.department.Remove((Data.department)DataGridDep.SelectedItem);
                SourceCore.DB.SaveChanges();
            }
        }

        private void CommitButtonDep(object sender, RoutedEventArgs e)
        {
            if(DataGridDep.SelectedItem == null)
            {
                var A = new Data.department();
                A.name_department = DepTextBox.Text;
                SourceCore.DB.department.Add(A);
            }
            SourceCore.DB.SaveChanges();
            CloseEdChangeClick(sender, e);
        }
    }
}
