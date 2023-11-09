using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Desktop.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }    
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
