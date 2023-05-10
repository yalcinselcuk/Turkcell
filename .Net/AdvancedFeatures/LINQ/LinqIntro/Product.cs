using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqIntro
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }

    public class ProductService 
    {
        private List<Product> products;

        public ProductService() 
        {
            products = new() {
                new(){Id = 1, Name = "Bisiklet", Description = "Spor Amaçlı", Price = 3000, Stock=150},
                new(){Id = 2, Name = "Dambıl Set", Description = "Spor Amaçlı", Price = 250, Stock=150},
                new(){Id = 3, Name = "Şort", Description = "Giyim Amaçlı", Price = 570, Stock=150},
                new(){Id = 4, Name = "Tişört", Description = "Spor Amaçlı", Price = 150, Stock=50},
                new(){Id = 5, Name = "Çadır", Description = "Kampçılık Amaçlı", Price = 5000, Stock=150},
                new(){Id = 6, Name = "Olta", Description = "Keyif Amaçlı", Price = 2500, Stock=15},
                new(){Id = 7, Name = "Eldiven", Description = "Spor Amaçlı", Price = 500, Stock=150},
            };
        }

        public List<Product> GetProducts()
        {
            return products;
            
        }
    }
}
