using ProductApi.Models;
using System.Collections.Generic;

namespace ProductApi.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}
