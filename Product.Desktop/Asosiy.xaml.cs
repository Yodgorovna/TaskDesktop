using Product.Desktop.Interfaces;
using Product.Desktop.Services;
using Product.Desktop.ViewModels;
using Product.Desktop.windows;
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
        private IProductService _service;

        public Asosiy()
        {
            InitializeComponent();
            this._service = new ProductService();
        }

        private async void btnRefresh(object sender, RoutedEventArgs e)
        {
            dgProducts.Items.Clear();

            var product = await _service.GetAllAsync(1);
            for (int i = 0; i < product.Count; i++)
            {
                ProductViewModel item = new ProductViewModel();
                item.Id = product[i].Id;
                item.Name = product[i].Name;
                item.Type = product[i].Type;
                item.Brand= product[i].Brand;
                item.Price = product[i].Price;
                item.CreatedAt = product[i].CreatedAt;
                item.UpdatedAt = product[i].UpdatedAt;

                dgProducts.Items.Add(item);
            }
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            ProductCreateWindow productCreateWindow = new ProductCreateWindow();
            productCreateWindow.ShowDialog();
        }
    }
}
