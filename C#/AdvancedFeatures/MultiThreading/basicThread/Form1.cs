namespace basicThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;//winform'a özgü bu
            InitializeComponent();
        }

        Thread thread = null;
        private void buttonCounter_Click(object sender, EventArgs e)
        {
            //counter();//bu metod bitmeden aşağıdaki işlem yapılmaz : Senkron

            thread = new Thread(new ThreadStart(counter));
            thread.Start();//bunu sen çalıştır, diğerini ben yaparım dedik
            thread.Join();//üstteki thread bitmeden alttaki iş yapılmasın dedik, bu da senkrona dönüştürdü
            MessageBox.Show("Bitti");//bu mesajı da başlar başlamaz gösterir, çünkü buradaki thread'te tek yapılacak bu iş var ve bunu yapıp bitirir
        }
        private void counter()
        {

            for (int i = 0; i <= 10000; i++)
            {
                labelCounter.Text = i.ToString();
                progressBar1.Value = i / 100;
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Show");
        }
    }
}