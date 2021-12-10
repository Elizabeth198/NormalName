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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for RegistrForm.xaml
    /// </summary>
    public partial class RegistrForm : Window
    {
        private Data.Furnirure_salon_Pershina1 Database;
        public RegistrForm(Data.Furnirure_salon_Pershina1 Database)
        {
            InitializeComponent();
            this.Database = Database;
        }

        public RegistrForm()
        {
            InitializeComponent();
        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            String Password = PasswordPasswordBox.Password;
            Visibility Visibility = PasswordPasswordBox.Visibility;
            double Width = PasswordPasswordBox.ActualWidth;
            // Изменение подписи на кнопке
            PasswordButton.Content = Visibility == Visibility.Visible ? "Скрыть" : "Показать";
            // Переброска информации из TextBox'а в PasswordBox
            PasswordPasswordBox.Password = PasswordTextBox.Text;
            PasswordPasswordBox.Visibility = PasswordTextBox.Visibility;
            PasswordPasswordBox.Width = PasswordTextBox.Width;
            // Возврат информации из временных буферов в TextBox
            PasswordTextBox.Text = Password;
            PasswordTextBox.Visibility = Visibility;
            PasswordTextBox.Width = Width;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание и инициализация нового пользователя системы
            Data.registration User = new Data.registration();
            User.name = LoginTextBox.Text;
            User.PASSWORD_N = PasswordPasswordBox.Password != "" ? PasswordPasswordBox.Password : PasswordTextBox.Text;
            User.role = 0;
            // Добавление его в базу данных
            Database.registration.Add(User);
            // Сохранение изменений
            Database.SaveChanges();
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
