namespace basicThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCounter_Click(object sender, EventArgs e)
        {
            counter();//bu metod bitmeden aşağıdaki işlem yapılmaz : Senkron
            MessageBox.Show("Bitti");
        }
        private void counter()
        {

            for (int i = 0; i < 50000; i++)
            {
                labelCounter.Text = i.ToString();
            }
        }
    }
}