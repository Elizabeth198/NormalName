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
    /// Interaction logic for Position.xaml
    /// </summary>
    public partial class Position : Page
    {
        string pos_type;
        public Position()
        {
            InitializeComponent();
            DataContext = this;
            DataGridPos.ItemsSource = SourceCore.DB.positions.ToList();
        }

        private void CommitButtonPos(object sender, RoutedEventArgs e)
        {
            if (DataGridPos.SelectedItem == null)
            {
                if (nameTextBox.Text != "")
                {
                    var A = new Data.positions();
                    A.name_position = nameTextBox.Text;
                    SourceCore.DB.positions.Add(A);
                }

            }
            SourceCore.DB.SaveChanges();
            CloseEdChangeClick(sender, e);
        }
    

        private void addPos_click(object sender, RoutedEventArgs e)
        {
            if (ChangeColumn.Width.Value == 0)
            {
                ChangeColumn.Width = new GridLength(250);
                SplitterColumn.Width = GridLength.Auto;
                if ((sender as Button).Content.ToString() == "Добавить")
                {
                    DataGridPos.SelectedItem = null;
                }
                if (((sender as Button).Content.ToString() == "Копировать") && (DataGridPos.SelectedItem != null))
                {
                    pos_type = nameTextBox.Text;
                    DataGridPos.SelectedItem = null;
                    nameTextBox.Text = pos_type;
                    DataGridPos.IsHitTestVisible = false;
                }
            }
            else
            {
                ChangeColumn.Width = new GridLength(0);
                SplitterColumn.Width = new GridLength(0);
            }
        }

        private void deletePos_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую книгу
                    Data.positions DeletingAreas = (Data.positions)DataGridPos.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (DataGridPos.SelectedIndex < DataGridPos.Items.Count - 1)
                    {
                        DataGridPos.SelectedIndex++;
                    }
                    else
                    {
                        if (DataGridPos.SelectedIndex > 0)
                        {
                            DataGridPos.SelectedIndex--;
                        }
                    }
                    Data.positions SelectingArea = (Data.positions)DataGridPos.SelectedItem;
                    DataGridPos.SelectedItem = DeletingAreas;
                    SourceCore.DB.positions.Remove(DeletingAreas);
                    SourceCore.DB.SaveChanges();
                    UpdateGrid(SelectingArea);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                DataGridPos.Focus();
            }
        }

        public void UpdateGrid(Data.positions Pos)
        {
            if ((Pos == null) && (DataGridPos.ItemsSource != null))
            {
                Pos = (Data.positions)DataGridPos.SelectedItem;
            }
            DataGridPos.ItemsSource = SourceCore.DB.positions.ToList();
            DataGridPos.SelectedItem = Pos;
        }

        private void CloseEdChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(0);
            SplitterColumn.Width = new GridLength(0);
           
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
                Columns.Add(DataGridPos.Columns[I].Header.ToString());
            }
            TypeObjectsFilterComboBox.ItemsSource = Columns;
            TypeObjectsFilterComboBox.SelectedIndex = 0;
            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in DataGridPos.Columns)
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
                    DataGridPos.ItemsSource = SourceCore.DB.positions.Where(filtercase => filtercase.name_position.Contains(textbox.Text)).ToList();
                    break;
            }
        }
    }
}
