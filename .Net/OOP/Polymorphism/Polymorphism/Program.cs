// See https://aka.ms/new-console-template for more information
using Polymorphism;

Console.WriteLine("Hello, World!");

Asci asci = new Asci();
asci.Pisir(new Baklava());

//bu yazilis sekli ne kadar dogru?
//yoksa direk new'i acikca mi yazmaliyim?
asci.Pisir(new Kurufasulye(){ Ad = "Kuru Fasulye" }) ;