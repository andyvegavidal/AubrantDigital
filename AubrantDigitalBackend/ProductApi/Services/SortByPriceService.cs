using ProductApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Services
{
    public class SortByPrice : ISortingService
    {
        public IEnumerable<Product> Sort(IEnumerable<Product> products)
        {
            return products.OrderBy(p => p.Price);
        }
    }
}
