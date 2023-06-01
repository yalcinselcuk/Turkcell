﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVSInterface
{
    public abstract class Document
    {
        public abstract void Save();
        public abstract void Open();

        //public abstract void Print();

        public void Copy(string from, string to)
        {
            Console.WriteLine($"{from} adresinden {to} adresine kopyalandı");
        }

        public string Title { get; set; }
        public string Owner { get; set; }
    }


    public interface IPrintable
    {
        void Print();
    }
    public class PdfDocument : Document
    {
        public override void Open()
        {
            Console.WriteLine("Pdf açılıyor");
        }

        //public override void Print()
        //{
        //    Console.WriteLine("Pdf çıktısı alındı");
        //}

        public override void Save()
        {
            Console.WriteLine("Pdf kaydedildi");

        }
    }

    public class ExcelDocument : Document, IPrintable
    {
        public override void Open()
        {
            Console.WriteLine("Excel açılıyor");

        }

        public void Print()
        {
            Console.WriteLine("Excel çıktısı alındı");

        }

        public override void Save()
        {
            Console.WriteLine("Excel kaydedildi");

        }
    }

    public class WordDocument : Document, IPrintable
    {
        public override void Open()
        {
            Console.WriteLine("Word açılıyor");

        }

        public void Print()
        {
            Console.WriteLine("Word çıktısı alındı");

        }

        public override void Save()
        {
            Console.WriteLine("Word kaydedildi");


        }
    }


    public class PrintDocumentComponent
    {
        public void Print(IPrintable document)
        {
            document.Print();
        }
    }

}
