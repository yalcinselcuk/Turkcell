// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");
ArrayList words = new ArrayList
{
    15
};
//demek ki boxing ve unboxing sadece MECBUR OLUNCA kullanılmalı.

GenericPoint<decimal> genericPoint = new GenericPoint<decimal>();
string kelime = "naber?";
//var output = GetTypeOfGeneric(kelime,5);
//Console.WriteLine(output);

string a = "Türkay";
string b = " Ürkmez";

Console.WriteLine($"{a} {b}");
Swap(ref a, ref b);
Console.WriteLine($"{a} {b}");
//burada eger ref vermezsek metod bir sey dondurmediginden ve sadece islem yaptigindan swap islemi olmaz 
//buradaki yani main'deki verilen string'leri dondurur
//ref vererek metodta yapilan islem sonucunun dondurulmesini sagladik

List<string> items = new List<string>();
//Generic Interface'de varyant-kovaryant-contravaryant kavramını araştırınız.... 




T GetTypeOfGeneric<T, W>(T type, W type2) where T : class, new()
                                              where W : class, new()
{
    var t = new T();
    return t;
}


void Swap<T>(ref T t1, ref T t2)
{
    T temp;
    temp = t2;
    t2 = t1;
    t1 = temp;

}


public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public void Reset()
    {
        X = 0;
        Y = 0;
    }
}

public class DoublePoint
{
    public double X { get; set; }
    public double Y { get; set; }

    public void Reset()
    {
        X = 0.0;
        Y = 0.0;
    }
}

public class ObjectPoint//2005 oncesinde tercih edilen. int-double'i 2 ayri class'ta tutmak yerine boyle yapilirdi
                        //bu da boxing-unboxing'e neden oldu
{
    public object X { get; set; }
    public object Y { get; set; }
}

/// <summary>
/// 
/// eger ki tipleri sonradan belirtmek istiyorsak Generic yapariz 
/// Generic'te arka tarafta obje olusturulmaz
/// biz ne dediysek arka planda o tipi olusturur
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class GenericPoint<T> where T : struct //buradaki where sartiyla struct'lari yani primitif tipleri verebiliriz
{
    public T X { get; set; }
    public T Y { get; set; }

    public void Reset()
    {
        X = default(T);//buradaki x ve y'nin tiplerini bilmedigimizden default() dedik yani varsayilan tipine dondur dedik
        Y = default(T);
    }

}
