using Newtonsoft.Json;
using Product.Desktop.API;
using Product.Desktop.Dtos;
using Product.Desktop.Interfaces;
using Product.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Product.Desktop.Services
{
    public class ProductService : IProductService
    {
        public async Task<int> CreateAsync(ProductCreateDto dto)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseAPI.BASE_URL}/api/product");
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(dto.Name), "Name");
                content.Add(new StringContent(dto.Type), "Type");
                content.Add(new StringContent((dto.Price).ToString()), "Price");
                content.Add(new StringContent(dto.Brand), "Brand");
                request.Content = content;
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"{BaseAPI.BASE_URL}" + $"/api/product/{Id}");
                var result = await client.DeleteAsync(client.BaseAddress);
                string response = await result.Content.ReadAsStringAsync();
                if(result.IsSuccessStatusCode)
                {
                    return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<IList<ProductViewModel>> GetAllAsync(int page)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"{BaseAPI.BASE_URL}" + $"/api/product?page={page}");
                HttpResponseMessage message = await client.GetAsync(client.BaseAddress);
                string response = await message.Content.ReadAsStringAsync();
                List<ProductViewModel> posts = JsonConvert.DeserializeObject<List<ProductViewModel>>(response)!;

                return posts;
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }

        public Task<int> UpdateAsync(ProductUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
