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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {
        public Employee()
        {
            InitializeComponent();
            DataContext = this;
            DataGridEmp.ItemsSource = SourceCore.DB.employee.ToList();
            ComboBoxDep.ItemsSource = SourceCore.DB.department.ToList();
            ComboBoxPos.ItemsSource = SourceCore.DB.positions.ToList();
        }

        private void AddEmp_click(object sender, RoutedEventArgs e)
        {
            if (ChangeColumn.Width.Value == 0)
            {
                ChangeColumn.Width = new GridLength(250);
                SplitterColumn.Width = GridLength.Auto;
                if ((sender as Button).Content.ToString() == "Новый сотрудник")
                {
                    DataGridEmp.SelectedItem = null;
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

        private void CommitButtonEmp(object sender, RoutedEventArgs e)
        {
            if (DataGridEmp.SelectedItem == null)
            {
                var A = new Data.employee();
                A.surname = SurnameTextBox.Text;
                A.patronymic = PatronymicTextBox.Text;
                A.name = NameTextBox.Text;
                A.telephone = TelephoneTextBox.Text;
             //   A.date_of_employment = DateBox.Text;
                A.department = (Data.department)ComboBoxDep.SelectedItem;
                A.positions = (Data.positions)ComboBoxPos.SelectedItem;
                SourceCore.DB.employee.Add(A);
            }

            SourceCore.DB.SaveChanges();
            CloseEdChangeClick(sender, e);
        }


        private void DeleteEmp_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                SourceCore.DB.employee.Remove((Data.employee)DataGridEmp.SelectedItem);
                SourceCore.DB.SaveChanges();
            }
        }
    }
}
