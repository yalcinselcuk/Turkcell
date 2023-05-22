using introduceEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introduceEFCore.Data
{
    public class BookStoreDbContext : DbContext
    {

        //public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        public BookStoreDbContext() { }
        /*
        EntityFramework'ü Manage NuGet üzerinden indiriyoruz ==> EntityFrameworkCore
        sonra da Db'ye Entity'mizi tanıtıyoruz DbSet ile
         */
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //db'yi nerede ve hangi opsiyonlarla oluşturucaz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            string connectionString = "Data Source=YALCINSELCUK-AC;Integrated Security=True;Initial Catalog=bookStoreSample;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
            // db'mizi belirttik ve tablomuzu nerede oluşturacağını söyledik
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(book => book.Title).IsRequired()
                                                                    .HasMaxLength(250);
            //burada tablomuzda hangilerinin boş geçiip geçilemeyeceğini de söyledik
            //ve burada belirtmek bazı yazılımcılar tarafından daha düzenli kabul ediliyor 

            modelBuilder.Entity<Book>().Property(book => book.Description).HasMaxLength(250);

            modelBuilder.Entity<Review>().HasOne(review => review.Book)//burada Review'in bir Book'a sahip olduğunu belirttik
                                         .WithMany(book => book.Reviews)//Book'un birçok Review'i olacağını söyledik
                                         .HasForeignKey(review => review.BookId)//aradaki ilişkiyi BookId ile sağladığını belirttik
                                         .OnDelete(DeleteBehavior.Restrict);
            //ilişkili tablolarda biri silindiğinde diğerine ne olacağını da devamında belirtebiliriz


        }
    }
}
