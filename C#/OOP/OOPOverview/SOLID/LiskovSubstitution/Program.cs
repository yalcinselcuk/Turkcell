/*
 * 
 * Liskov diyor ki :
 * bir sınıf bir başkasına miras veriyorsa ; bu sınıflar BİRBİRLERİNİN YERİNE KULLANILABİLİR olmalı.
 * birbirinin yerine kullanıldığında herhangi bir hata vermemeli
 * 
 * Bir sınıf miras aldığı sınıfın özelliklerini AYNEN KULLANMAK ZORUNDADIR
 * 
 * 
 */

using LiskovSubstitution;

//Rectangle rectangle= new Rectangle { Width=5,Height=4 };
//Console.WriteLine($"Rect : {rectangle.GetArea()}");
//Square square = new Square { Width = 10 };
//Console.WriteLine($"Square : {square.GetArea()}");

//var rectangle2 = GeometryLibrary.RectangleFactory();
//rectangle2.Width = 10;
//rectangle2.Height = 5;

//Console.WriteLine($"rect2 : {rectangle2.GetArea()}");
//normalde bize 50 donmesi gerekirken 25 dondu
//liskov prensibine gore Rectangle ile Square birbiri yerine kullanilabilmesi gerekirken kullanilamadi

var rect = GeometryLibrary.AreaCalculatable(5, 4);
Console.WriteLine($"Dortgen Alani : {rect.GetArea()}");

var rect2 = GeometryLibrary.AreaCalculatable(5);
Console.WriteLine($"Dortgen Alani : {rect2.GetArea()}");