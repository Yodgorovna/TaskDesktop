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

namespace Product.Desktop
{
    /// <summary>
    /// Interaction logic for Asosiy.xaml
    /// </summary>
    public partial class Asosiy : Window
    {
        public Asosiy()
        {
            InitializeComponent();
        }

        private void btnRefresh(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
        }
    }
}
