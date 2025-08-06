using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : EntityBase
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public Rating Rating { get; set; } 
        public Guid RatingId { get; set; } 
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }

    public class Rating : EntityBase
    {
        public decimal Rate { get; set; }
        public int Count { get; set; }
    }
}
