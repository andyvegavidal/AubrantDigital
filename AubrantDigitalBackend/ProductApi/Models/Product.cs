using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductApi.Models
{
    [XmlRoot("inventory")]
    public class Inventory
    {
        [XmlArray("products")]
        [XmlArrayItem("product")]
        public List<Product>? Products { get; set; }
    }

    public class Product
    {
        [XmlAttribute("name")]
        public required string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("qty")]
        public int Qty { get; set; }
    }
}
