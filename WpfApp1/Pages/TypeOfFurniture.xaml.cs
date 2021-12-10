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
    /// Interaction logic for TypeOfFurniture.xaml
    /// </summary>
    public partial class TypeOfFurniture : Page
    {
        string type;
        public TypeOfFurniture()
        {
            InitializeComponent();
            DataContext = this;
            DataGridType.ItemsSource = SourceCore.DB.types_of_furniture.ToList();
        }

        private void addtype_click(object sender, RoutedEventArgs e)
        {
            if (ChangeColumn.Width.Value == 0)
            {
                ChangeColumn.Width = new GridLength(250);
                SplitterColumn.Width = GridLength.Auto;
                if ((sender as Button).Content.ToString() == "Добавить")
                {
                    DataGridType.SelectedItem = null;
                }
                if (((sender as Button).Content.ToString() == "Копировать") && (DataGridType.SelectedItem != null))
                {
                    type = nameTextBox.Text;
                    DataGridType.SelectedItem = null;
                    nameTextBox.Text = type;
                    DataGridType.IsHitTestVisible = false;
                }
            }
            else
            {
                ChangeColumn.Width = new GridLength(0);
                SplitterColumn.Width = new GridLength(0);
            }
        }

        private void deletetype_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую книгу
                    Data.types_of_furniture DeletingAreas = (Data.types_of_furniture)DataGridType.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (DataGridType.SelectedIndex < DataGridType.Items.Count - 1)
                    {
                        DataGridType.SelectedIndex++;
                    }
                    else
                    {
                        if (DataGridType.SelectedIndex > 0)
                        {
                            DataGridType.SelectedIndex--;
                        }
                    }
                    Data.types_of_furniture SelectingArea = (Data.types_of_furniture)DataGridType.SelectedItem;
                    DataGridType.SelectedItem = DeletingAreas;
                    SourceCore.DB.types_of_furniture.Remove(DeletingAreas);
                    SourceCore.DB.SaveChanges();
                    UpdateGrid(SelectingArea);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                DataGridType.Focus();
            }
        }
        public void UpdateGrid(Data.types_of_furniture Type)
        {
            if ((Type == null) && (DataGridType.ItemsSource != null))
            {
                Type = (Data.types_of_furniture)DataGridType.SelectedItem;
            }
            DataGridType.ItemsSource = SourceCore.DB.types_of_furniture.ToList();
            DataGridType.SelectedItem = Type;
        }

        private void CloseEdChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(0);
            SplitterColumn.Width = new GridLength(0);
           
        }

        private void CommitButtonType(object sender, RoutedEventArgs e)
        {
            if (DataGridType.SelectedItem == null)
            {
                if (nameTextBox.Text != "")
                {
                    var A = new Data.types_of_furniture();
                    A.name = nameTextBox.Text;
                    SourceCore.DB.types_of_furniture.Add(A);
                }

            }
            SourceCore.DB.SaveChanges();
            CloseEdChangeClick(sender, e);
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
                    DataGridType.ItemsSource = SourceCore.DB.types_of_furniture.Where(filtercase => filtercase.name.Contains(textbox.Text)).ToList();
                    break;
            }
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
                Columns.Add(DataGridType.Columns[I].Header.ToString());
            }
            TypeObjectsFilterComboBox.ItemsSource = Columns;
            TypeObjectsFilterComboBox.SelectedIndex = 0;
            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in DataGridType.Columns)
            {
                Column.CanUserSort = false;
            }
        }
    }
}
