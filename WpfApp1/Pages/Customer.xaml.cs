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
        string surname;
        string patronymic;
        string name;
        string telephone;
        string adress;
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
                if ((sender as Button).Content.ToString() == "Добавить")
                {
                    DataGridCustomers.SelectedItem = null;
                }
                if (((sender as Button).Content.ToString() == "Копировать") && (DataGridCustomers.SelectedItem != null))
                {
                   
                   surname = SurnameTextBox.Text;
                   patronymic = PatronymicTextBox.Text;
                   name = NameTextBox.Text;
                   telephone = TelephoneTextBox.Text;
                   adress = AdressTextBox.Text;
                   DataGridCustomers.SelectedItem = null;
                    SurnameTextBox.Text = surname;
                    PatronymicTextBox.Text = patronymic;
                    NameTextBox.Text = name;
                    TelephoneTextBox.Text = telephone;
                    AdressTextBox.Text = adress;
                    DataGridCustomers.IsHitTestVisible = false;
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
            ChangeColumnTwo.Width = new GridLength(0);
            SplitterColumnTwo.Width = new GridLength(0);
            
        }
        private void Delete_Cust(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую книгу
                    Data.customers DeletingAreas = (Data.customers)DataGridCustomers.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (DataGridCustomers.SelectedIndex < DataGridCustomers.Items.Count - 1)
                    {
                        DataGridCustomers.SelectedIndex++;
                    }
                    else
                    {
                        if (DataGridCustomers.SelectedIndex > 0)
                        {
                            DataGridCustomers.SelectedIndex--;
                        }
                    }
                    Data.customers SelectingArea = (Data.customers)DataGridCustomers.SelectedItem;
                    DataGridCustomers.SelectedItem = DeletingAreas;
                    SourceCore.DB.customers.Remove(DeletingAreas);
                    SourceCore.DB.SaveChanges();
                    UpdateGrid(SelectingArea);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                DataGridCustomers.Focus();
            }
        }
        public void UpdateGrid(Data.customers Cus)
        {
            if ((Cus == null) && (DataGridCustomers.ItemsSource != null))
            {
                Cus = (Data.customers)DataGridCustomers.SelectedItem;
            }
            DataGridCustomers.ItemsSource = SourceCore.DB.customers.ToList();
            DataGridCustomers.SelectedItem = Cus;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Первоначальная настройка фильтра данных для быстрого поиска,
            // при этом из фильтрации нужно исключить столбец "Управление"
            // Создание собствнного списка заголовков столбцов
            List<String> Columns = new List<string>();
            // Перебор и добавление в новый список только необходимых заголовков
            // Исключен столбец 4
            for (int I = 0; I < 4; I++)
            {
                Columns.Add(DataGridCustomers.Columns[I].Header.ToString());
            }
            TypeObjectsFilterComboBox.ItemsSource = Columns;
            TypeObjectsFilterComboBox.SelectedIndex = 0;
            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in DataGridCustomers.Columns)
            {
                Column.CanUserSort = false;
            }
        }

        private void TypeObjectsFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TypeObjectsFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //BooksViewModel.View.Refresh();
            var textbox = sender as TextBox;
            switch (TypeObjectsFilterComboBox.SelectedIndex)
            {
                case 0:
                    DataGridCustomers.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.surname.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    DataGridCustomers.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.name.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    DataGridCustomers.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.patronymic.Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    DataGridCustomers.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.adress.Contains(textbox.Text)).ToList();
                    break;
                case 4:
                    DataGridCustomers.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.telephone.Contains(textbox.Text)).ToList();
                    break;
            }
        }
    }
}
