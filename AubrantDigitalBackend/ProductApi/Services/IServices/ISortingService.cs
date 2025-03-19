using ProductApi.Models;
using System.Collections.Generic;

namespace ProductApi.Services
{
    public interface ISortingService
    {
        IEnumerable<Product> Sort(IEnumerable<Product> products);
    }
}
