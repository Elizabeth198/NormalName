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
        public TypeOfFurniture()
        {
            InitializeComponent();
            DataContext = this;
            DataGridType.ItemsSource = SourceCore.DB.types_of_furniture.ToList();
        }
    }
}
