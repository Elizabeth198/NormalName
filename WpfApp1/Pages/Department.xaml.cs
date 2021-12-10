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
        string type_dep;
        public Department()
        {
            InitializeComponent();
            DataContext = this;
            DataGridDep.ItemsSource = SourceCore.DB.department.ToList();
        }


        private void CloseEdChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(0);
            SplitterColumn.Width = new GridLength(0);
            DataGridDep.IsHitTestVisible = true;
        }

        private void AddDep_Click(object sender, RoutedEventArgs e)
        {
            if (ChangeColumn.Width.Value == 0)
            {
                ChangeColumn.Width = new GridLength(250);
                SplitterColumn.Width = GridLength.Auto;
                if ((sender as Button).Content.ToString() == "Добавить")
                {
                    DataGridDep.SelectedItem = null;
                }
                if (((sender as Button).Content.ToString() == "Копировать") && (DataGridDep.SelectedItem != null))
                {
                    type_dep = nameTextBox.Text;
                    DataGridDep.SelectedItem = null;
                    nameTextBox.Text = type_dep;
                    DataGridDep.IsHitTestVisible = false;
                }
            }
            else
            {
                ChangeColumn.Width = new GridLength(0);
                SplitterColumn.Width = new GridLength(0);
            }
        }

        private void DeleteDep_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую книгу
                    Data.department DeletingAreas = (Data.department)DataGridDep.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (DataGridDep.SelectedIndex < DataGridDep.Items.Count - 1)
                    {
                        DataGridDep.SelectedIndex++;
                    }
                    else
                    {
                        if (DataGridDep.SelectedIndex > 0)
                        {
                            DataGridDep.SelectedIndex--;
                        }
                    }
                    Data.department SelectingArea = (Data.department)DataGridDep.SelectedItem;
                    DataGridDep.SelectedItem = DeletingAreas;
                    SourceCore.DB.department.Remove(DeletingAreas);
                    SourceCore.DB.SaveChanges();
                    UpdateGrid(SelectingArea);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                DataGridDep.Focus();
            }
        }
        public void UpdateGrid(Data.department Dep)
        {
            if ((Dep == null) && (DataGridDep.ItemsSource != null))
            {
                Dep = (Data.department)DataGridDep.SelectedItem;
            }
            DataGridDep.ItemsSource = SourceCore.DB.department.ToList();
            DataGridDep.SelectedItem = Dep;
        }

        private void CommitButtonDep(object sender, RoutedEventArgs e)
        {
            if (DataGridDep.SelectedItem == null)
            {
                if (nameTextBox.Text != "")
                {
                 var A = new Data.department();
                 A.name_department = nameTextBox.Text;
                 SourceCore.DB.department.Add(A);
                }
                   
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
            for (int I = 0; I < 1; I++)
            {
                Columns.Add(DataGridDep.Columns[I].Header.ToString());
            }
            TypeObjectsFilterComboBox.ItemsSource = Columns;
            TypeObjectsFilterComboBox.SelectedIndex = 0;
            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in DataGridDep.Columns)
            {
                Column.CanUserSort = false;
            }
        }

        private void TypeObjectsFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //BooksViewModel.View.Refresh();
            var textbox = sender as TextBox;
            switch (TypeObjectsFilterComboBox.SelectedIndex)
            {
                case 0:
                    DataGridDep.ItemsSource = SourceCore.DB.department.Where(filtercase => filtercase.name_department.Contains(textbox.Text)).ToList();
                    break;
            }
        }

        private void TypeObjectsFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
