﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    public class Ekmek
    {
        public int Adet { get; set; }
        public string Tur { get; set; }

        public Ekmek() : this("Somun", 1) //constructor'ı cagirdik "this" ile
        {
            //Adet = 1;
            //Tur = "Somun Ekmek";
        }

        public Ekmek(int adet) : this("Somun", adet)
        {
            //Adet = adet;
            //Tur = "Somun";
        }

        public Ekmek(string tur) : this(tur, 1)
        {
            //Adet = 1;
            //Tur = tur;
        }

        public Ekmek(string tur, int adet)
        {
            Tur = tur;
            Adet = adet;
        }
    }
}
