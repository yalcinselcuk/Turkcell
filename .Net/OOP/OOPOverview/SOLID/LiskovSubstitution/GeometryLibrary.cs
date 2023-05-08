using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    public static class GeometryLibrary
    {
        public static Rectangle RectangleFactory()
        {
            // sonradan bir sekilde Square dondurmeye karar verdiniz...
            return new Square();
        }
    }

    public class Rectangle
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
    public class Square : Rectangle 
    {
        public override int Height { get => base.Height; set { base.Height = value; base.Width = value; } }
        public override int Width { get => base.Width; set { base.Height = value; base.Width = value; } }
    }

}
