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
            // bir junior'in kodu :D

            // SqlConnection, SqlCommand, Parametreler, Baglanti acma ve kapatma kismi da ProductService'in gorevi
            
            ProductService productService = new ProductService();
            string name = textBoxName.Text;
            decimal price = Convert.ToDecimal(textBoxPrice.Text);

            var affectedRows = productService.AddProduct(name, price);

            string message = affectedRows > 0 ? "Basarili" : "İslem Yapilamadi";
            MessageBox.Show(message);

            // bu formda degisiklik yapilmak istense ;
            // 1.formun arayuzu, design'i : renk, yazi stili, controllerin yerleri
            // 2.veritabaniyla iliskiniz degistiginde bu nesnede degisiklik yapilmasi gerekiyor
            // yani su anda srp'yi ihlal ediyoruz 
            
            // sira Turkay Hoca'nin tekniginde 
            // Form1 insan olsaydi gorevini nasil tanimlardi?
            // derdi ki : benim gorevim kullanicidan verileri almak, butona tiklanmasini takip etmek, arkada olan sonucu kullaniciya gostermek 
            // baska bir gorevim yok derdi

            // o zaman diyoruz ki bu tanimin disinda yer alan her sey baska bir class'in gorevidir

            // 2. Form1 insan evladi olsaydi, sorumlulugunu nasil anlatirdi ? (Turkay Hoca Yontemi)

            //parametreleri atamak ve mesajla gostermek Form1'in gorevi 
            //onun disindakiler baska bir elemanin gorevi
            //o gorevler icin de yeni bir eleman almamiz lazim ve bu arkadas gorevi ustlenecek
        
            //ustteki kod Form1'in sorumlulugunu gerceklestirmekte
        }
    }
}