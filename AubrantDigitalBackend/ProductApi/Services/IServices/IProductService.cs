using ProductApi.Enums;
using ProductApi.DTOs;

namespace ProductApi.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts(SortBy sortBy,SortOrder sortOrder, int take, int skip);
    }
}
