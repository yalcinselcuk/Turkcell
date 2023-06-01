// See https://aka.ms/new-console-template for more information
using Encapsulation;

Console.WriteLine("Hello, World!");

Otomobil otomobil = new Otomobil();
/*otomobil.Calistir();
otomobil.GazaBas();
otomobil.Durdur();*/

Product product = new Product();
Console.Write("Price : ");
int price = Convert.ToInt32(Console.ReadLine());
product.SetPrice(price);
Console.WriteLine(product.GetPrice());

product.Name = "Telefon";
Console.WriteLine(product.Name);

product.Stock = 200;
Console.WriteLine(product.Stock);