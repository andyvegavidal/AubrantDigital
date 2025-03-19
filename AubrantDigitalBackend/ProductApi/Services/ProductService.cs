using ProductApi.Models;
using ProductApi.Repositories;
using ProductApi.Enums;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using ProductApi.DTOs;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly Dictionary<SortBy, ISortingService> _sortingStrategies;
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;

            _sortingStrategies = new Dictionary<SortBy, ISortingService>
            {
                { SortBy.Name, new SortByName() },
                { SortBy.Price, new SortByPrice() },
                { SortBy.Qty, new SortByQty() }
            };
            _logger = logger;
        }

        public IEnumerable<ProductDto> GetProducts(SortBy sortBy, SortOrder sortOrder, int take, int limit)
        {
            var cacheKey = $"products_{sortBy}_{sortOrder}_{take}_{limit}";

            if (_memoryCache.TryGetValue(cacheKey, out IEnumerable<ProductDto>? cachedProducts))
            {
                _logger.LogInformation($"Cache hit for key: {cacheKey}");
                return cachedProducts ?? Enumerable.Empty<ProductDto>();
            }

            _logger.LogInformation("Data is not in the Cache, getting data from the source");
            var products = _productRepository.GetAll();

            var sortedProducts = _sortingStrategies[sortBy].Sort(products);

            if (sortOrder == SortOrder.Desc)
            {
                sortedProducts = sortedProducts.Reverse();
            }

            var paginatedProducts = sortedProducts
                .Skip(limit)
                .Take(take)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Qty = p.Qty
                })
                .ToList();

            _memoryCache.Set(cacheKey, paginatedProducts, TimeSpan.FromMinutes(_cacheSettings.ExpirationInMinutes));
            return paginatedProducts;
        }
    }
}
