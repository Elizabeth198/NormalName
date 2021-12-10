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
        string surname;
        string patronymic;
        string name;
        string telephone;
        string passport_series;
        string passport_number;
        DateTime dateEmp;
        string dep;
        string pos;
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
                if ((sender as Button).Content.ToString() == "Добавить")
                {
                    DataGridEmp.SelectedItem = null;
                }
                if (((sender as Button).Content.ToString() == "Копировать") && (DataGridEmp.SelectedItem != null))
                {

                    surname = SurnameTextBox.Text;
                    patronymic = PatronymicTextBox.Text;
                    name = nameTextBox.Text;
                    telephone = TelephoneTextBox.Text;
                    passport_series = seriesTextBox.Text;
                    passport_number = numberTextBox.Text;
                    dateEmp = DateTime.Parse(DatePick.Text);
                    pos = Convert.ToString((Data.positions)ComboBoxPos.SelectedItem);
                    dep = Convert.ToString((Data.department)ComboBoxDep.SelectedItem);
                    DataGridEmp.SelectedItem = null;
                    SurnameTextBox.Text = surname;
                    PatronymicTextBox.Text = patronymic;
                    nameTextBox.Text = name;
                    DatePick.Text = Convert.ToString(dateEmp);
                    seriesTextBox.Text = passport_series;
                    numberTextBox.Text = passport_number;
                    ComboBoxDep.Text = dep;
                    ComboBoxPos.Text = pos;
                    TelephoneTextBox.Text = telephone;
                    DataGridEmp.IsHitTestVisible = false;
                }
            }
            else
            {
                ChangeColumn.Width = new GridLength(0);
                SplitterColumn.Width = new GridLength(0);
            }
        }

        private void DeleteEmp_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую книгу
                    Data.employee DeletingAreas = (Data.employee)DataGridEmp.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (DataGridEmp.SelectedIndex < DataGridEmp.Items.Count - 1)
                    {
                        DataGridEmp.SelectedIndex++;
                    }
                    else
                    {
                        if (DataGridEmp.SelectedIndex > 0)
                        {
                            DataGridEmp.SelectedIndex--;
                        }
                    }
                    Data.employee SelectingArea = (Data.employee)DataGridEmp.SelectedItem;
                    DataGridEmp.SelectedItem = DeletingAreas;
                    SourceCore.DB.employee.Remove(DeletingAreas);
                    SourceCore.DB.SaveChanges();
                    UpdateGrid(SelectingArea);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                DataGridEmp.Focus();
            }
        }
        public void UpdateGrid(Data.employee Emp)
        {
            if ((Emp == null) && (DataGridEmp.ItemsSource != null))
            {
                Emp = (Data.employee)DataGridEmp.SelectedItem;
            }
            DataGridEmp.ItemsSource = SourceCore.DB.employee.ToList();
            DataGridEmp.SelectedItem = Emp;
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
                A.name = nameTextBox.Text;
                A.date_of_employment = DateTime.Parse(DatePick.Text);
                A.passport_series = seriesTextBox.Text;
                A.passport_number = numberTextBox.Text;
                A.positions = (Data.positions)ComboBoxPos.SelectedItem;
                A.department = (Data.department)ComboBoxDep.SelectedItem;

                SourceCore.DB.employee.Add(A);

            }
            SourceCore.DB.SaveChanges();
            CloseEdChangeClick(sender, e);

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
                Columns.Add(DataGridEmp.Columns[I].Header.ToString());
            }
            TypeObjectsFilterComboBox.ItemsSource = Columns;
            TypeObjectsFilterComboBox.SelectedIndex = 0;
            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in DataGridEmp.Columns)
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
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.surname.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.patronymic.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.name.Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    DataGridEmp.ItemsSource = SourceCore.DB.employee.Where(filtercase => filtercase.telephone.Contains(textbox.Text)).ToList();
                    break;
            }
        }
    }
}
