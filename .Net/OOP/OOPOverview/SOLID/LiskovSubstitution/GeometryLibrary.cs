using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    public static class GeometryLibrary
    {
        //public static Rectangle RectangleFactory()
        //{
        //    // sonradan bir sekilde Square dondurmeye karar verdiniz...
        //    return new Square();
        //}

        public static IAreaCalculatable AreaCalculatable(int unit1, int? unit2 = null)//birinci birim zorunlu, ikinci birim bos gecilebilir
        {
            if(unit2.HasValue) { return new Rectangle() { Width = unit1, Height = unit2.Value }; }
            else
            {
                return new Square() { EdgeLEngth = unit1 };
            }
        }
    }
    public interface IAreaCalculatable
    {
        int GetArea();
    }

    public class Rectangle : IAreaCalculatable
    {
        public virtual int Width{ get; set; }
        public virtual int Height{ get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    //dikdortgen'de yukseklik ve genislik farklidir ama karede aynidir
    //biz de gittik ustteki class'taki ozellikleri virtual olarak tanimladik sonra
    public class Square : IAreaCalculatable
        //: Rectangle ==> dedik ki bu ikisi akraba degil ama ikisinde de ortak islev var  
    {
        //public override int Height { get => base.Height; set { base.Height = value; base.Width = value; } }
        //public override int Width { get => base.Width; set { base.Height = value; base.Width = value; } }
        //ayrica belirtilen "GELEN OZELLİK AYNI SEKİLDE KULLANİLMALİDİR" prensibi de ihlal edildi
        //super class'ta nasil tanimlandiysa sub class'ta da oyle kullanilmali
        //override edilmemesi gerekir

        public int EdgeLEngth { get; set; }

        //aralarinda ortaklik yok ama ikisinde de ortak islem varsa bunu "interface" ile saglarim

        public int GetArea()
        {
            return EdgeLEngth * EdgeLEngth;
        }
    }

}
