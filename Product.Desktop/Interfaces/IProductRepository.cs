using Product.Desktop.Dtos;
using Product.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Desktop.Interfaces
{
    public interface IProductRepository
    {
        public Task<int> CreateAsync(ProductCreateDto dto);
        public Task<int> UpdateAsync(ProductUpdateDto dto);
        public Task<int> DeleteAsync(long Id);
        public Task<IList<ProductViewModel>> GetAllAsync();
    }
}
