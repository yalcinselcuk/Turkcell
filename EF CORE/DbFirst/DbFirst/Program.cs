
using DbFirst.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var context = new NorthwindContext().Products.ToList();
context.ForEach(p => Console.WriteLine(p.ProductName));
