// LINQ : Language INtegrated Query
// Sorgu için entegre edilmiş dil, yapı.

// varlık sebebi bir koleksiyonlar kolayca iş yapabilmektir

using LinqIntro;
using System.Diagnostics;

var service = new ProductService();
var products = service.GetProducts();

var anonymousType = new { Name = "Turkay", Age = 42 };
var nameAndPriceList = from p in products
                       where p.Price < 1000
                       select new { Ad = p.Name, Fiyat = p.Price};

nameAndPriceList.ToList().ForEach(x => Console.WriteLine($"{x.Ad   }\t{x.Fiyat}"));


var stopWatch = Stopwatch.StartNew(); // timer'ımızı oluşturduk
var sameResultWithExt = products.Where(p => p.Price < 1000) // where metodu bir extension metodudur
                            .Select(p => new {Ad = p.Name, Fiyat = p.Price})
                            .ToList();
stopWatch.Stop(); // burada durdurup zamanı ölçüyoruz
Console.WriteLine($"birinci sorgunun süresi : {stopWatch.ElapsedMilliseconds.ToString()}");
Console.WriteLine();

Console.WriteLine("Extension 1");
sameResultWithExt.ForEach(x => Console.WriteLine($"{x.Ad}\t{x.Fiyat}"));

stopWatch.Restart();// timer'ımızı sıfırladık

var same = products.ToList()
                    .Where(p => p.Price < 1000)
                    .Select(p => new { Ad = p.Name, Fiyat = p.Price });
stopWatch.Stop(); // burada durdurup zamanı ölçüyoruz
Console.WriteLine($"ikinci sorgunun süresi : {stopWatch.ElapsedMilliseconds.ToString()}");

Console.WriteLine();
Console.WriteLine("Extension 2");
same.ToList().ForEach(x => Console.WriteLine($"{x.Ad}\t{x.Fiyat}"));

/* 
 * ext2, ext1'den daha yavaştır
 * yavaş olmasının nedeni belleğe atma sırasıdır
 * bunu daha iyi görebilmek için üstte bir tane timer oluşturduk
 */


Console.WriteLine("---------------- FirstOrDefault -------------------");
//id'si 6 olanı almaya çalışalım
var product = products?.FirstOrDefault( p => p.Id == 6); 
//içeri yazdığımız koşula ait bir koleksiyon dönüyorsa ilk elemanı, yoksa null döndürücez FirstOrDefault ile
Console.WriteLine($"6 nolu ürün : {product?.Name}"); // boş değilse kullan dedik ? ile 

// ama her seferinde bir koleksiyon almak yanlıştır. örnek olarak bir users döndüreceksek birden fazla insan olamaz
// o zaman koleksiyon dönmememiz lazım

//var sportProduct = products.SingleOrDefault( p => p.Description.Contains("Spor")); // bu ya tek ya da varsayılan değeri döndürür.
//birden fazla eleman dönerse hata verir.Biz de hata vermesi için spor'u verdik

Console.WriteLine();
Console.WriteLine("Fiyata göre sıraladık");
// ilk önce fiyata göre sıralayalım
var ordered1 = products.OrderBy(p => p.Price) //fiyatlar eşitse ThenByDescending çalışır
                        .ThenByDescending(st => st.Stock) // burada da stok'a göre sıraladık
                        .ToList();
ordered1.ForEach(x => Console.WriteLine($"{x.Name}\t{x.Price}"));

var averagePrice = products.Average(p => p.Price);
Console.WriteLine($"Average price: {averagePrice}");

var totalItem = products.Count(p => p.Description.Contains("Spor"));
Console.WriteLine($"total item 'spor' : {totalItem}");


// en pahalı ürün bulmak
var expensiveProduct = products.FirstOrDefault(p => p.Price == products.Max(pr => pr.Price));
Console.WriteLine();
//expensiveProduct.ForEach(x => Console.WriteLine($"en pahalı ürün \n ------ \n {x.Name}\t{x.Price}"));
// expensiveProduct'ı FirstOrDefault yerine Where yazsaydık en sonuna ToList() yazmalıydık ve üstteki şekilde bastırırdık
Console.WriteLine($"expensive product \n ------------- \n Ad : {expensiveProduct.Name} \t Fiyat : {expensiveProduct.Price}");

//JOIN : iki koleksiyon bellekte birleştirilip ortak bir sonuç üretilecek
/*
    Products
    Id   Name     CatId
    -------------------
    1    A           1
    2    B           3
 
    Categories
    Id   Name
    -----------
    1    X
    2    Y
    3    Z

    Output
    1   A   X
    2   B   Z

 */
var categories = service.GetCategories();
var joinQuery = categories.Join(products,
                                category => category,/*category'i al, product.category ile eşleştir*/
                                product => product.Category,
                                (category, product) => new { KategoriAdı = category.Name, Urun = product.Name }
                                ).ToList();
// parametreler : nereye bağlanacaksın, hangi iki nesne arasında eşleştirme yapacaksın, bu kesişim kümesinden ne istiyorsun
joinQuery.ForEach(x => Console.WriteLine($"Urun : {x.Urun} \t Kategori : {x.KategoriAdı}"));

//bunun alternatifi de şu ;
Console.WriteLine();
Console.WriteLine("Alternative Join");
var join2 = products.Select(p => new {UrunAdi = p.Name, Kategorisi = p.Category?.Name }).ToList();//bu kod üsttekinin aynısı, join kullanmadan
// üsttekiyle farkı kategorisi boş değilse yani bellekte varsa döndür dedik
join2.ForEach(x => Console.WriteLine($"Urun : {x.UrunAdi} \t Kategori : {x.Kategorisi}"));

//Group By
var group = products.GroupBy(pr => pr.Category?.Name,
                                    result => new { result.Name, result.Price},
                                    (category, products) => new
                                    {
                                        Key = category,
                                        Adet = products.Count(),
                                        EnUcuz = products.Min(p => p.Price),
                                        EnPahalı = products.Max(p => p.Price),
                                    }
                                    ).ToList();//neye göre gruplanacak, grubun yanında ne istiyorsun ürünle ilgili, nasıl bir koleksiyon istiyorsun
Console.WriteLine();
Console.WriteLine("Group By");
group.ForEach(x => Console.WriteLine($"Kategori : {x.Key} \t Adet : {x.Adet} \t En Ucuz : {x.EnUcuz} \t En Pahalı : {x.EnPahalı}"));
