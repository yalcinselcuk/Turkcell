using introduceEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introduceEFCore.Data
{
    public class BookStoreDbContext :DbContext 
    {
        private const string connectionString = "Data Source=YALCINSELCUK-AC;Integrated Security=True;Initial Catalog=bookStoreSample";
        /*
        EntityFramework'ü Manage NuGet üzerinden indiriyoruz ==> EntityFrameworkCore
        sonra da Db'ye Entity'mizi tanıtıyoruz DbSet ile
         */
        public DbSet<Book> Books{ get; set; }

        //db'yi nerede ve hangi opsiyonlarla oluşturucaz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            // db'mizi belirttik ve tablomuzu nerede oluşturacağını söyledik
        }
    }
}
