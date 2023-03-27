// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Open-Closed : bir nesne gelisime ACIK, degisime KAPALI olmali

// buna gercek hayattan bir ornek vermek gerekirse;
// klasik eski bir analog saat dusunelim
// ben bu saate gunduz mu gece mi oldugunu gosteren bir ozellik eklemek istiyorum
// bu prensib de diyor ki mevcut sistemi degistirmeden yeni carklar ekleyebiliyorsan bu prensibe uymustur

// ama bu keyfi olamaz. ornek olarak ic organlarimizi keyfimize gore yenisiyle degistiremezsek
// kodumuzu da keyfimize gore degistirmemeliyiz

// Senaryo : bir musterinin uc tip karti olabilir ; standart, silver, gold
// musteri bunlara gore indirim alacak : %5 , 10 ya da 15

// bir junior'in drami 2 :D

Customer customer = new Customer() {Name = "yalcin", Cart = new Gold() };
OrderManager orderManager = new OrderManager() { Customer = customer};
var price = orderManager.GetDiscountedPrice(100);
Console.WriteLine( $"Indirimli fiyat : {price}" );
//public enum CartType
//{
//    Standard,
//    Silver,
//    Gold
//}

public interface ICartType
{
    public double GetDiscounted(double totalPrice);//bu metodun icine hangi kart tipine gore oldugunu belirleyemedigimden abstract ya da interface olabilir
}

public class Standard : ICartType
{
    public double GetDiscounted(double totalPrice)
    {
        return totalPrice * 0.95;
    }
}
public class Silver : ICartType
{
    public double GetDiscounted(double totalPrice)
    {
        return totalPrice * 0.90;
    }
}
public class Gold : ICartType
{
    public double GetDiscounted(double totalPrice)
    {
        return totalPrice * 0.85;
    }
}
public class Customer
{
    public string Name { get; set; }
    public ICartType Cart { get; set; }
}

public class OrderManager
{
    public Customer Customer { get; set; }
    public double GetDiscountedPrice(double total)
    {
        return Customer.Cart.GetDiscounted(total);
        //switch (Customer.Cart)
        //{
        //    case CartType.Standard:
        //        return total * 0.95;
        //    case CartType.Silver:
        //        return total * 0.90;
        //    case CartType.Gold:
        //        return total * 0.85;
        //    default:
        //        return total;
        //}
    }
    // bu kodda su anlik sorun yok
    // ama ilerisi icin sikintili
    // ornek olarak Premium Kart eklensin dendiginde butun mimari degisecek 
    //buradaki switch-case yanlis oluyor
}