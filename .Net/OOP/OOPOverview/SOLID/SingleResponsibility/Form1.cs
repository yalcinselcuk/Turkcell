using System.Data.SqlClient;

namespace SingleResponsibility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //SRP : Her nesnenin SADECE BİR sorumluluğu olmalı !

        //hangi kosulda bunu ihlal edersin ?
        //kitapta yazana gore (GoF Design Patterns) ;
        //1. bir nesnede degisiklik yapmak icin birden fazla sebebiniz varsa ; bu prensibi ihlal ediyorsunuz demektir
        //bir de turkay hoca yontemi var : bunu kod yazdıktan 

        //bu uygulamanin amaci db'ye urun eklemek
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-818NV7UV;Initial Catalog=deneme;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("Insert into Products (ProductName, UnitPrice) values (@name, @price)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", textBoxName.Text);
            sqlCommand.Parameters.AddWithValue("@price", Convert.ToDecimal(textBoxPrice.Text));

            sqlConnection.Open();
            var affectedRows = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            string message = affectedRows > 0 ? "Basarili" : "İslem Yapilamadi";
            MessageBox.Show(message);

        }
    }
}