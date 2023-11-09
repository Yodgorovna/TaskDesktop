using Product.Desktop.Dtos;
using Product.Desktop.Interfaces;
using Product.Desktop.Services;
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

namespace Product.Desktop.windows
{
    /// <summary>
    /// Interaction logic for ProductCreateWindow.xaml
    /// </summary>
    public partial class ProductCreateWindow : Window
    {
        private IProductService _productService;
        public const string Ok_Hand = "👌";
        public const string Revolving_Hearts = "💞";
        public ProductCreateWindow()
        {
            InitializeComponent();
            this._productService = new ProductService();
        }

        private async void create_product(object sender, RoutedEventArgs e)
        {
            if (txt_brand.Text.Length > 0 && txt_name.Text.Length > 0 && txt_price.Text.Length > 0 && txt_type.Text.Length > 0)
            {
                ProductCreateDto productCreateDto = new ProductCreateDto()
                {
                    Name = txt_name.Text,
                    Type = txt_type.Text,
                    Brand = txt_brand.Text,
                    Price = Convert.ToDouble(txt_price.Text),
                };
                
                var result = await _productService.CreateAsync(productCreateDto);

                if (result > 0)
                {
                    MessageBox.Show(Ok_Hand);
                    MessageBox.Show(Revolving_Hearts);
                }
                else
                    MessageBox.Show(Revolving_Hearts);


            }
        }

        private void btnCreate_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
