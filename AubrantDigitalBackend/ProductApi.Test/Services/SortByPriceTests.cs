using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Test.Services
{
    public class SortByPriceTests
    {
        [Fact]
        public void Sort_ShouldSortByPriceAscending()
        {
            var products = new List<Product>
        {
            new Product { Name = "Table", Price = 50m, Qty = 4 },
            new Product { Name = "Chair", Price = 10m, Qty = 7 },
            new Product { Name = "Bench", Price = 30m, Qty = 3 }
        };

            var sorter = new SortByPrice();
            var sortedProducts = sorter.Sort(products).ToList();

            Assert.Equal(10m, sortedProducts[0].Price);
            Assert.Equal(30m, sortedProducts[1].Price);
            Assert.Equal(50m, sortedProducts[2].Price);
        }
    }
}
