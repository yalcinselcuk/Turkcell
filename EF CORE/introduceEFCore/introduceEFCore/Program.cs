
using introduceEFCore.Data;
using Microsoft.EntityFrameworkCore;
using introduceEFCore.Models;
Console.WriteLine("Hello, World!");

var dbContext = new BookStoreDbContext();

Author author = new Author() { Name = "Jules", LastName = "Verne" };
dbContext.Authors.Add(author);

Book book = new Book() { Title = "Denizler Altında 20000 Fersah", Authors = new List<Author> { author} };
dbContext.Books.Add(book);

dbContext.SaveChanges();

//BookStoreDbContext context = new BookStoreDbContext(optionBuilder.Options);
