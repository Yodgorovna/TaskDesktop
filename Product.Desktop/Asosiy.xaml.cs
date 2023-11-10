using Product.Desktop.Interfaces;
using Product.Desktop.Services;
using Product.Desktop.ViewModels;
using Product.Desktop.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Product.Desktop
{
    /// <summary>
    /// Interaction logic for Asosiy.xaml
    /// </summary>
    public partial class Asosiy : Window
    {
        private IList<ProductViewModel> searchProducts;
        private IProductService _service;
        private int page = 1;

        public Asosiy()
        {
            InitializeComponent();
            this._service = new ProductService();
        }

        private async void btnRefresh(object sender, RoutedEventArgs e)
        {
            try
            {
                dgProducts.Items.Clear();

                var product = await _service.GetAllAsync(page);
                searchProducts = new List<ProductViewModel>();
                searchProducts = await _service.GetAllAsync(1);
                for (int i = 0; i < product.Count; i++)
                {
                    ProductViewModel item = new ProductViewModel();
                    item.Id = product[i].Id;
                    item.Name = product[i].Name;
                    item.Type = product[i].Type;
                    item.Brand = product[i].Brand;
                    item.Price = product[i].Price;
                    item.CreatedAt = product[i].CreatedAt;
                    item.UpdatedAt = product[i].UpdatedAt;

                    dgProducts.Items.Add(item);
                }
            }
            catch { }
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            ProductCreateWindow productCreateWindow = new ProductCreateWindow();
            productCreateWindow.ShowDialog();
        }

        private void btnSearch(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = tbSearch.Text;
                dgProducts.Items.Clear();

                var searchGetProduct = searchProducts.Where(p =>
                    p.Id.ToString().Contains(searchTerm) ||
                    p.Name.Contains(searchTerm) ||
                    p.Type.Contains(searchTerm) ||
                    p.Price.ToString().Contains(searchTerm) ||
                    p.Brand.Contains(searchTerm) ||
                    (p.CreatedAt != null && p.CreatedAt.ToString().Contains(searchTerm)) ||
                    (p.UpdatedAt != null && p.UpdatedAt.ToString().Contains(searchTerm)))
                 .ToList();

                for (int i = 0; i < searchGetProduct.Count; i++)
                {
                    ProductViewModel item = new ProductViewModel();
                    item.Id = searchGetProduct[i].Id;
                    item.Name = searchGetProduct[i].Name;
                    item.Type = searchGetProduct[i].Type;
                    item.Brand = searchGetProduct[i].Brand;
                    item.Price = searchGetProduct[i].Price;
                    item.CreatedAt = searchGetProduct[i].CreatedAt;
                    item.UpdatedAt = searchGetProduct[i].UpdatedAt;

                    dgProducts.Items.Add(item);
                }
            }
            catch { }
        }

        private async void btnNext(object sender, RoutedEventArgs e)
        {
            try
            {
                dgProducts.Items.Clear();

                var product = await _service.GetAllAsync(page + 1);
                searchProducts = new List<ProductViewModel>();
                searchProducts = await _service.GetAllAsync(1);
                for (int i = 0; i < product.Count; i++)
                {
                    ProductViewModel item = new ProductViewModel();
                    item.Id = product[i].Id;
                    item.Name = product[i].Name;
                    item.Type = product[i].Type;
                    item.Brand = product[i].Brand;
                    item.Price = product[i].Price;
                    item.CreatedAt = product[i].CreatedAt;
                    item.UpdatedAt = product[i].UpdatedAt;

                    dgProducts.Items.Add(item);
                }
            }
            catch { }
        }

        private async void btnPervouce(object sender, RoutedEventArgs e)
        {
            dgProducts.Items.Clear();

            int pagenum = page > 1 ? (page - 1) : 1;
            var product = await _service.GetAllAsync(pagenum);
            searchProducts = new List<ProductViewModel>();
            searchProducts = await _service.GetAllAsync(1);
            for (int i = 0; i < product.Count; i++)
            {
                ProductViewModel item = new ProductViewModel();
                item.Id = product[i].Id;
                item.Name = product[i].Name;
                item.Type = product[i].Type;
                item.Brand = product[i].Brand;
                item.Price = product[i].Price;
                item.CreatedAt = product[i].CreatedAt;
                item.UpdatedAt = product[i].UpdatedAt;

                dgProducts.Items.Add(item);
            }
        }

        private async void deletedbtn(object sender, RoutedEventArgs e)
        {

            try
            {
                if (dgProducts.SelectedItems.Count == 1)
                {
                    if (dgProducts.SelectedItem != null)
                    {
                        ProductViewModel selectedItem = dgProducts.SelectedItem as ProductViewModel;

                        if (selectedItem != null)
                        {
                            var a = await _service.DeleteAsync(selectedItem.Id);
                            if (a > 0) MessageBox.Show("Malumot o'chirildi. Iltimos refresh tugmasini bosing!");
                            else MessageBox.Show("Qayerdadur xatolikga duch keldik :( ");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O'chirish uchun 1 ta mahsulotni tanlang");
                }
                
            }
            catch (Exception ex)
            {
                // Xato haqida ma'lumotni ko'rsatish
                MessageBox.Show("Xatolik: " + ex.Message);
            }

        }

        private void btnDateFilter(object sender, RoutedEventArgs e)
        {
            try
            {
                var to = dpBolshalnishVaqt.SelectedDate;
                var from = dpTugashVaqt.SelectedDate;

                var product = searchProducts
                    .Where(p => p.CreatedAt > to && p.CreatedAt < from)
                    .ToList();

                for (int i = 0; i < product.Count; i++)
                {
                    ProductViewModel item = new ProductViewModel();
                    item.Id = product[i].Id;
                    item.Name = product[i].Name;
                    item.Type = product[i].Type;
                    item.Brand = product[i].Brand;
                    item.Price = product[i].Price;
                    item.CreatedAt = product[i].CreatedAt;
                    item.UpdatedAt = product[i].UpdatedAt;

                    dgProducts.Items.Add(item);
                }
            }
            catch { }
        }
    }
}
