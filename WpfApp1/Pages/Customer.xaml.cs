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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        /*private int DlgMode;
        private string Name_buf;
        private string Authors_buf;
        private string Publishers_buf;
        private string PublishYear_buf;*/


        public Customer()
        {
            InitializeComponent();
            DataContext = this;
            DataGridCustomers.ItemsSource = SourceCore.DB.customers.ToList();
        }


        private void AddCust_Click(object sender, RoutedEventArgs e)
        {
           
            if (ChangeColumn.Width.Value == 0)
            {
                ChangeColumn.Width = new GridLength(250);
                SplitterColumn.Width = GridLength.Auto;
                if ((sender as Button).Content.ToString() == "Новый клиент")
                {
                    DataGridCustomers.SelectedItem = null;
                }
            }
            else
            {
                ChangeColumn.Width = new GridLength(0);
                SplitterColumn.Width = new GridLength(0);
            }
        }

        private void CommitButtonCustomers(object sender, RoutedEventArgs e)
        {
            if (DataGridCustomers.SelectedItem == null)
            {
                var A = new Data.customers();
                A.surname = SurnameTextBox.Text;
                A.patronymic = PatronymicTextBox.Text;
                A.name = NameTextBox.Text;
                A.telephone = TelephoneTextBox.Text;
                A.adress = AdressTextBox.Text;
                SourceCore.DB.customers.Add(A);
            }
            
            SourceCore.DB.SaveChanges();
            CloseEdChangeClick(sender, e);
        }
        private void CloseEdChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(0);
            SplitterColumn.Width = new GridLength(0);
         
        }
        private void Delete_Cust(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Удалить запись?","Внимание",MessageBoxButton.OKCancel)== MessageBoxResult.OK)
            {
                SourceCore.DB.customers.Remove((Data.customers)DataGridCustomers.SelectedItem);
                SourceCore.DB.SaveChanges();
            }
        }

       

        private void CopyCust_Click(object sender, RoutedEventArgs e)
        {/*
            if (DataGridCustomers.SelectedItem != null)
            {
                DlgMode = 0;
                Label.Content = "Копировать - добавить книгу на основе выбранной";
                BookAddCommit.Content = "Копировать книгу";
                BookDataGrid.IsHitTestVisible = false;
                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                Name_buf = BookTextName.Text;
                Authors_buf = BookTextAuthors.Text;
                Publishers_buf = BookComboBoxPublishers.Text;
                PublishYear_buf = BookTextPublishYear.Text;
                //убрать фокус с выделенной строки
                BookDataGrid.SelectedItem = null;
                BookTextName.Text = Name_buf;
                BookTextAuthors.Text = Authors_buf;
                BookComboBoxPublishers.Text = Publishers_buf;
                BookTextPublishYear.Text = PublishYear_buf;
            }
            else
            {
                MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
            }
*/

        }
    }
}
