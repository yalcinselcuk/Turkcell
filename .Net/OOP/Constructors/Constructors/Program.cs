// See https://aka.ms/new-console-template for more information
using Constructors;

Console.WriteLine("Hello, World!");

ReportGenerator reportGenerator = new ReportGenerator("C:\\data.txt");
Console.WriteLine(reportGenerator.ReadingDataPath);

ReportGenerator reportGenerator2 = new ReportGenerator(readingPath : "Excel");//constructor'da deger gonderilen degiskeni burada belirtebiliriz
Console.WriteLine(reportGenerator2.ReadingDataPath);

Ekmek ekmek = new Ekmek("kepek", 2);

