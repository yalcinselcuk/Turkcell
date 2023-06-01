string geometry = Console.ReadLine();
if (geometry == "Kare")
{
    Console.WriteLine("birim kenarın karesi");
}
else if (geometry == "Daire")
{
    Console.WriteLine("yarı çapın karesi x pi");

}
else if (geometry == "Üçgen")
{
    Console.WriteLine("(taban * yükseklik ) / 2");

}

switch (geometry)
{
    case "Kare":
        Console.WriteLine("birim kenarın karesi");
        break;
    case "Daire":
        Console.WriteLine("yarı çapın karesi x pi");
        break;
    case "Üçgen":
        Console.WriteLine("(taban * yükseklik ) / 2");
        break;
    default:
        break;
}


Console.WriteLine("Bir sembol seçiniz (Sinek, Maça, Kupa, Karo)");
string symbol = Console.ReadLine();

switch (symbol)
{
    case "Sinek" or "Maça":
        Console.WriteLine("Siyah renk");
        break;

    //asagidaki case birlestirme
    case "Karo":
    case "Kupa":
        Console.WriteLine("Kırmızı renk");
        break;
    default:
        break;
}

//switch (DateTime.Now.DayOfWeek)
//{
//    case DayOfWeek.Sunday:
//        break;
//    case DayOfWeek.Monday:
//        break;
//    case DayOfWeek.Tuesday:
//        break;
//    case DayOfWeek.Wednesday:
//        break;
//    case DayOfWeek.Thursday:
//        break;
//    case DayOfWeek.Friday:
//        break;
//    case DayOfWeek.Saturday:
//        break;
//    default:
//        break;
//}