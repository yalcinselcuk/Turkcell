using usingDelegates;

List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var helper = new FilterHelper();
// .net 1.1, yıl olarak tahmini 2001-2003
var filtered1 = helper.Filter(numbers,isEven);

// .net 2.0 yıl olarak tahmini 2005
var filtered2 = helper.Filter(numbers, delegate(int n) { return n % 2 == 1; });//bu kez de tek olanları dondurmesini istedik
showNumbers(filtered1);
showNumbers(filtered2);
//biz delegate'e metod yazıp göndermiş olduk metod içinde

//.net 3.5, yıl 2008 ve sonrası
var filtered3 = helper.Filter(numbers, p => p > 5); //lambda operatörü ile yaptık
showNumbers(filtered3);

//.net 4.0'dan sonra
// microsoft dedi ki sen artık delegate yazma. Ben senin yerine Generic Metod oluşturdum, onu kullan
alternateShowNumbers(filtered3);

void showNumbers(List<int> filtered1)
{
    foreach (int number in filtered1) 
    {
        Console.WriteLine(number);
    }
}

void alternateShowNumbers(List<int> numbers)
{
    numbers.ForEach(n => Console.WriteLine(n));//action olusturuldu
}
bool isEven(int number)
{
    return number % 2 == 0;
}