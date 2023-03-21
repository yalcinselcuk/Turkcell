using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Product
    {
        //private olan degiskenler kucuk harfle yazilir
        //public olan degiskenler buyuk harfle yazilir
        private double price;

        public void SetPrice(double price)
        {
            if (price > 0) { this.price = price; }
            else { throw new ArgumentException($"{price} degeri kabul edilemez !"); }
        }
        public double GetPrice() { return this.price; }
        //bunu Java'dan almistir C#
        //bu get-set'i aldıktan sonra su hale getirmistir;
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        //buna da property denmistir


        //ustteki de eski kaldi, artik yeni hali ;
        public int Stock { get; set; }
    }
}
