using Product.Desktop.API;
using Product.Desktop.Dtos;
using Product.Desktop.Interfaces;
using Product.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public Task<int> DeleteAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ProductViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(ProductUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
