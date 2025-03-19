using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Test.Services
{
    public class SortByQtyTests
    {
        [Fact]
        public void Sort_ShouldSortByQtyAscending()
        {
            var products = new List<Product>
        {
            new Product { Name = "Table", Price = 29.99m, Qty = 4 },
            new Product { Name = "Chair", Price = 9.99m, Qty = 7 },
            new Product { Name = "Bench", Price = 29.99m, Qty = 3 }
        };

            var sorter = new SortByQty();
            var sortedProducts = sorter.Sort(products).ToList();

            Assert.Equal(3, sortedProducts[0].Qty);
            Assert.Equal(4, sortedProducts[1].Qty);
            Assert.Equal(7, sortedProducts[2].Qty);
        }
    }
}
