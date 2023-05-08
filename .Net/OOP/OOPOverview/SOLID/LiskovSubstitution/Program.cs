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

Rectangle rectangle= new Rectangle { Width=5,Height=4 };
Console.WriteLine($"Rect : {rectangle.GetArea()}");
Square square = new Square { Width = 10 };
Console.WriteLine($"Square : {square.GetArea()}");