using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    public class ReportGenerator
    {
        //normalde asagidaki degiskenleri get-set olmadan da kullanabiliriz
        //get-set kullanmamizin nedeni ileride olusacak sartlari yazmaktir
        public string ReportFormat { get; set; }
        public string SavedPath { get; set; }
        public string ReadingDataPath { get; set; }

        //public ReportGenerator()
        //{
        //    ReportFormat = "PDF";
        //}
        //public ReportGenerator(string reportFormat)
        //{
        //    this.ReportFormat= reportFormat;
        //}

        public ReportGenerator(string readingPath)
        {
            this.ReadingDataPath = readingPath;
        }
    }
}
