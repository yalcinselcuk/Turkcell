// See https://aka.ms/new-console-template for more information
using CounterStrike;

Console.WriteLine("Hello, World!");

Oyuncu oyuncu= new Oyuncu();
Ak47 ak47= new Ak47 { Ad = "Ak 47"}; //burada yapilan : object initializer
DesertEagle desertEagle= new DesertEagle();

oyuncu.OyuncununSilahi = desertEagle;
oyuncu.Saldir();
oyuncu.SarjorDegistir();
oyuncu.SagTikla();

oyuncu.OyuncununSilahi = ak47;
oyuncu.Saldir();
oyuncu.SarjorDegistir();
oyuncu.SagTikla();
