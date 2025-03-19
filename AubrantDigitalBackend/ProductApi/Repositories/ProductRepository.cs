using ProductApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly string _xmlFilePath;

        public ProductRepository(IHostEnvironment environment)
        {
            _xmlFilePath = Path.Combine(environment.ContentRootPath, "Data", "products.xml");
        }

        public IEnumerable<Product> GetAll()
        {
            if (!File.Exists(_xmlFilePath))
            {
                throw new FileNotFoundException($"The XML file at {_xmlFilePath} was not found.");
            }

            using (var stream = new FileStream(_xmlFilePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                var deserializedObject = serializer.Deserialize(stream);

                if (deserializedObject is Inventory inventory)
                {
                    return inventory.Products ?? Enumerable.Empty<Product>();
                }
                else
                {
                    return Enumerable.Empty<Product>();
                }
            }
        }
    }
}
