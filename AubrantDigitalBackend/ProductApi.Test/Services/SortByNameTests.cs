using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Test.Services
{
    public class SortByNameTests
    {
        [Fact]
        public void Sort_ShouldSortByNameAscending()
        {
            var products = new List<Product>
        {
            new Product { Name = "Table", Price = 29.99m, Qty = 4 },
            new Product { Name = "Chair", Price = 9.99m, Qty = 7 },
            new Product { Name = "Bench", Price = 29.99m, Qty = 3 }
        };

            var sorter = new SortByName();
            var sortedProducts = sorter.Sort(products).ToList();

            Assert.Equal("Bench", sortedProducts[0].Name);
            Assert.Equal("Chair", sortedProducts[1].Name);
            Assert.Equal("Table", sortedProducts[2].Name);
        }
    }
}
