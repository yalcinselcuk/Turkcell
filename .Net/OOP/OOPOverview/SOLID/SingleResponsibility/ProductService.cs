using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleResponsibility
{
    //bu class geriye veri islemlerini calistiracak ve ekleme isini icraa edecek bir metod olmasi lazim
    //geriye affectedRows'u dondurmesi lazim
    public class ProductService
    {
        public int AddProduct(string name, decimal price)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-818NV7UV;Initial Catalog=deneme;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("Insert into Products (ProductName, UnitPrice) values (@name, @price)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@price", price);
            //buradaki parametreler de Form1'deki tool'larla direk islem yapmayacak

            sqlConnection.Open();
            var affectedRows = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return affectedRows;
        }

        //burada da soyle bir sikinti var
        //AddProduct isleminde yapilan islemleri Update'te tekrar edicez 
        //Dont Repeat Yourself'e dusmus oluyoruz
        //Bunun onune gecmek icin de bir BaseClass'a ihtiyacimiz var 
        //Bunun adina da klasik ad olan "DataAccess" diyelim

        public int UpdateProduct(string name, decimal price)
        {
            return 0;
        }
        public void SendInfoMailToProductOwner(string mail)
        {

        }

    }
}
