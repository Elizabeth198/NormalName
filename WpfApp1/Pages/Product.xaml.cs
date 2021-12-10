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
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        int quant;
        decimal price;
        string type;
        string supp;
        string name;
        string color;
        public Product()
        {
            InitializeComponent();
            DataContext = this;
            DataGridProduct.ItemsSource = SourceCore.DB.product.ToList();
            ComboBoxType.ItemsSource = SourceCore.DB.types_of_furniture.ToList();
            ComboBoxSupp.ItemsSource = SourceCore.DB.suppliers.ToList();
        }

        private void AddPro_click(object sender, RoutedEventArgs e)
        {
            if (ChangeColumn.Width.Value == 0)
            {
                ChangeColumn.Width = new GridLength(250);
                SplitterColumn.Width = GridLength.Auto;
                if ((sender as Button).Content.ToString() == "Добавить")
                {
                    DataGridProduct.SelectedItem = null;
                }
                if (((sender as Button).Content.ToString() == "Копировать") && (DataGridProduct.SelectedItem != null))
                {

                    quant = Int32.Parse(QuantTextBox.Text);
                    price = Decimal.Parse(PriceTextBox.Text);
                    name = NameTextBox.Text;
                    type = Convert.ToString((Data.types_of_furniture)ComboBoxType.SelectedItem);
                    supp = Convert.ToString((Data.suppliers)ComboBoxSupp.SelectedItem);
                    color = ColorTextBox.Text;
                    DataGridProduct.SelectedItem = null;
                    QuantTextBox.Text =Convert.ToString(quant);
                    PriceTextBox.Text = Convert.ToString(price) ;
                    NameTextBox.Text = name;
                    ComboBoxType.SelectedItem = type;
                    ComboBoxSupp.SelectedItem = supp;
                    DataGridProduct.IsHitTestVisible = false;
                }
            }
            else
            {
                ChangeColumn.Width = new GridLength(0);
                SplitterColumn.Width = new GridLength(0);
            }
        }

        private void DeletePro_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую книгу
                    Data.product DeletingAreas = (Data.product)DataGridProduct.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (DataGridProduct.SelectedIndex < DataGridProduct.Items.Count - 1)
                    {
                        DataGridProduct.SelectedIndex++;
                    }
                    else
                    {
                        if (DataGridProduct.SelectedIndex > 0)
                        {
                            DataGridProduct.SelectedIndex--;
                        }
                    }
                    Data.product SelectingArea = (Data.product)DataGridProduct.SelectedItem;
                    DataGridProduct.SelectedItem = DeletingAreas;
                    SourceCore.DB.product.Remove(DeletingAreas);
                    SourceCore.DB.SaveChanges();
                    UpdateGrid(SelectingArea);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
                DataGridProduct.Focus();
            }
        }
        public void UpdateGrid(Data.product Pro)
        {
            if ((Pro == null) && (DataGridProduct.ItemsSource != null))
            {
                Pro = (Data.product)DataGridProduct.SelectedItem;
            }
            DataGridProduct.ItemsSource = SourceCore.DB.product.ToList();
            DataGridProduct.SelectedItem = Pro;
        }


        private void CommitButtonPro(object sender, RoutedEventArgs e)
        {
            if (DataGridProduct.SelectedItem == null)
            {
                var A = new Data.product();
                A.name_product = NameTextBox.Text;
                A.price =decimal.Parse (PriceTextBox.Text);
                A.quantity_product = Int32.Parse(QuantTextBox.Text);
                A.color = ColorTextBox.Text;
                A.types_of_furniture = (Data.types_of_furniture)ComboBoxType.SelectedItem;
                A.suppliers = (Data.suppliers)ComboBoxSupp.SelectedItem;

                SourceCore.DB.product.Add(A);

            }
            SourceCore.DB.SaveChanges();
            CloseEdChangeClick(sender, e);
        }

        private void CloseEdChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeColumn.Width = new GridLength(0);
            SplitterColumn.Width = new GridLength(0);
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
                    DataGridProduct.ItemsSource = SourceCore.DB.product.Where(filtercase => filtercase.color.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    DataGridProduct.ItemsSource = SourceCore.DB.product.Where(filtercase => filtercase.name_product.Contains(textbox.Text)).ToList();
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
            for (int I = 0; I < 2; I++)
            {
                Columns.Add(DataGridProduct.Columns[I].Header.ToString());
            }
            TypeObjectsFilterComboBox.ItemsSource = Columns;
            TypeObjectsFilterComboBox.SelectedIndex = 0;
            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in DataGridProduct.Columns)
            {
                Column.CanUserSort = false;
            }
        }
    }

}
