// LINQ : Language INtegrated Query
// Sorgu için entegre edilmiş dil, yapı.

// varlık sebebi bir koleksiyonlar kolayca iş yapabilmektir

using LinqIntro;

var products = new ProductService().GetProducts();

var anonymousType = new { Name = "Turkay", Age = 42 };
var nameAndPriceList = from p in products
                       where p.Price < 1000
                       select new { Ad = p.Name, Fiyat = p.Price};

nameAndPriceList.ToList().ForEach(x => Console.WriteLine($"{x.Ad   }\t{x.Fiyat}"));

var sameResultWithExt = products.Where(p => p.Price < 1000) // where metodu bir extension metodudur
                            .Select(p => new {Ad = p.Name, Fiyat = p.Price})
                            .ToList();

