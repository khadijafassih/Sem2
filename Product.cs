using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Challenge2
{
    internal class Product
    {
        public int ID;
        public string Name;
        public double Price;
        public string Category;
        public string BrandName;
        public string Country;
        public Product(int id, string name, double price, string category, string brandName, string country)
        {
            ID = id;
            Name = name;
            Price = price;
            Category = category;
            BrandName = brandName;
            Country = country;
        }
    }
}
