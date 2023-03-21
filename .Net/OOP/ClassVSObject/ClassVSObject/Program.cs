// See https://aka.ms/new-console-template for more information
using ClassVSObject;

Console.WriteLine("Hello, World!");

Product p1 = new Product();
p1.Name= "Laptop";

Product p2 = p1;
//p1 adresini p2'ye kopyalamış oluruz
p2.Name = "Telefon";

Console.WriteLine(p1.Name);