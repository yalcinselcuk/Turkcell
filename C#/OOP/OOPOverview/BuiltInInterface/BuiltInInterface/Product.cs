using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiltInInterface
{
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public int CompareTo(Product? other)
        {
            //biz de karsilastirma yapmak icin Price'i sectik 
            if (Price > other?.Price)
            {
                return 1;
            }
            else if (Price < other?.Price)
            {
                return -1;

            }
            return 0;
        }
    }

    public class ProductCollection : IEnumerable<Product>
    {
        private List<Product> products = new List<Product>();
        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Clear()
        {
            products.Clear();
        }
        public List<Product> GetAll()
        {
            return products;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;// yield anahtarı
            }
        }

        public void SortProducts()
        {
            products.Sort(); //IComparable 'yi implement etmesi gerektiğini yazdi yoksa bu metod calismiyor
            //yani diyor ki ozelliklerden en az bir tanesini comparable etmesi gerekiyor
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
