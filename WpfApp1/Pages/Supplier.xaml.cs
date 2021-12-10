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
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class Supplier : Page
    {
        string surname;
        string patronymic;
        string name;
        string telephone;
        string adress;
        public Supplier()
        {
            InitializeComponent();
            DataContext = this;
            DataGridSupp.ItemsSource = SourceCore.DB.suppliers.ToList();
        }

        private void CloseEdChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(0);
            SplitterColumn.Width = new GridLength(0);
        }

        private void CommitButtonSupp(object sender, RoutedEventArgs e)
        {
            if (DataGridSupp.SelectedItem == null)
            {
                var A = new Data.suppliers();
                A.surname = SurnameTextBox.Text;
                A.patronymic = PatronymicTextBox.Text;
                A.name = nameTextBox.Text;
                A.address = AdressTextBox.Text;
                SourceCore.DB.suppliers.Add(A);
            }
            SourceCore.DB.SaveChanges();
            CloseEdChangeClick(sender, e);
        }

        private void Addsupp_click(object sender, RoutedEventArgs e)
        {
            if (ChangeColumn.Width.Value == 0)
            {
                ChangeColumn.Width = new GridLength(250);
                SplitterColumn.Width = GridLength.Auto;
                if ((sender as Button).Content.ToString() == "Добавить")
                {
                    DataGridSupp.SelectedItem = null;
                }
                if (((sender as Button).Content.ToString() == "Копировать") && (DataGridSupp.SelectedItem != null))
                {

                    surname = SurnameTextBox.Text;
                    patronymic = PatronymicTextBox.Text;
                    name = nameTextBox.Text;
                    telephone = TelephoneTextBox.Text;
                    adress = AdressTextBox.Text;
                    DataGridSupp.SelectedItem = null;
                    SurnameTextBox.Text = surname;
                    PatronymicTextBox.Text = patronymic;
                    nameTextBox.Text = name;                 
                    TelephoneTextBox.Text = telephone;
                    AdressTextBox.Text = adress;
                    DataGridSupp.IsHitTestVisible = false;
                }
            }
            else
            {
                ChangeColumn.Width = new GridLength(0);
                SplitterColumn.Width = new GridLength(0);
            }
        }

        private void Deletesupp_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую книгу
                    Data.suppliers DeletingAreas = (Data.suppliers)DataGridSupp.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (DataGridSupp.SelectedIndex < DataGridSupp.Items.Count - 1)
                    {
                        DataGridSupp.SelectedIndex++;
                    }
                    else
                    {
                        if (DataGridSupp.SelectedIndex > 0)
                        {
                            DataGridSupp.SelectedIndex--;
                        }
                    }
                    Data.suppliers SelectingArea = (Data.suppliers)DataGridSupp.SelectedItem;
                    DataGridSupp.SelectedItem = DeletingAreas;
                    SourceCore.DB.suppliers.Remove(DeletingAreas);
                    SourceCore.DB.SaveChanges();
                    UpdateGrid(SelectingArea);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                DataGridSupp.Focus();
            }
        }
        public void UpdateGrid(Data.suppliers Supp)
        {
            if ((Supp == null) && (DataGridSupp.ItemsSource != null))
            {
                Supp = (Data.suppliers)DataGridSupp.SelectedItem;
            }
            DataGridSupp.ItemsSource = SourceCore.DB.suppliers.ToList();
            DataGridSupp.SelectedItem = Supp;
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
                Columns.Add(DataGridSupp.Columns[I].Header.ToString());
            }
            TypeObjectsFilterComboBox.ItemsSource = Columns;
            TypeObjectsFilterComboBox.SelectedIndex = 0;
            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in DataGridSupp.Columns)
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
                    DataGridSupp.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.surname.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    DataGridSupp.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.patronymic.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    DataGridSupp.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.name.Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    DataGridSupp.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.adress.Contains(textbox.Text)).ToList();
                    break;
                case 4:
                    DataGridSupp.ItemsSource = SourceCore.DB.customers.Where(filtercase => filtercase.telephone.Contains(textbox.Text)).ToList();
                    break;
            }
        }
    }
}
