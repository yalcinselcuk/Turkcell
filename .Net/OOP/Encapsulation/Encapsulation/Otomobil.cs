using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Otomobil
    {
        //buradaki degiskenlere ulasilamaz cunku private'lar ve erisilemezler
        int hiz = 0;
        bool arabaCalisiyorMu = false;
        public void Calistir()
        {
            arabaCalisiyorMu = true;
        }
        public void GazaBas()
        {
            if (arabaCalisiyorMu)
            {
                hiz++;
            }
            else
            {
                Console.WriteLine("Araba Calismiyor");
            }
        }
        public void Durdur()
        {
            if (arabaCalisiyorMu)
            {
                hiz = 0;
            }
            else
            {
                Console.WriteLine("Araba Calismiyor");
            }
        }
    }
}
